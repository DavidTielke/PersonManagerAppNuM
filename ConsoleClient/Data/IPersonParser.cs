namespace ConsoleClient.Data;

public interface IPersonParser
{
    List<Person> ParseFromCSV(IEnumerable<string> lines);
}