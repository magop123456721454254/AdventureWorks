using AdventureWorksAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksAPI.Services
{
    public class PersonService : IPersonService
    {
        private AdventureWorksContext _context;

        public PersonService(AdventureWorksContext context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetPersonsList()
        {
            return [.. _context.DbSetOfPersons.Take(5)];
        }

        public IEnumerable<Person> GetPersonsList(int amount)
        {
            return [.. _context.DbSetOfPersons.Take(amount)];
        }

        public Person? GetPerson(int businessIdentityId)
        {
            var obj = _context.DbSetOfPersons.Find(businessIdentityId);

            return obj ?? null;
        }

        public Person AddPerson(PersonDto personDto)
        {
            var person = MapDtoToPerson(personDto);
            _context.DbSetOfPersons.Add(person);
            _context.SaveChanges();
            return person;
        }

        public bool SoftDeletePerson(int businessIdentityId)
        {
            var person = _context.DbSetOfPersons.Find(businessIdentityId);
            if (person == null)
            {
                return false;
            }
            person.IsActive = false;
            return _context.SaveChanges() > 0;
        }

        public bool ReActivatePerson(int businessIdentityId)
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

        // Updated Person is sent from FE (unchanged parameters are reused)
        public bool EditPerson(int businessIdentityId, PersonDto updatedPersonDto)
        {
            var oldPerson = _context.DbSetOfPersons.Find(businessIdentityId);
            if (oldPerson == null)
            {
                return false;
            }

            Person updatedPerson = MapDtoToPerson(updatedPersonDto);
            updatedPerson.BusinessEntityId = oldPerson.BusinessEntityId;

            _context.Entry(oldPerson).CurrentValues.SetValues(updatedPerson);
            return _context.SaveChanges() > 0;
        }

        private static Person MapDtoToPerson(PersonDto personDto)
        {
            return new Person
            {
                PersonType = personDto.PersonType,
                Title = personDto.Title,
                FirstName = personDto.FirstName,
                MiddleName = personDto.MiddleName,
                LastName = personDto.LastName,
                Suffix = personDto.Suffix,
                EmailPromotion = personDto.EmailPromotion,
                IsActive = true
            };
        }
    }
}
