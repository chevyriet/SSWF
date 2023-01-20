using Domain;
using DomainServices;
using EB_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

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
        public ActionResult<MealBox> CreateMealBox(NewMealBoxDTOWithoutReservation mealBox)
        {
            List<Product> products = new List<Product>();
            foreach (var p in mealBox.Products)
            {
                products.Add(new Product { Id = p.Id, Name = p.Name, ContainsAlcohol = p.ContainsAlcohol, ImgUrl = p.ImgUrl });
            }

            MealBox? newMealBox = new MealBox
            {
                Name = mealBox.Name,
                City = mealBox.City,
                PickupFromTime = mealBox.PickupFromTime,
                PickupUntilTime = mealBox.PickupUntilTime,
                Price = mealBox.Price,
                IsEighteen = mealBox.IsEighteen,
                Type = mealBox.Type,
                IsWarm = mealBox.IsWarm,
                Cantina = mealBox.Cantina,
                Products = products
            };

            return _mealBoxRepository.CreateMealBox(newMealBox);
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