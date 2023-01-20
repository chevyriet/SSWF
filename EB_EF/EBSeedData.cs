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
            Cantina Cantina3 = new Cantina { City = City.Breda, Location = "HA", ServesWarm = true };

            Cantina Cantina4 = new Cantina { City = City.Tilburg, Location = "TLA", ServesWarm = true };
            Cantina Cantina5 = new Cantina { City = City.Tilburg, Location = "TLD", ServesWarm = false };
            Cantina Cantina6 = new Cantina { City = City.Tilburg, Location = "THA", ServesWarm = true };

            Cantina Cantina7 = new Cantina { City = City.DenBosch, Location = "DBLA", ServesWarm = true };
            Cantina Cantina8 = new Cantina { City = City.DenBosch, Location = "DBLD", ServesWarm = true };
            Cantina Cantina9 = new Cantina { City = City.DenBosch, Location = "DBHA", ServesWarm = true };

            _context.Cantinas.AddRange(new[]
            {
                Cantina1, 
                Cantina2, 
                Cantina3,
                Cantina4,
                Cantina5,
                Cantina6,
                Cantina7,
                Cantina8,
                Cantina9,
            });

            Product Product1 = new Product { Name = "Spinazie", ContainsAlcohol = false, ImgUrl = "~/images/spinazie-img.jpg" };
            Product Product2 = new Product { Name = "Vissticks", ContainsAlcohol = false, ImgUrl = "~/images/visticks-img.png" };
            Product Product3 = new Product { Name = "Salade", ContainsAlcohol = false, ImgUrl = "~/images/salade-img.jpg" };
            Product Product4 = new Product { Name = "Smoothie", ContainsAlcohol = false, ImgUrl = "~/images/smoothie-img.png" };
            Product Product5 = new Product { Name = "Bier", ContainsAlcohol = true, ImgUrl = "~/images/bier-img.png" };

            Product Product6 = new Product { Name = "Tomatensoep", ContainsAlcohol = false, ImgUrl = "~/images/tomatensoep-img.png" };
            Product Product7 = new Product { Name = "Friet", ContainsAlcohol = false, ImgUrl = "~/images/friet-img.png" };
            Product Product8 = new Product { Name = "Kroket", ContainsAlcohol = false, ImgUrl = "~/images/kroket-img.png" };
            Product Product9 = new Product { Name = "Pizza", ContainsAlcohol = false, ImgUrl = "~/images/pizza-img.jpg" };
            Product Product10 = new Product { Name = "Chips", ContainsAlcohol = false, ImgUrl = "~/images/chips-img.png" };
            Product Product11 = new Product { Name = "Appel", ContainsAlcohol = false, ImgUrl = "~/images/appel-img.png" };

            _context.Products.AddRange(new[]
            {
                Product1,
                Product2,
                Product3,
                Product4,
                Product5,
                Product6,
                Product7,
                Product8,
                Product9,
                Product10,
                Product11,
            });

            Student Student1 = new Student { FirstName = "Chevy", LastName = "Rietveld", City = City.Breda, PhoneNumber = "0651160300", DateOfBirth = DateTime.Now.AddYears(-20), StudentNr = "2188423", EmailAddress = "chevy@gmail.com" };
            Student Student2 = new Student { FirstName = "Frank", LastName = "De Jong", City = City.Tilburg, PhoneNumber = "0612345678", DateOfBirth = DateTime.Now.AddYears(-16), StudentNr = "2190345", EmailAddress = "frank@gmail.com" };

            _context.Students.AddRange(new[]
            {
                Student1,
                Student2,
            });

            //LA 2 zonder alcohol
            MealBox MealBox1 = new MealBox { Name = "Spinazie Pakket", Cantina = Cantina1, City = Cantina1.City, IsEighteen = false, Type = MealType.Groente, IsWarm = true, Price = 7.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };
            MealBox MealBox2 = new MealBox { Name = "Gezond Lunch Pakket", Cantina = Cantina1, City = Cantina1.City, IsEighteen = false, Type = MealType.Lunch, IsWarm = false, Price = 6.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };
            MealBox MealBox6 = new MealBox { Name = "Pizza Pakket", Cantina = Cantina1, City = Cantina1.City, IsEighteen = false, Type = MealType.Snack, IsWarm = true, Price = 7.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };
            MealBox MealBox7 = new MealBox { Name = "Friet Pakket", Cantina = Cantina1, City = Cantina1.City, IsEighteen = false, Type = MealType.Snack, IsWarm = true, Price = 6.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddDays(1), Products = new List<Product>() };

            //TLD 2 zonder alcohol
            MealBox MealBox3 = new MealBox { Name = "Koude Soep Pakket", Cantina = Cantina5, City = Cantina5.City, IsEighteen = false, Type = MealType.Groente, IsWarm = false, Price = 4.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };
            MealBox MealBox4 = new MealBox { Name = "Fruit Pakket", Cantina = Cantina5, City = Cantina5.City, IsEighteen = false, Type = MealType.Gezond, IsWarm = false, Price = 8.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };

            //LA 1 met alcohol
            MealBox MealBox5 = new MealBox { Name = "Borrel Pakket", Cantina = Cantina1, City = Cantina1.City, IsEighteen = true, Type = MealType.Snack, IsWarm = true, Price = 6.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };


            _context.MealBoxes.AddRange(new[]
            {
                MealBox1,
                MealBox2,
                MealBox3,
                MealBox4,
                MealBox5,
                MealBox6,
                MealBox7,
            });

            _context.SaveChanges();

            _context.MealBoxesProducts.AddRange(new[]
            {
                new MealBoxProduct { MealBoxId = MealBox1.Id, ProductId = Product1.Id},
                new MealBoxProduct { MealBoxId = MealBox1.Id, ProductId = Product2.Id},

                new MealBoxProduct { MealBoxId = MealBox2.Id, ProductId = Product3.Id},
                new MealBoxProduct { MealBoxId = MealBox2.Id, ProductId = Product4.Id},

                new MealBoxProduct { MealBoxId = MealBox3.Id, ProductId = Product6.Id},
                new MealBoxProduct { MealBoxId = MealBox3.Id, ProductId = Product4.Id},

                new MealBoxProduct { MealBoxId = MealBox4.Id, ProductId = Product3.Id},
                new MealBoxProduct { MealBoxId = MealBox4.Id, ProductId = Product11.Id},

                new MealBoxProduct { MealBoxId = MealBox5.Id, ProductId = Product5.Id},
                new MealBoxProduct { MealBoxId = MealBox5.Id, ProductId = Product8.Id},
                new MealBoxProduct { MealBoxId = MealBox5.Id, ProductId = Product10.Id},

                new MealBoxProduct { MealBoxId = MealBox6.Id, ProductId = Product9.Id},

                new MealBoxProduct { MealBoxId = MealBox7.Id, ProductId = Product7.Id},
                new MealBoxProduct { MealBoxId = MealBox7.Id, ProductId = Product8.Id},
            });

            Employee Employee1 = new Employee { EmployeeNr = "123456789", Cantina = Cantina1, FirstName = "Jan", LastName = "De Ruiter" };
            Employee Employee2 = new Employee { EmployeeNr = "987654321", Cantina = Cantina5, FirstName = "Bram", LastName = "Boelens" };

            _context.Employees.AddRange(new[]
            {
                Employee1,
                Employee2
            });

            _context.SaveChanges();
            _logger.LogInformation("Database has been seeded");
        }
    }
}

