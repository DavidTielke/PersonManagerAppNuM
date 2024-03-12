using CrossCutting.DomainModel;

namespace Backend.Data.DatabaseStorage;

public interface IPersonRepository
{
    IQueryable<Person> GetAllPersons();
    void Insert(Person person);
}