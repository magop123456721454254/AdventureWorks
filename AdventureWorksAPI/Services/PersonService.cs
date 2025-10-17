namespace AdventureWorksAPI.Services
{
    public class PersonService
    {
        private AdventureWorksContext _context;

        public PersonService(AdventureWorksContext context) {
            _context = context;
        }

        public IEnumerable<Person> GetPersons(int amount) {
            return [.. _context.DbSetOfPersons.Take(amount)];
        }
    }
}
