using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using ConsoleClient.CrossCutting;
using ConsoleClient.Data;

namespace ConsoleClient.Logic
{
    public class PersonManager : IPersonManager
    {
        private IPersonRepository _personRepository;
        private readonly IConfigurator _config;
        private readonly int AGE_TRESHOLD;

        public PersonManager(IPersonRepository personRepository, IConfigurator config)
        {
            _personRepository = personRepository;
            _config = config;
            AGE_TRESHOLD = _config.Get("AgeTreshold", 18);
        }

        //public void Add(Person person)
        //{
        //    _personRepository.Insert(person);
        //}

        public List<Person> GetAllAdults()
        {
            var adults = _personRepository
                .GetAllPersons()
                .Where(p => p.Age >= AGE_TRESHOLD)
                .ToList();
            return adults;
        }

        public List<Person> GetAllChildren()
        {
            var children = _personRepository
                .GetAllPersons()
                .Where(p => p.Age < AGE_TRESHOLD)
                .ToList();
            return children;
        }
    }
}