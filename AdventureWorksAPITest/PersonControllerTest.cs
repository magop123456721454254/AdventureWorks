using AdventureWorksAPI.Controllers;
using AdventureWorksAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AdventureWorksAPITest
{
    public class PersonControllerTest
    {
        [Fact]
        public void GetPersons_ReturnsOk_WithPersonList()
        {
            // Arrange
            var mockService = new Mock<PersonService>();
            mockService
                .Setup(s => s.GetPersons(2))
                .Returns(new List<Person>
                {
                    new Person { FirstName = "Alice", LastName = "Smith" },
                    new Person { FirstName = "Bob", LastName = "Lazar" }
                });

            var controller = new PersonController(mockService.Object);

            // Act
            var results = controller.GetPersons();

            // Assert
            var okResult = Assert.IsType<ObjectResult>(results);
            var persons = Assert.IsAssignableFrom<IEnumerable<Person>>(okResult.Value);
            Assert.Equal(2, persons.Count());
        }
    }
}
