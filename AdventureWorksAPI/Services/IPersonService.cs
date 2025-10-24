using System.Runtime.InteropServices;

namespace AdventureWorksAPI.Services
{
    public interface IPersonService
    {
        public IEnumerable<Person> GetPersons();

        public IEnumerable<Person> GetPersons(int amount);
    }
}
