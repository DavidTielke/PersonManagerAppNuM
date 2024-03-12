using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleClient.CrossCutting;
using CrossCutting.DomainModel;

namespace Backend.Data.DatabaseStorage
{
    public class PersonParser : IPersonParser
    {
        private readonly IConfigurator _config;
        private readonly string SEPARATOR;

        public PersonParser(IConfigurator config)
        {
            _config = config;
            SEPARATOR = config.Get("CsvSeparator", ",");
        }

        public List<Person> ParseFromCSV(IEnumerable<string> lines)
        {
            ArgumentNullException.ThrowIfNull(lines);

            var persons = lines
                .Select(l => l.Split(SEPARATOR))
                .Select(p => new Person
                {
                    Id = int.Parse(p[0]),
                    Name = p[1],
                    Age = int.Parse(p[2])
                }).ToList();
            return persons;
        }
    }
}