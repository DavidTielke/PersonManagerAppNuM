using CrossCutting.DomainModel;

namespace Backend.Data.DatabaseStorage;

public class PersonConverter : IPersonConverter
{
    public string ToCsv(Person person)
    {
        return $"{person.Id},{person.Name},{person.Age}";
    }
}