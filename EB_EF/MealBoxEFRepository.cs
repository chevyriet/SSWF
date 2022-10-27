using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DomainServices;
using Microsoft.EntityFrameworkCore;

namespace EB_EF
{
    public class MealBoxEFRepository : IMealBoxRepository
    {
        private readonly EBDbContext _dbContext;

        public MealBoxEFRepository(EBDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MealBox> Mealboxes => _dbContext.MealBoxes.Include(m => m.Products).Include(m => m.Cantina).ToList();

        public MealBox? GetMealBoxById(int id)
        {
            return _dbContext.MealBoxes.Include(m => m.Products).Include(m => m.Cantina).FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<MealBox> GetMealBoxesByStudentId(int studentId)
        {
            return _dbContext.MealBoxes.Include(m => m.Products).Include(m => m.Cantina).Where(m => m.Student.Id == studentId).ToList();
        }

        public void DeleteMealBox(int id)
        {
            MealBox? mealBox = _dbContext.MealBoxes.Include(m => m.Products).Include(m => m.Cantina).FirstOrDefault(m => m.Id == id);
            if(mealBox != null && mealBox.Student == null)
            {
                List<MealBoxProduct> mpList = _dbContext.MealBoxesProducts.Where(p => p.MealBoxId == id).ToList();
                foreach(MealBoxProduct mp in mpList)
                {
                    _dbContext.MealBoxesProducts.Remove(mp);
                    _dbContext.SaveChanges();
                }

                _dbContext.MealBoxes.Remove(mealBox);
                _dbContext.SaveChanges();
            }
        }

        public MealBox? CreateMealBox(MealBox mealBox)
        {
            MealBox? newMealBox = new MealBox() { Name = mealBox.Name, City = mealBox.City, PickupFromTime = mealBox.PickupFromTime, PickupUntilTime = mealBox.PickupUntilTime, Price = mealBox.Price, IsEighteen = mealBox.IsEighteen, Type = mealBox.Type, Cantina = mealBox.Cantina, Products = new List<Product>() };
            _dbContext.MealBoxes.Add(newMealBox);
            _dbContext.SaveChanges();

            foreach (Product p in mealBox.Products)
            {
                _dbContext.MealBoxesProducts.Add(new MealBoxProduct { MealBoxId = newMealBox.Id, ProductId = p.Id });
            }
            _dbContext.SaveChanges();

            return newMealBox;
        }

        public MealBox? EditMealBox(MealBox mealBox)
        {
            MealBox? mealBoxToUpdate = _dbContext.MealBoxes.Include(m => m.Products).Include(m => m.Cantina).FirstOrDefault(m => m.Id == mealBox.Id);
            if (mealBoxToUpdate != null)
            {
                mealBoxToUpdate.Name = mealBox.Name;
                mealBoxToUpdate.City = mealBox.City;
                mealBoxToUpdate.PickupUntilTime = mealBox.PickupUntilTime;
                mealBoxToUpdate.Price = mealBox.Price;
                mealBoxToUpdate.IsEighteen = mealBox.IsEighteen;
                mealBoxToUpdate.Type = mealBox.Type;
                mealBoxToUpdate?.Products?.Clear();

                _dbContext.SaveChanges();

                foreach(Product p in mealBox.Products)
                {
                    _dbContext.MealBoxesProducts.Add(new MealBoxProduct { MealBoxId = mealBoxToUpdate.Id, ProductId = p.Id });
                }

                _dbContext.SaveChanges();
            }

            return mealBoxToUpdate;
        }
    }
}
