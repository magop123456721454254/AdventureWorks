using AdventureWorksAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace AdventureWorksAPI.Services
{
    public class PersonService : IPersonService
    {
        private readonly AdventureWorksContext _context;

        public PersonService(AdventureWorksContext context)
        {
            _context = context;
        }

        #region GET
        public IQueryable<Person> GetPersonsList()
        {
            return _context.DbSetOfPersons.Take(5);
        }

        public IQueryable<Person> GetPersonsList(int amount)
        {
            return _context.DbSetOfPersons.Take(amount);
        }

        public IQueryable<Person?> GetPerson(int businessIdentityId)
        {
            return _context.DbSetOfPersons.Where(p =>
                p.BusinessEntityId == businessIdentityId);
        }

        public IQueryable<Person> FindPersons(string keyword)
        {
            var searchResult = _context.DbSetOfPersons.Where(person =>
                person.PersonType != null && person.PersonType.Contains(keyword) ||
                person.Title != null && person.Title.Contains(keyword) ||
                person.FirstName != null && person.FirstName.Contains(keyword) ||
                person.MiddleName != null && person.MiddleName.Contains(keyword) ||
                person.LastName != null && person.LastName.Contains(keyword) ||
                person.Suffix != null && person.Suffix.Contains(keyword)
            );

            return searchResult;
        }

        public IQueryable<RankedItem> GetRankedOccurances(string propertyName, int listLength, bool orderByDesc)
        {
            if (orderByDesc)
            {
                return _context.DbSetOfPersons.GroupBy(p => p.FirstName)
                    .OrderByDescending(p => p.Count())
                    .Take(listLength)
                    .Select(p => new RankedItem(p.Key ?? string.Empty, p.Count()));
            }
            else
            {
                return _context.DbSetOfPersons.GroupBy(p => p.FirstName)
                    .OrderBy(p => p.Count())
                    .Take(listLength)
                    .Select(p => new RankedItem(p.Key ?? string.Empty, p.Count()));
            }
        }
        #endregion

        #region POST
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


        #endregion
    }
}
