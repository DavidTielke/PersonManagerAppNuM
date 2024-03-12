using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Backend.Data.DatabaseStorage;
using ConsoleClient.CrossCutting;
using CrossCutting.DomainModel;

namespace Backend.Logic.PersonManagement
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

        public IQueryable<Person> GetAllAdults()
        {
            var adults = _personRepository
                .GetAllPersons()
                .Where(p => p.Age >= AGE_TRESHOLD);
            return adults;
        }

        public IQueryable<Person> GetAllChildren()
        {
            var children = _personRepository
                .GetAllPersons()
                .Where(p => p.Age < AGE_TRESHOLD);
            return children;
        }

        public IQueryable<Person> GetAll()
        {
            return _personRepository.GetAllPersons();
        }
    }
}