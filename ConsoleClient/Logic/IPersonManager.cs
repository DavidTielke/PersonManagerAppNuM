namespace ConsoleClient.Logic;

public interface IPersonManager
{
    List<Person> GetAllAdults();
    List<Person> GetAllChildren();
    //void Add(Person person);
}