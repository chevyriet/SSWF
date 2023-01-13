using Domain;
using DomainServices;
using EB_GraphQL.Models;

namespace EB_GraphQL.GraphQL
{
    [ExtendObjectType("Mutation")]
    public class MealBoxMutation
    {
        private readonly IMealBoxRepository _mealBoxRepository;
        private readonly IStudentRepository _studentRepository;

        public MealBoxMutation(IMealBoxRepository mealBoxRepository, IStudentRepository studentRepository)
        {
            _mealBoxRepository = mealBoxRepository;
            _studentRepository = studentRepository;
        }

        public MealBox? CreateMealBox(NewMealBoxDTO mealBox)
        {
            List<Product> products = new List<Product>();
            foreach (var p in mealBox.Products)
            {
                products.Add(new Product { Id = p.Id, Name = p.Name, ContainsAlcohol = p.ContainsAlcohol, ImgUrl = p.ImgUrl });
            }

            MealBox? newMealBox = _mealBoxRepository.CreateMealBox(new MealBox 
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
                }
            );

            return newMealBox;
        }

        public MealBox? EditMealBox(NewMealBoxDTOId mealBox)
        {
            List<Product> products = new List<Product>();
            foreach (var p in mealBox.Products)
            {
                products.Add(new Product { Id = p.Id, Name = p.Name, ContainsAlcohol = p.ContainsAlcohol, ImgUrl = p.ImgUrl });
            }

            MealBox? updatedMealBox = new MealBox
            {
                Id = mealBox.Id,
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

            _mealBoxRepository.EditMealBox(updatedMealBox);

            return updatedMealBox;
        }

        public void DeleteMealBox(int id)
        {
            var MealBox = _mealBoxRepository.GetMealBoxById(id);

            if(MealBox != null)
            {
                _mealBoxRepository.DeleteMealBox(id);
            }

        }

        public MealBox? ReserveMealBox(int mealBoxId, string studentEmail)
        {
            var mealBox = _mealBoxRepository.GetMealBoxById(mealBoxId);
            var student = _studentRepository.GetStudentByEmail(studentEmail);

            if(mealBox != null && student != null)
            {
                return _mealBoxRepository.ReserveMealBox(mealBoxId, student);
            }

            return mealBox;
        }

    }
}
