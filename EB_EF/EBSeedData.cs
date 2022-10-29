using Domain;
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
            _context.Cantinas.AddRange(new[]
            {
                Cantina1, 
                Cantina2, 
                Cantina3
            });

            Product Product1 = new Product { Name = "Spinazie", ContainsAlcohol = false, ImgUrl = "~/images/spinazie-img.jpg" };
            Product Product2 = new Product { Name = "Vissticks", ContainsAlcohol = false, ImgUrl = "~/images/visticks-img.png" };
            Product Product3 = new Product { Name = "Salade", ContainsAlcohol = false, ImgUrl = "~/images/salade-img.jpg" };
            Product Product4 = new Product { Name = "Smoothie", ContainsAlcohol = false, ImgUrl = "~/images/smoothie-img.png" };
            Product Product5 = new Product { Name = "Bier", ContainsAlcohol = true, ImgUrl = "~/images/bier-img.png" };

            _context.Products.AddRange(new[]
            {
                Product1,
                Product2,
                Product3,
                Product4,
                Product5,
            });

            Student Student1 = new Student { FirstName = "Chevy", LastName = "Rietveld", City = City.Breda, PhoneNumber = "0651160300", DateOfBirth = DateTime.Now.AddYears(-18), StudentNr = "2188423", EmailAddress = "chevyriet040104@gmail.com" };
            _context.Students.Add(Student1);

            MealBox MealBox1 = new MealBox { Name = "Spinazie Pakket", Cantina = Cantina1, City = Cantina1.City, IsEighteen = false, Type = MealType.AvondEten, IsWarm = true, Price = 7.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };
            MealBox MealBox2 = new MealBox { Name = "Gezond Lunch Pakket", Cantina = Cantina1, City = Cantina1.City, IsEighteen = false, Type = MealType.Lunch, IsWarm = false, Price = 6.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };
            MealBox MealBox3 = new MealBox { Name = "Brood Pakket", Cantina = Cantina2, City = Cantina2.City, IsEighteen = false, Type = MealType.Brood, IsWarm = false, Price = 4.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };
            MealBox MealBox4 = new MealBox { Name = "Vettig Ontbijt Pakket", Cantina = Cantina3, City = Cantina3.City, IsEighteen = true, Type = MealType.Ontbijt, IsWarm = false, Price = 8.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };
            MealBox MealBox5 = new MealBox { Name = "Snack Pakket", Cantina = Cantina3, City = Cantina3.City, IsEighteen = false, Type = MealType.AvondEten, IsWarm = false, Price = 7.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };
            MealBox MealBox6 = new MealBox { Name = "Borrel Pakket", Cantina = Cantina2, City = Cantina2.City, IsEighteen = true, Type = MealType.Lunch, IsWarm = false, Price = 6.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };
            MealBox MealBox7 = new MealBox { Name = "Soep Pakket", Cantina = Cantina1, City = Cantina1.City, IsEighteen = false, Type = MealType.Brood, IsWarm = false, Price = 4.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };
            MealBox MealBox8 = new MealBox { Name = "Indonesisch Pakket", Cantina = Cantina1, City = Cantina1.City, IsEighteen = true, Type = MealType.Brood, IsWarm = false, Price = 4.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };

            _context.MealBoxes.AddRange(new[]
            {
                MealBox1, MealBox2, MealBox3, MealBox4, MealBox5, MealBox6, MealBox7, MealBox8
            });

            _context.SaveChanges();

            _context.MealBoxesProducts.AddRange(new[]
            {
                new MealBoxProduct { MealBoxId = MealBox1.Id, ProductId = Product1.Id},
                new MealBoxProduct { MealBoxId = MealBox1.Id, ProductId = Product2.Id},
                new MealBoxProduct { MealBoxId = MealBox2.Id, ProductId = Product3.Id},
                new MealBoxProduct { MealBoxId = MealBox2.Id, ProductId = Product4.Id},
                new MealBoxProduct { MealBoxId = MealBox3.Id, ProductId = Product1.Id},
                new MealBoxProduct { MealBoxId = MealBox3.Id, ProductId = Product2.Id},
                new MealBoxProduct { MealBoxId = MealBox4.Id, ProductId = Product3.Id},
                new MealBoxProduct { MealBoxId = MealBox4.Id, ProductId = Product4.Id},

                new MealBoxProduct { MealBoxId = MealBox5.Id, ProductId = Product1.Id},
                new MealBoxProduct { MealBoxId = MealBox5.Id, ProductId = Product2.Id},
                new MealBoxProduct { MealBoxId = MealBox6.Id, ProductId = Product3.Id},
                new MealBoxProduct { MealBoxId = MealBox6.Id, ProductId = Product4.Id},
                new MealBoxProduct { MealBoxId = MealBox7.Id, ProductId = Product1.Id},
                new MealBoxProduct { MealBoxId = MealBox7.Id, ProductId = Product2.Id},
                new MealBoxProduct { MealBoxId = MealBox8.Id, ProductId = Product3.Id},
                new MealBoxProduct { MealBoxId = MealBox8.Id, ProductId = Product4.Id},
            });

            Employee Employee1 = new Employee { EmployeeNr = "123456789", Cantina = Cantina1, FirstName = "Jan", LastName = "De Ruiter" };
            _context.Employees.Add(Employee1);

            _context.SaveChanges();
            _logger.LogInformation("Database has been seeded");
        }
    }
}

