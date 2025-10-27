using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public virtual Person GetPerson(int id)
        {
            var obj = _context.DbSetOfPersons.Find(id);

            if (obj == null)
            {
                return new Person();
            }
            else
            {
                return obj;
            }
        }

        public virtual bool AddPerson(Person person)
        {
            _context.DbSetOfPersons.Add(person);
            return _context.SaveChanges() > 0;
        }

        public virtual bool SoftDeletePerson(int id)
        {
            var person = _context.DbSetOfPersons.Find(id);
            if (person == null)
            {
                return false;
            }
            person.IsActive = false;
            return _context.SaveChanges() > 0;
        }
    }
}
