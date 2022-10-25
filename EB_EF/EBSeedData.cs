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
            _context.Cantinas.RemoveRange(_context.Cantinas);
            _context.MealBoxes.RemoveRange(_context.MealBoxes);
            _context.Employees.RemoveRange(_context.Employees);
            _context.Students.RemoveRange(_context.Students);
            _context.Products.RemoveRange(_context.Products);

            _logger.LogInformation("Preparing to seed database");

            Cantina Cantina1 = new Cantina { City = City.Breda, Location = "LA", ServesWarm = true };
            Cantina Cantina2 = new Cantina { City = City.Breda, Location = "LD", ServesWarm = true };
            Cantina Cantina3 = new Cantina { City = City.Tilburg, Location = "TLD", ServesWarm = true };

            Product Product1 = new Product { Name = "Spinazie", ContainsAlcohol = false, ImgUrl = "~/images/spinazie-img.jpg" };
            Product Product2 = new Product { Name = "Vissticks", ContainsAlcohol = false, ImgUrl = "~/images/visticks-img.png" };
            Product Product3 = new Product { Name = "Salade", ContainsAlcohol = false, ImgUrl = "~/images/salade-img.jpg" };
            Product Product4 = new Product { Name = "Smoothie", ContainsAlcohol = false, ImgUrl = "~/images/smoothie-img.png" };

            List<Product> products1 = new List<Product> { Product1, Product2 };
            List<Product> products2 = new List<Product> { Product3, Product4 };

            Student Student1 = new Student { FirstName = "Chevy", LastName = "Rietveld", City = City.Breda, PhoneNumber = "0651160300", DateOfBirth = DateTime.Now.AddYears(-20), StudentNr = "2188423", EmailAddress = "chevyriet040104@gmail.com" };
            _context.Students.Add(Student1);

            _context.MealBoxes.Add(new MealBox { Name = "Spinazie Pakket", Cantina = Cantina1, City = Cantina1.City, IsEighteen = false, Type = MealType.WarmDinner, Price = 7.99, PickupFromTime = DateTime.Now, Student = Student1, PickupUntilTime = DateTime.Now.AddHours(10), Products = products1 });
            _context.MealBoxes.Add(new MealBox { Name = "Gezond Lunch Pakket", Cantina = Cantina1, City = Cantina1.City, IsEighteen = false, Type = MealType.Lunch, Price = 6.99, PickupFromTime = DateTime.Now, Student = Student1, PickupUntilTime = DateTime.Now.AddHours(10), Products = products2 });

            _context.MealBoxes.Add(new MealBox { Name = "Brood Pakket", Cantina = Cantina2, City = Cantina2.City, IsEighteen = false, Type = MealType.Bread, Price = 4.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = products2 });
            _context.MealBoxes.Add(new MealBox { Name = "Vettig Ontbijt Pakket", Cantina = Cantina3, City = Cantina3.City, IsEighteen = false, Type = MealType.Breakfast, Price = 8.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = products1 });

            Employee Employee1 = new Employee { EmployeeNr = "123456789", Cantina = Cantina1, FirstName = "Jan", LastName = "De Ruiter" };
            _context.Employees.Add(Employee1);

            _context.SaveChanges();
            _logger.LogInformation("Database has been seeded");
        }
    }
}

