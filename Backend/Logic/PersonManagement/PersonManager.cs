using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Backend.Data.DatabaseStorage;
using ConsoleClient.CrossCutting;
using CrossCutting.DomainModel;
using FluentValidation.Results;

namespace Backend.Logic.PersonManagement
{
    public class PersonManager : IPersonManager
    {
        private IPersonRepository _personRepository;
        private readonly IConfigurator _config;
        private readonly int AGE_TRESHOLD;
        private readonly IPersonAddLogicValidator _validator;

        public PersonManager(IPersonRepository personRepository, 
            IConfigurator config, 
            IPersonAddLogicValidator validator)
        {
            _personRepository = personRepository;
            _config = config;
            _validator = validator;
            AGE_TRESHOLD = _config.Get("AgeTreshold", 18);
        }

        public void Add(Person person)
        {
            try
            {
                Console.WriteLine("+++ ENTER Add(Person person) +++");
                _personRepository.Insert(person);
                Console.WriteLine("### FINISHED Add(Person person) ###");
            }
            catch (Exception e)
            {
                Console.WriteLine("!!! ERROR Add(Person person) !!!");
                throw;
            }
        }

        public ValidationResult ValidateForAdd(Person person)
        {
            var result = _personRepository.ValidateForInsert(person);
            var logicResults = _validator.Validate(person);
            result.Errors.AddRange(logicResults.Errors);
            return result;
        }

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