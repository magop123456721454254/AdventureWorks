using AdventureWorksAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksAPI.Controllers
{

    // TEST COMMENT FOR FIRST PR

    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;
        
        public PersonController(PersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("{amount?}")]
        public IActionResult GetPersons(int? amount)
        {
            int take = amount ?? 5;
            var persons = _personService.GetPersons(take);
            return Ok(persons);
        }
    }
}
