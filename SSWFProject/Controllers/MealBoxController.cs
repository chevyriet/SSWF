using DomainServices;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;
using SSWFProject.Models;
using System.Diagnostics;

namespace Portal.Controllers
{
    public class MealBoxController : Controller
    {
        private readonly IMealBoxRepository _repository;

        public MealBoxController(IMealBoxRepository repository)
        {
            _repository = repository;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
