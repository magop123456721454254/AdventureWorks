namespace AdventureWorksAPI.Services
{
    public class PersonService
    {
        private AdventureWorksContext _context;

        public PersonService(AdventureWorksContext context) {
            _context = context;
        }

        public IEnumerable<Person> GetPersons(int amount) {
            if(amount < 0)
            {
                return Enumerable.Empty<Person>();
            }
            return [.. _context.DbSetOfPersons.Take(amount)];
        }
    }
}
