namespace AdventureWorksAPI.Services
{
    public class PersonService : IPersonService
    {
        private AdventureWorksContext _context;

        public PersonService(AdventureWorksContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<Person> GetPersonsList()
        {
            return [.. _context.DbSetOfPersons.Take(5)];
        }

        public virtual IEnumerable<Person> GetPersonsList(int amount)
        {
            return [.. _context.DbSetOfPersons.Take(amount)];
        }

        public virtual Person GetPerson(int businessEntityId)
        {

            var obj = _context.DbSetOfPersons.Find(businessEntityId);

            if (obj == null) { 
                return new Person(); 
            } else { 
                return obj; 
            }

        }

        public virtual bool AddPerson(Person person) {
            _context.DbSetOfPersons.Add(person);
            return _context.SaveChanges() > 0;

        }
    }
}
