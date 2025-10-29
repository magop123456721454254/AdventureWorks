using AdventureWorksAPI.Models;
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
                    new Person { FirstName = "Bob", LastName = "Lazar" },sssssssss
                    new Person { FirstName = "Stan", LastName = "Carley" }
                };
        }

        public Person GetPerson(int businessIdentityId)
        {
            return new Person
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
        }

        public Person AddPerson(PersonDto person)
        {
            throw new NotImplementedException();
        }

        public bool SoftDeletePerson(int businessIdentityId)
        {
            throw new NotImplementedException();
        }

        public bool ReActivatePerson(int businessIdentityId)
        {
            throw new NotImplementedException();
        }
        
        public bool EditPerson(int businessIdentityId, PersonDto updatedPerson)
        {
            throw new NotImplementedException();
        }
    }
}