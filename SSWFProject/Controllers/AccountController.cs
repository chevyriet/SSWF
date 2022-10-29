using DomainServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Portal.Models;

namespace Portal.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IStudentRepository _studentRepository;
        private readonly IMealBoxRepository _mealBoxRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IStudentRepository studentRepository, IMealBoxRepository mealBoxRepository, IEmployeeRepository employeeRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _studentRepository = studentRepository;
            _mealBoxRepository = mealBoxRepository;
            _employeeRepository = employeeRepository;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View("Login", new LoginViewModel());
        }

        [Authorize(Policy = "OnlyStudentUsersAndUp")]
        public IActionResult Profile()
        {
            var student = _studentRepository.GetStudentByEmail(User.Identity!.Name!);
            IEnumerable<MealBox> MealBoxes = _mealBoxRepository.GetMealBoxesByStudentId(student!.Id);

            var viewModel = new ReservedMealBoxesViewModel
            {
                Student = student,
                MealBoxes = MealBoxes
            };
            return View("Profile", viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(lvm.EmailAddress);
                if(user != null)
                {
                    if((await _signInManager.PasswordSignInAsync(user, lvm.Password, false, false)).Succeeded)
                    {
                        return RedirectToAction("Profile");
                    }
                }
            }

            ModelState.AddModelError("WrongEmailPasswordError", "Verkeerd email of wachtwoord");
            return View();
        }

        [AllowAnonymous]
        public IActionResult EmployeeLogin()
        {
            return View("EmployeeLogin");
        }

        [Authorize(Policy = "OnlyEmployeeUsersAndUp")]
        public IActionResult Admin()
        {
            var employee = _employeeRepository.GetEmployeeByNr(User.Identity!.Name!);
            IEnumerable<MealBox> MealBoxes = _mealBoxRepository.Mealboxes;

            var viewModel = new EmployeeViewModel
            {
                Employee = employee,
                MealBoxes = MealBoxes
            };
            return View("Admin", viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EmployeeLogin(EmployeeLoginViewModel elvm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(elvm.EmployeeNr);
                if (user != null)
                {
                    if ((await _signInManager.PasswordSignInAsync(user, elvm.Password, false, false)).Succeeded)
                    {
                        return RedirectToAction("Admin");
                    }
                }
            }

            ModelState.AddModelError("", "Verkeerd medewerker nummer of wachtwoord");
            return View("EmployeeLogin");
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

    }
}
