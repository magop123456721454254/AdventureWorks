using AdventureWorksAPI.Models;
namespace AdventureWorksAPI.Services
{
    public interface IPersonService
    {
        public IEnumerable<Person> GetPersonsList();
        public IEnumerable<Person> GetPersonsList(int amount);
        public Person GetPerson(int businessIdentityId);
        public Person AddPerson(PersonDto personDto);
        public bool SoftDeletePerson(int businessIdentityId);
        public bool ReactivatePerson(int businessIdentityId);

    }
}
