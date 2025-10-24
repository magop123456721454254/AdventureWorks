using AdventureWorksAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetPersonsList()
        {
            var personsList = _personService.GetPersonsList(5);
            return Ok(personsList);
        }

        [HttpGet("{amount}")]
        public IActionResult GetPersonsList(int amount)
        {
            var personsList = _personService.GetPersonsList(amount);
            return Ok(personsList);
        }

        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            var Person = _personService.GetPerson(id);
            return Ok(Person);
        }
    }
}
