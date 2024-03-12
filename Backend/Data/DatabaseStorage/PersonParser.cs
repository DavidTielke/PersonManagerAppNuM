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
        public List<Person> ParseFromCSV(IEnumerable<string> lines)
        {
            ArgumentNullException.ThrowIfNull(lines);

            var persons = lines
                .Select(l => l.Split(","))
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