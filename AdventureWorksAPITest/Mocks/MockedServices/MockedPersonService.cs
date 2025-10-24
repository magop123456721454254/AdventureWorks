using AdventureWorksAPI.Services;

namespace AdventureWorksAPITest
{
    public class MockedPersonService : IPersonService
    {
        public MockedPersonService() { }

        public virtual IEnumerable<Person> GetPersonsList()
        {
            return new List<Person>
                {
                    new Person { FirstName = "Alice", LastName = "Smith" },
                    new Person { FirstName = "Bob", LastName = "Lazar" }
                };
        }

        public virtual IEnumerable<Person> GetPersonsList(int amount)
        {
            return new List<Person>
                {
                    new Person { FirstName = "Alice", LastName = "Smith" },
                    new Person { FirstName = "Bob", LastName = "Lazar" },
                    new Person { FirstName = "Stan", LastName = "Carley" }
                };
        }
    }
}