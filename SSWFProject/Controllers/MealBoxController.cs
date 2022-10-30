using Domain;
using DomainServices;
using DomainServices.Rules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portal.Models;
using SSWFProject.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Portal.Controllers
{
    public class MealBoxController : Controller
    {
        private readonly IMealBoxRepository _repository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProductRepository _productRepository;
        private readonly IStudentRepository _studentRepository;

        public MealBoxController(IMealBoxRepository repository, IEmployeeRepository employeeRepository, IProductRepository productRepository, IStudentRepository studentRepository)
        {
            _repository = repository;
            _employeeRepository = employeeRepository;
            _productRepository = productRepository;
            _studentRepository = studentRepository;
        }

        public IActionResult MealBoxes(int? id)
        {
            if(id == null)
            {
                var viewModel = new MealBoxViewModel
                {
                    MealBoxes = _repository.Mealboxes,
                };
                return View("MealBoxes", viewModel);
            }
            var mealbox = _repository.GetMealBoxById(id.Value);
            if(mealbox == null)
            {
                return NotFound();
            }

            return View("MealBoxDetail", mealbox);
        }

        [HttpPost]
        public IActionResult MealBox(int id)
        {
            _repository.DeleteMealBox(id);
            return RedirectToAction("Admin", "Account");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create()
        {
            var employee = _employeeRepository.GetEmployeeByNr(User.Identity!.Name!);
            ViewBag.CreateCityChoice = employee?.Cantina.City;
            ViewBag.CantinaServesWarm = employee?.Cantina.ServesWarm;
            ViewBag.CreateLocationChoice = employee?.Cantina.Location;

            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            foreach(Product p in _productRepository.Products)
            {
                productViewModels.Add(new ProductViewModel { Product = p, isSelected = false});
            }

            var viewModel = new CreateUpdateMealBoxViewModel
            {
                MealBox = new MealBox(),
                ProductViewModels = productViewModels,
            };

            return View("CreateBox", viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateUpdateMealBoxViewModel cbvm)
        {
            MealBox? mealBox = cbvm.MealBox;
            mealBox.PickupFromTime = DateTime.Now;
            mealBox.Products = new List<Product>();
            var employee = _employeeRepository.GetEmployeeByNr(User.Identity!.Name!);
            mealBox.Cantina = employee.Cantina;

            IList<ProductViewModel> productViewModels = cbvm.ProductViewModels;

            foreach (ProductViewModel p in productViewModels)
            {
                if (p.isSelected)
                {
                    mealBox.Products.Add(p.Product);
                    if (p.Product.ContainsAlcohol)
                    {
                        mealBox.IsEighteen = true;
                    }
                }

            }

            var createdMealBox = _repository.CreateMealBox(mealBox);
            if(createdMealBox == null)
            {
                ModelState.AddModelError("error", "An Error occured while Creating");
                return View();
            }

            return RedirectToAction("Admin", "Account");
        }

        public IActionResult Edit(int id)
        {
            var employee = _employeeRepository.GetEmployeeByNr(User.Identity!.Name!);
            ViewBag.CantinaServesWarm = employee?.Cantina.ServesWarm;

            MealBox? mealbox = _repository.GetMealBoxById(id);
            if (mealbox == null)
            {
                return NotFound();
            }

            List<ProductViewModel> productViewModels = new List<ProductViewModel>();
            foreach (Product p in _productRepository.Products)
            {
                if (mealbox.Products.Contains(p))
                {
                    productViewModels.Add(new ProductViewModel { Product = p, isSelected = true });
                } else
                {
                    productViewModels.Add(new ProductViewModel { Product = p, isSelected = false });
                }
            }

            var viewModel = new CreateUpdateMealBoxViewModel
            {
                MealBox = mealbox,
                ProductViewModels = productViewModels,
            };

            return View("EditBox", viewModel);
        }

        [HttpPost]
        public IActionResult Edit(CreateUpdateMealBoxViewModel cbvm)
        {
            MealBox? mealBox = cbvm.MealBox;
            mealBox.Products = new List<Product>();

            IList<ProductViewModel> productViewModels = cbvm.ProductViewModels;

            foreach (ProductViewModel p in productViewModels)
            {
                if (p.isSelected)
                {
                    mealBox.Products.Add(p.Product);
                    if (p.Product.ContainsAlcohol)
                    {
                        mealBox.IsEighteen = true;
                    }
                }

            }

            var updatedMealBox = _repository.EditMealBox(mealBox);
            if(updatedMealBox == null)
            {
                ModelState.AddModelError("error", "An Error occured while Updating");
                return View("EditBox");
            }

            return RedirectToAction("Admin", "Account");
        }

        [HttpPost]
        public IActionResult ReserveMealBox(int id)
        {
            var student = _studentRepository.GetStudentByEmail(User.Identity!.Name!);
            MealBox? mealBox = _repository.GetMealBoxById(id);
            StudentCheckService studentCheckService = new StudentCheckService();
            MealBoxReservationService mealBoxReservationService = new MealBoxReservationService(studentCheckService);

            if(mealBoxReservationService.DoesMealBoxAndStudentExist(student, mealBox)){
                if (!mealBoxReservationService.HasMealBoxAlreadyBeenReserved(mealBox))
                {
                    if (_repository.GetMealBoxesByStudentId(student.Id).Where(m => m.PickupFromTime.Value.Date.Equals(DateTime.Now.Date)).Count() > 0)
                    {
                        ModelState.AddModelError("ReserveMoreThanOneError", "Kan niet meer dan 1 pakket per ophaaldag reserveren!");
                        return View("MealBoxDetail", mealBox);
                    }
                    else
                    {
                        if (mealBox.IsEighteen)
                        {
                            if (!studentCheckService.IsStudentOfAge(student, mealBox))
                            {
                                ModelState.AddModelError("TooYoungError", "Moet 18+ zijn om dit pakket te kunnen reserveren");
                                return View("MealBoxDetail", mealBox);
                            }
                            else
                            {
                                _repository.ReserveMealBox(id, student);
                            }
                        }
                        else
                        {
                            _repository.ReserveMealBox(id, student);
                        }
                    }
                } else
                {
                    ModelState.AddModelError("AlreadyReservedError", "Pakket is ondertussen al gereserveerd, kan niet reserveren");
                    return View("MealBoxDetail", mealBox);
                }
            } else
            {
                ModelState.AddModelError("DoesNotExistError", "Pakket of Student bestaat niet");
                return View("MealBoxDetail", mealBox);
            }
            

            return RedirectToAction("Profile", "Account");
        }

    }
}
