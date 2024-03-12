using CrossCutting.DomainModel;

namespace Backend.Data.DatabaseStorage;

public interface IPersonParser
{
    List<Person> ParseFromCSV(IEnumerable<string> lines);
}