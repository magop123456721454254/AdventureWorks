using AdventureWorksAPI.Controllers;
using AdventureWorksAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AdventureWorksAPITest
{
    public class PersonControllerTest
    {
        [Fact]
        public void GetPersons_ReturnsOkResult()
        {
            // Arrange
            var mockService = new Mock<MockedPersonService>();
            var controller = new PersonController(mockService.Object);

            // Act
            var results = controller.GetPersonsList();

            // Assert
            var okRes = Assert.IsType<OkObjectResult>(results);

            //var list = Assert.IsType<IActionResult>(results, exactMatch: false);
            //bool ok = results.ExecuteResultAsync();

            //var person = list.First();
            //Assert.Equal("Alice", person.FirstName);

            //var okResult = Assert.IsType<ObjectResult>(results);
            //var persons = Assert.IsAssignableFrom<IEnumerable<Person>>(okResult.Value);
            //Assert.Equal(2, persons.Count());
        }

        [Fact]
        public void GetPersons_WithParameter_ReturnsOkResult()
        {
            // Arrange
            var mockService = new Mock<MockedPersonService>();
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
            var mockService = new Mock<MockedPersonService>();
            var controller = new PersonController(mockService.Object);

            // Act
            var results = controller.GetPerson(50);

            // Assert
            var okRes = Assert.IsType<OkObjectResult>(results);
        }

        [Fact]
        public void GetPerson_WithSpecificId_HasCorrectValues()
        {
            // Arrange
            var mockService = new Mock<MockedPersonService>();
            var controller = new PersonController(mockService.Object);

            Person matchPerson = new Person
            {
                BusinessEntityId = 50,
                PersonType = "EM",
                Title = null,
                FirstName = "Sidney",
                MiddleName = "M",
                LastName = "Higa",
                Suffix = null,
                EmailPromotion = 0
            };

            // Act
            var result = controller.GetPerson(50);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var person = Assert.IsType<Person>(okResult.Value);

            Assert.Equal(person.FirstName, matchPerson.FirstName);
            Assert.Equal(person.LastName, matchPerson.LastName);
            Assert.Equal(person.MiddleName, matchPerson.MiddleName);
            Assert.Equal(person.Title, matchPerson.Title);
            Assert.Equal(person.PersonType, matchPerson.PersonType);

        }
    }
}
