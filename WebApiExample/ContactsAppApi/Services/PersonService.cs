using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Model;
using WebApiExample.Repositories;

namespace WebApiExample.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public List<Person> Read()
        {
            return _personRepository.Read();
        }

        public Person Read(int id)
        {
            return _personRepository.Read(id);
        }

        public Person Create(Person person)
        {
            return _personRepository.Create(person);
        }


        public Person Update(int id, Person person)
        {
            var updatedPerson = _personRepository.Read(id);
            if(updatedPerson == null)
            {
                throw new Exception("Person not found!");
            }
            else
            {
                return _personRepository.Update(person);
            }
        }

        public void Delete(int id)
        {
            _personRepository.Delete(id);
        }
    }
}
