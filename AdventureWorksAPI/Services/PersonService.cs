using AdventureWorksAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        public virtual Person GetPerson(int businessIdentityId)
        {
            var obj = _context.DbSetOfPersons.Find(businessIdentityId);

            if (obj == null)
            {
                return new Person();
            }
            else
            {
                return obj;
            }
        }

        public virtual Person AddPerson(PersonDto personDto)
        {
            var person = MapDtoToPerson(personDto);
            _context.DbSetOfPersons.Add(person);
            _context.SaveChanges();
            return person;
        }

      

        public virtual bool SoftDeletePerson(int businessIdentityId)
        {
            var person = _context.DbSetOfPersons.Find(businessIdentityId);
            if (person == null)
            {
                return false;
            }
            person.IsActive = false;
            return _context.SaveChanges() > 0;
        }

        public bool ReactivatePerson(int businessIdentityId)
        {
            var person = _context.DbSetOfPersons
                .IgnoreQueryFilters()
                .FirstOrDefault(p => p.BusinessEntityId == businessIdentityId);
            
            if (person == null)
            {
                return false;
            }

            person.IsActive = true;
            return _context.SaveChanges() > 0;
        }

     

        private Person MapDtoToPerson(PersonDto personDto)
        {
            return new Person
            {
                PersonType = personDto.PersonType,
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
                MiddleName = personDto.MiddleName,
                Suffix = personDto.Suffix,
                EmailPromotion = personDto.EmailPromotion,
                IsActive = true
            };
        }
    }
}
