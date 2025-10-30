using AdventureWorksAPI.Models;
namespace AdventureWorksAPI.Services
{
    public interface IPersonService
    {
        public IEnumerable<Person> GetPersonsList();
        public IEnumerable<Person> GetPersonsList(int amount);
        public Person? GetPerson(int businessIdentityId);
        public IEnumerable<Person>? FindPersons(string keyword);
        public Person AddPerson(PersonDto personDto);
        public bool SoftDeletePerson(int businessIdentityId);
        public bool ReActivatePerson(int businessIdentityId);
        public bool EditPerson(int businessIdentityId, PersonDto person);
    }
}
