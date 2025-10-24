using AdventureWorksAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetPersons()
        {
            var persons = _personService.GetPersonsList(5);
            return Ok(persons);
        }

        [HttpGet("{amount}")]
        public IActionResult GetPersons(int amount)
        {
            var persons = _personService.GetPersonsList(amount);
            return Ok(persons);
        }
    }
}
