using AdventureWorksAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;
        
        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("{amount}")]
        public IActionResult GetPersons(int amount)
        {
            var persons = _personService.GetPersons(amount);
            return Ok(persons);
        }
    }
}
