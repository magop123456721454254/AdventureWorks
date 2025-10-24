using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace AdventureWorksAPI.Services
{
    public interface IPersonService
    {
        public IEnumerable<Person> GetPersonsList();

        public IEnumerable<Person> GetPersonsList(int amount);

        public Person GetPerson(int businessIdentityId);
    }
}
