namespace ConsoleClient.Data;

public interface IPersonDataValidator
{
    void AssertForInsert(Person person);
}