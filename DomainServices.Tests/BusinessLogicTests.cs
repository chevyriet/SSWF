using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DomainServices;
using DomainServices.Rules;
using Moq;
using Xunit;

namespace DomainServices.Tests
{
    public class BusinessLogicTests
    {
        [Fact]
        public void DoesMealBoxAndStudentExistShouldReturnFalseWhenStudentIsNull()
        {
            //Arrange
            var MealBox = new MealBox { Name = "Test Pakket", IsEighteen = false, Type = MealType.Groente, IsWarm = true, Price = 7.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };
            var Student = new Student();
            Student = null;
            var StudentCheckServiceMock = new Mock<StudentCheckService>();

            var sut = new MealBoxReservationService(StudentCheckServiceMock.Object);

            //Act
            var result = sut.DoesMealBoxAndStudentExist(Student, MealBox);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void DoesMealBoxAndStudentExistShouldReturnFalseWhenMealBoxIsNull()
        {
            //Arrange
            var MealBox = new MealBox();
            MealBox = null;
            var Student = new Student { FirstName = "Chevy", LastName = "Rietveld", City = City.Breda, PhoneNumber = "0651160300", DateOfBirth = DateTime.Now.AddYears(-20), StudentNr = "2188423", EmailAddress = "chevy@gmail.com" };
            var StudentCheckServiceMock = new Mock<StudentCheckService>();

            var sut = new MealBoxReservationService(StudentCheckServiceMock.Object);

            //Act
            var result = sut.DoesMealBoxAndStudentExist(Student, MealBox);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void DoesMealBoxAndStudentExistShouldReturnFalseWhenMealBoxAndStudentIsNull()
        {
            //Arrange
            var MealBox = new MealBox();
            MealBox = null;
            var Student = new Student();
            Student = null;

            var StudentCheckServiceMock = new Mock<StudentCheckService>();

            var sut = new MealBoxReservationService(StudentCheckServiceMock.Object);

            //Act
            var result = sut.DoesMealBoxAndStudentExist(Student, MealBox);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void DoesMealBoxAndStudentExistShouldReturnTrueWhenMealBoxAndStudentArentNull()
        {
            //Arrange
            var MealBox = new MealBox { Name = "Test Pakket", IsEighteen = false, Type = MealType.Groente, IsWarm = true, Price = 7.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };
            var Student = new Student { FirstName = "Chevy", LastName = "Rietveld", City = City.Breda, PhoneNumber = "0651160300", DateOfBirth = DateTime.Now.AddYears(-20), StudentNr = "2188423", EmailAddress = "chevy@gmail.com" };
            var StudentCheckServiceMock = new Mock<StudentCheckService>();

            var sut = new MealBoxReservationService(StudentCheckServiceMock.Object);

            //Act
            var result = sut.DoesMealBoxAndStudentExist(Student, MealBox);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void HasMealBoxAlreadyBeenReservedShouldReturnFalseIfItHasntBeenReservedYet()
        {
            //Arrange
            var MealBox = new MealBox { Name = "Test Pakket", IsEighteen = false, Type = MealType.Groente, IsWarm = true, Price = 7.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };
            var StudentCheckServiceMock = new Mock<StudentCheckService>();

            var sut = new MealBoxReservationService(StudentCheckServiceMock.Object);

            //Act
            var result = sut.HasMealBoxAlreadyBeenReserved(MealBox);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void HasMealBoxAlreadyBeenReservedShouldReturnTrueIfItHasBeenReserved()
        {
            //Arrange
            var MealBox = new MealBox { Name = "Test Pakket", IsEighteen = false, Type = MealType.Groente, IsWarm = true, Price = 7.99, StudentId = 1, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };
            var StudentCheckServiceMock = new Mock<StudentCheckService>();

            var sut = new MealBoxReservationService(StudentCheckServiceMock.Object);

            //Act
            var result = sut.HasMealBoxAlreadyBeenReserved(MealBox);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsStudentOfAgeShouldReturnTrueIfStudentIsEighteenOnMealBoxPickupTime()
        {
            //Arrange
            var MealBox = new MealBox { Name = "Test Pakket", IsEighteen = false, Type = MealType.Groente, IsWarm = true, Price = 7.99, StudentId = 1, PickupFromTime = DateTime.Now.AddHours(-10), PickupUntilTime = DateTime.Now, Products = new List<Product>() };
            var Student = new Student { FirstName = "Chevy", LastName = "Rietveld", City = City.Breda, PhoneNumber = "0651160300", DateOfBirth = DateTime.Now.AddYears(-18), StudentNr = "2188423", EmailAddress = "chevy@gmail.com" };

            var sut = new StudentCheckService();

            //Act
            var result = sut.IsStudentOfAge(Student, MealBox);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsStudentOfAgeShouldReturnTrueIfStudentIsNineteenOnMealBoxPickupTime()
        {
            //Arrange
            var MealBox = new MealBox { Name = "Test Pakket", IsEighteen = false, Type = MealType.Groente, IsWarm = true, Price = 7.99, StudentId = 1, PickupFromTime = DateTime.Now.AddHours(-10), PickupUntilTime = DateTime.Now, Products = new List<Product>() };
            var Student = new Student { FirstName = "Chevy", LastName = "Rietveld", City = City.Breda, PhoneNumber = "0651160300", DateOfBirth = DateTime.Now.AddYears(-19), StudentNr = "2188423", EmailAddress = "chevy@gmail.com" };

            var sut = new StudentCheckService();

            //Act
            var result = sut.IsStudentOfAge(Student, MealBox);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsStudentOfAgeShouldReturnTrueIfStudentIsNinetyOnMealBoxPickupTime()
        {
            //Arrange
            var MealBox = new MealBox { Name = "Test Pakket", IsEighteen = false, Type = MealType.Groente, IsWarm = true, Price = 7.99, StudentId = 1, PickupFromTime = DateTime.Now.AddHours(-10), PickupUntilTime = DateTime.Now, Products = new List<Product>() };
            var Student = new Student { FirstName = "Chevy", LastName = "Rietveld", City = City.Breda, PhoneNumber = "0651160300", DateOfBirth = DateTime.Now.AddYears(-90), StudentNr = "2188423", EmailAddress = "chevy@gmail.com" };

            var sut = new StudentCheckService();

            //Act
            var result = sut.IsStudentOfAge(Student, MealBox);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsStudentOfAgeShouldReturnFalseIfStudentIsSeventeenOnMealBoxPickupTime()
        {
            //Arrange
            var MealBox = new MealBox { Name = "Test Pakket", IsEighteen = false, Type = MealType.Groente, IsWarm = true, Price = 7.99, StudentId = 1, PickupFromTime = DateTime.Now.AddHours(-10), PickupUntilTime = DateTime.Now, Products = new List<Product>() };
            var Student = new Student { FirstName = "Chevy", LastName = "Rietveld", City = City.Breda, PhoneNumber = "0651160300", DateOfBirth = DateTime.Now.AddYears(-17), StudentNr = "2188423", EmailAddress = "chevy@gmail.com" };

            var sut = new StudentCheckService();

            //Act
            var result = sut.IsStudentOfAge(Student, MealBox);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsStudentOfAgeShouldReturnFalseIfStudentIsOneOnMealBoxPickupTime()
        {
            //Arrange
            var MealBox = new MealBox { Name = "Test Pakket", IsEighteen = false, Type = MealType.Groente, IsWarm = true, Price = 7.99, StudentId = 1, PickupFromTime = DateTime.Now.AddHours(-10), PickupUntilTime = DateTime.Now, Products = new List<Product>() };
            var Student = new Student { FirstName = "Chevy", LastName = "Rietveld", City = City.Breda, PhoneNumber = "0651160300", DateOfBirth = DateTime.Now.AddYears(-1), StudentNr = "2188423", EmailAddress = "chevy@gmail.com" };

            var sut = new StudentCheckService();

            //Act
            var result = sut.IsStudentOfAge(Student, MealBox);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsStudentAllowedToReservateMealBoxShouldReturnFalseIfMealBoxOrStudentIsNull()
        {
            //Arrange
            var MealBox = new MealBox();
            MealBox = null;
            var Student = new Student { FirstName = "Chevy", LastName = "Rietveld", City = City.Breda, PhoneNumber = "0651160300", DateOfBirth = DateTime.Now.AddYears(-20), StudentNr = "2188423", EmailAddress = "chevy@gmail.com" };
            var StudentCheckServiceMock = new Mock<StudentCheckService>();

            var sut = new MealBoxReservationService(StudentCheckServiceMock.Object);

            //Act
            var result = sut.IsStudentAllowedToReservateMealBox(Student, MealBox);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsStudentAllowedToReservateMealBoxShouldReturnFalseIfMealBoxHasAlreadyBeenReserved()
        {
            //Arrange
            var Student = new Student { Id = 1, FirstName = "Chevy", LastName = "Rietveld", City = City.Breda, PhoneNumber = "0651160300", DateOfBirth = DateTime.Now.AddYears(-20), StudentNr = "2188423", EmailAddress = "chevy@gmail.com" };
            var MealBox = new MealBox { Name = "Test Pakket", IsEighteen = false, Type = MealType.Groente, IsWarm = true, Price = 7.99, StudentId = 4, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };
            var StudentCheckServiceMock = new Mock<StudentCheckService>();

            var sut = new MealBoxReservationService(StudentCheckServiceMock.Object);

            //Act
            var result = sut.IsStudentAllowedToReservateMealBox(Student, MealBox);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsStudentAllowedToReservateMealBoxShouldReturnFalseIfMealBoxContainsAlcoholAndStudentIsNotOfAge()
        {
            //Arrange
            var Student = new Student { FirstName = "Chevy", LastName = "Rietveld", City = City.Breda, PhoneNumber = "0651160300", DateOfBirth = DateTime.Now.AddYears(-10), StudentNr = "2188423", EmailAddress = "chevy@gmail.com" };
            var MealBox = new MealBox { Name = "Test Pakket", IsEighteen = true, Type = MealType.Groente, IsWarm = true, Price = 7.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };
            var StudentCheckServiceMock = new Mock<StudentCheckService>();

            var sut = new MealBoxReservationService(StudentCheckServiceMock.Object);

            //Act
            var result = sut.IsStudentAllowedToReservateMealBox(Student, MealBox);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void IsStudentAllowedToReservateMealBoxShouldReturnTrueIfMealBoxContainsAlcoholAndStudentIsOfAge()
        {
            //Arrange
            var Student = new Student { FirstName = "Chevy", LastName = "Rietveld", City = City.Breda, PhoneNumber = "0651160300", DateOfBirth = DateTime.Now.AddYears(-20), StudentNr = "2188423", EmailAddress = "chevy@gmail.com" };
            var MealBox = new MealBox { Name = "Test Pakket", IsEighteen = true, Type = MealType.Groente, IsWarm = true, Price = 7.99, PickupFromTime = DateTime.Now, PickupUntilTime = DateTime.Now.AddHours(10), Products = new List<Product>() };
            var StudentCheckServiceMock = new Mock<StudentCheckService>();

            var sut = new MealBoxReservationService(StudentCheckServiceMock.Object);

            //Act
            var result = sut.IsStudentAllowedToReservateMealBox(Student, MealBox);

            //Assert
            Assert.True(result);
        }
    }
}
