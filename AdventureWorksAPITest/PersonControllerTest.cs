using AdventureWorksAPI.Controllers;
using AdventureWorksAPI.Services;
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
            var results = controller.GetPersons();

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
            var results = controller.GetPersons(11);

            // Assert
            var okRes = Assert.IsType<OkObjectResult>(results);
        }
    }
}
