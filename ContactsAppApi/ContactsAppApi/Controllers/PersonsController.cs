using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsAppApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactsAppApi.Repositories;
using ContactsAppApi.Services;

namespace ContactsAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonService _personService;

        public PersonsController(IPersonRepository personRepository, IPersonService personService)
        {
            _personRepository = personRepository;
            _personService = personService;
        }

        // GET api/persons
        [HttpGet]
        public ActionResult <List<Person>> GetPersons()
        {
            /*var users = new List<Person>
            {
                new Person("James", 45),
                new Person("Lisa", 65)
            };*/
            var persons = _personService.Read();
            return new JsonResult(persons);
        }

        // GET api/persons/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            var person = _personService.Read();
            return new JsonResult(person);
        }

        // POST api/persons
        [HttpPost]
        public ActionResult<Person> Post(Person person)
        {
            var newPerson = _personService.Create(person);
            return new JsonResult(newPerson);
        }

        // PUT api/persons
        [HttpPut("{id}")]
        public ActionResult<Person> Put(int id, Person person)
        {
            var updatePerson = _personService.Update(id, person);
            return new JsonResult(updatePerson);
        }

        // DELETE api/persons
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _personService.Delete(id);
            return new OkResult();
        }
    }
}