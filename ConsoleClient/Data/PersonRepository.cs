using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleClient.Data
{
    public class PersonRepository : IPersonRepository
    {
        private IFileStorer _fileStorer;
        private IPersonParser _personParser;
        private readonly IPersonConverter _converter;
        private readonly IPersonDataValidator _validator;

        public PersonRepository(IFileStorer fileStorer,
            IPersonParser personParser,
            IPersonConverter converter, 
            IPersonDataValidator validator)
        {
            _fileStorer = fileStorer;
            _personParser = personParser;
            _converter = converter;
            _validator = validator;
        }

        //public void Insert(Person person)
        //{
        //    _validator.AssertForInsert(person);

        //    var allLines = _fileStorer.LoadAllLines("data.csv");

        //    var allPersons = _personParser.ParseFromCSV(allLines);
        //    var nextIndex = allPersons.Max(p => p.Id) + 1;
        //    person.Id = nextIndex;

        //    var csvData = _converter.ToCsv(person);
        //    allLines.Add(csvData);
        //    _fileStorer.WriteAllLines("data.csv", allLines);
        //}

        public List<Person> GetAllPersons()
        {
            var lines = _fileStorer.LoadAllLines("data.csv");
            var persons = _personParser.ParseFromCSV(lines);
            return persons;
        }
    }
}