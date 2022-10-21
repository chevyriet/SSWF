using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB_EF
{
    public class EBSeedData : ISeedData
    {
        private EBDbContext _context;
        private ILogger<EBSeedData> _logger;

        public EBSeedData(EBDbContext context, ILogger<EBSeedData> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task EnsurePopulated(bool dropExisting = false)
        {
            _context.Products.RemoveRange(_context.Products);
            _context.Students.RemoveRange(_context.Students);
            _context.Employees.RemoveRange(_context.Employees);
            _context.Cantinas.RemoveRange(_context.Cantinas);
            _context.MealBoxes.RemoveRange(_context.MealBoxes);
            if (_context.MealBoxes?.Count() == 0 && _context.Products?.Count() == 0 && _context.Students?.Count() == 0 && _context.Employees?.Count() == 0 && _context.Cantinas?.Count() == 0)
            {
                _logger.LogInformation("Preparing to seed database");

                Cantina Cantina1 = new Cantina { City = City.Breda, Location = "LA", ServesWarm = true };

                Product Product1 = new Product { Name = "Spinazie", ContainsAlcohol = false, Image = "image" };
                Product Product2 = new Product { Name = "Vissticks", ContainsAlcohol = false, Image = "image" };
                Product Product3 = new Product { Name = "Salade", ContainsAlcohol = false, Image = "image" };
                Product Product4 = new Product { Name = "Smoothie", ContainsAlcohol = false, Image = "image" };

                _context.Products.AddRange(new[] { Product1, Product2, Product3, Product4 });

                List<Product> products1 = new List<Product> { Product1, Product2 };
                List<Product> products2 = new List<Product> { Product3, Product4 };

                Student Student1 = new Student { FirstName = "Chevy", LastName = "Rietveld", City = City.Breda, PhoneNumber = "0651160300", DateOfBirth = DateTime.Now.AddYears(-20), StudentNr = "2188423"};

                _context.MealBoxes.Add(new MealBox { Name = "Spinazie Pakket", Cantina = Cantina1, City = City.Breda, IsEighteen = false, Type = MealType.WarmDinner, Price = 7.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = products1 });
                _context.MealBoxes.Add(new MealBox { Name = "Gezond Lunch Pakket", Cantina = Cantina1, City = City.Breda, IsEighteen = false, Type = MealType.Lunch, Price = 6.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = products2 });

                _context.SaveChanges();
                _logger.LogInformation("Database has been seeded");
            }
            else
            {
                _logger.LogInformation("Database has not been seeded");
            }
        }
    }

}
