using AdventureWorksAPI.Models;
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

        [HttpGet("{businessIdentityId}")]
        public IActionResult GetPerson(int businessIdentityId)
        {
            var person = _personService.GetPerson(businessIdentityId);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpGet("{keyword}")]
        public IActionResult FindPersons(string keyword)
        {
            var res = _personService.FindPersons(keyword);
            
            if (res == null)
            {
                return BadRequest();
            }

            return Ok(res);
        }

        [HttpGet]
        public IActionResult GetRankedOccurances(string propertyName, int listLength, bool orderByDesc)
        {
            var res = _personService.GetRankedOccurances(propertyName, listLength, orderByDesc);

            if (res == null)
            {
                return BadRequest();
            }

            return Ok(res);
        }

        [HttpPost]
        public IActionResult AddPerson(PersonDto personDto)
        {
            var res = _personService.AddPerson(personDto);
            return Ok(res);
        }

        [HttpPost("{businessIdentityId}")]
        public IActionResult SoftDeletePerson(int businessIdentityId)
        {
            var res = _personService.SoftDeletePerson(businessIdentityId);
            return Ok(res);
        }

        [HttpPost("{businessIdentityId}")]
        public IActionResult ReactivatePerson(int businessIdentityId)
        {
            var res = _personService.ReActivatePerson(businessIdentityId);
            if (res == false)
            {
                return BadRequest();
            }
            return Ok(res);
        }

        [HttpPost("{businessIdentityId}")]
        public IActionResult EditPerson(int businessIdentityId, PersonDto person)
        {
            var res = _personService.EditPerson(businessIdentityId, person);
            if (res == false)
            {
                return BadRequest();
            }
            return Ok(res);
        }

        
    }
}
