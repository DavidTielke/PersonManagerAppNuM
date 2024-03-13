using Backend.Logic.PersonManagement;
using CrossCutting.DomainModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ServiceClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonManager _personManager;

        public PersonController(IPersonManager personManager)
        {
            _personManager = personManager;
        }

        [HttpGet]
        [EnableQuery()]
        [Route("/Persons")]
        public IQueryable<Person> GetAll()
        {
            return _personManager.GetAll();
        }

        [HttpGet]
        [Route("/Persons/Adults")]
        public IQueryable<Person> GetAllAdults()
        {
            return _personManager.GetAllAdults().OrderBy(p => p.Id);
        }

        [HttpGet]
        [Route("/Persons/Children")]
        public IQueryable<Person> GetAllChildren()
        {
            return _personManager.GetAllChildren().OrderBy(p => p.Name);
        }

        [HttpPost]
        [Route("/Persons")]

        public IActionResult AddPerson(Person person)
        {
            _personManager.Add(person);
            return Created("", person);
        }
    }
}
