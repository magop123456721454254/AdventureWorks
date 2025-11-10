using AdventureWorksAPI.Models;
namespace AdventureWorksAPI.Services
{
    public interface IPersonService
    {
        // GET
        public IQueryable<Person> GetPersonsList();
        public IQueryable<Person> GetPersonsList(int amount);
        public IQueryable<Person?> GetPerson(int businessIdentityId);
        public IQueryable<Person> FindPersons(string keyword);
        public IQueryable<RankedItem> GetRankedOccurances(string propertyName, int listLength, bool orderByDesc);

        // POST
        public Person AddPerson(PersonDto personDto);
        public bool SoftDeletePerson(int businessIdentityId);
        public bool ReActivatePerson(int businessIdentityId);
        public bool EditPerson(int businessIdentityId, PersonDto person);
    }
}
