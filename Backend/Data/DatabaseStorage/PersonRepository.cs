using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Data.FileStorage;
using ConsoleClient.CrossCutting;
using CrossCutting.DomainModel;

namespace Backend.Data.DatabaseStorage
{
    public class PersonRepository : IPersonRepository
    {
        private IFileStorer _fileStorer;
        private IPersonParser _personParser;
        private readonly IPersonConverter _converter;
        private readonly IPersonDataValidator _validator;
        private readonly IConfigurator _config;

        public PersonRepository(IFileStorer fileStorer,
            IPersonParser personParser,
            IPersonConverter converter,
            IPersonDataValidator validator,
            IConfigurator config)
        {
            _fileStorer = fileStorer;
            _personParser = personParser;
            _converter = converter;
            _validator = validator;
            _config = config;
        }

        public string PATH => _config.Get("DataPath", "data.csv");

        public void Insert(Person person)
        {
            //_validator.AssertForInsert(person);

            var allLines = _fileStorer.LoadAllLines(PATH);

            var allPersons = _personParser.ParseFromCSV(allLines);
            var nextIndex = allPersons.Max(p => p.Id) + 1;
            person.Id = nextIndex;

            var csvData = _converter.ToCsv(person);
            allLines.Add(csvData);
            _fileStorer.WriteAllLines("data.csv", allLines);
        }

        public IQueryable<Person> GetAllPersons()
        {
            var lines = _fileStorer.LoadAllLines(PATH);
            var persons = _personParser.ParseFromCSV(lines);
            return persons.AsQueryable();
        }
    }
}