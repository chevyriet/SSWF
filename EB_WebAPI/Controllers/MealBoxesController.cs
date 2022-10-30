using Domain;
using DomainServices;
using EB_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EB_WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MealBoxesController : ControllerBase
    {
        private readonly IMealBoxRepository _mealBoxRepository;

        public MealBoxesController(IMealBoxRepository mealBoxRepository)
        {
            _mealBoxRepository = mealBoxRepository;
        }

        [HttpGet]
        public ActionResult<List<MealBox>> Get()
        {
            return Ok(_mealBoxRepository.Mealboxes);
        }

        [HttpGet("{id}")]
        public ActionResult<MealBox> GetMealBoxById(int id)
        {
            return Ok(_mealBoxRepository.GetMealBoxById(id));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMealBox(int id)
        {
            var mealBox = _mealBoxRepository.GetMealBoxById(id);
            _mealBoxRepository.DeleteMealBox(mealBox.Id);

            return new NoContentResult();
        }

        [HttpPost]
        public ActionResult<MealBox> CreateMealBox(MealBox mealBox)
        {
            return _mealBoxRepository.CreateMealBox(mealBox);
        }

        [HttpPut]
        public ActionResult<MealBox> EditMealBox(MealBox mealBox)
        {
            return _mealBoxRepository.EditMealBox(mealBox);
        }

        [HttpPut("{id}/students/{student}")]
        public ActionResult<MealBox> ReserveMealBox(int id, Student student)
        {
            return _mealBoxRepository.ReserveMealBox(id, student);
        }

    }
}