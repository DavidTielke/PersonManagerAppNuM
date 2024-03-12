namespace ConsoleClient.Data;

public interface IPersonConverter
{
    string ToCsv(Person person);
}