using AdventureWorksAPI.Controllers;
using AdventureWorksAPI.Models;
using AdventureWorksAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace AdventureWorksAPITest
{
    public class PersonControllerTest
    {
        [Fact]
        public void GetPersons_ReturnsOkResult()
        {
            // Arrange
            var mockService = new Mock<IPersonService>();
            mockService.Setup(s => s.GetPerson(50)).Returns(new Person { FirstName = "Alice", BusinessEntityId = 50 });
            var controller = new PersonController(mockService.Object);
            // Act
            var results = controller.GetPersonsList();

            // Assert
            var okRes = Assert.IsType<OkObjectResult>(results);
        }

        [Fact]
        public void GetPersons_WithParameter_ReturnsOkResult()
        {
            // Arrange
            var mockService = new Mock<IPersonService>();
            var controller = new PersonController(mockService.Object);

            // Act
            var results = controller.GetPersonsList(11);

            // Assert
            var okRes = Assert.IsType<OkObjectResult>(results);
        }

        [Fact]
        public void GetPerson_WithSpecificId_ReturnsOk()
        {
            // Arrange
            var mockService = new Mock<IPersonService>();
            var controller = new PersonController(mockService.Object);

            // Act
            var results = controller.GetPerson(50);

            // Assert
            Assert.IsType<OkObjectResult>(results);
        }

        [Fact]
        public void GetPerson_WithBadId_ReturnsNotFound()
        {
            // Arrange
            var mockService = new Mock<IPersonService>();
            mockService.Setup(s => s.GetPerson(50)).Returns(new Person { FirstName = "Alice", BusinessEntityId = 50 });
            var controller = new PersonController(mockService.Object);

            // Act
            var results = controller.GetPerson(51);

            // Assert
            Assert.IsType<NotFoundResult>(results);
        }



        [Fact]
        public void GetPerson_WithSpecificId_HasCorrectValues()
        {
            // Arrange
            var mockService = new Mock<IPersonService>();
            mockService.Setup(s => s.GetPerson(50)).
                Returns(
                new Person
                {
                    BusinessEntityId = 50,
                    PersonType = "EM",
                    Title = null,
                    FirstName = "Alice",
                    MiddleName = "M",
                    LastName = "Higa",
                    Suffix = null,
                    EmailPromotion = 0
                });

            var controller = new PersonController(mockService.Object);

            // Act
            var result = controller.GetPerson(50);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var person = Assert.IsType<Person>(okResult.Value);

            Assert.Equal("Alice", person.FirstName);
            Assert.Equal("Higa", person.LastName);
            Assert.Equal("M", person.MiddleName);
            Assert.Equal("EM", person.PersonType);
        }

        [Fact]
        public void AddPerson_AddsPerson()
        {
            var options = new DbContextOptionsBuilder<AdventureWorksContext>()
                .UseInMemoryDatabase(databaseName: "AddPersonTestDb")
                .Options;

            using var context = new AdventureWorksContext(options);
            var service = new PersonService(context);

            var newPerson = new PersonDto { FirstName = "Test", LastName = "Tester", IsActive = true }; 
            
            var result = service.AddPerson(newPerson);

            Assert.IsType<Person>(result);
            Assert.Equal(1, context.DbSetOfPersons.Count());
            Assert.Equal("Test", context.DbSetOfPersons.First().FirstName);
        }

        [Fact]
        public void SoftDeletePerson_Should_Set_IsActive_False()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AdventureWorksContext>()
                .UseInMemoryDatabase(databaseName: "SoftDeleteTestDb")
                .Options;

            using var context = new AdventureWorksContext(options);

            // Seed a person
            var person = new Person { BusinessEntityId = 1006, FirstName = "Alice", IsActive = true };
            context.DbSetOfPersons.Add(person);
            context.SaveChanges();

            var service = new PersonService(context);

            // Act
            var result = service.SoftDeletePerson(1006);

            // Assert
            Assert.True(result);
            var updatedPerson = context.DbSetOfPersons
                .IgnoreQueryFilters()
                .First(p => p.BusinessEntityId == 1006);

            Assert.False(updatedPerson.IsActive);
        }

        [Fact]
        public void ReactivatePerson_ReactivatesPerson()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AdventureWorksContext>()
                .UseInMemoryDatabase(databaseName: "SoftDeleteTestDb")
                .Options;

            using var context = new AdventureWorksContext(options);

            // Seed a person
            var person = new Person { BusinessEntityId = 1005, FirstName = "Alice", IsActive = true };
            context.DbSetOfPersons.Add(person);
            context.SaveChanges();

            var service = new PersonService(context);

            // Act
            var result = service.SoftDeletePerson(1005);

            // Assert
            Assert.True(result);
            var updatedPerson = context.DbSetOfPersons
                .IgnoreQueryFilters()
                .First(p => p.BusinessEntityId == 1005);

            Assert.False(updatedPerson.IsActive);
            
            result = service.ReActivatePerson(1005);
            Assert.True(updatedPerson.IsActive);            
        }
    }
}
