using CrossCutting.DomainModel;

namespace Backend.Data.DatabaseStorage;

public interface IPersonDataValidator
{
    void AssertForInsert(Person person);
}