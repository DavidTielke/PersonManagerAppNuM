using CrossCutting.DomainModel;

namespace Backend.Logic.PersonManagement;

public interface IPersonManager
{
    IQueryable<Person> GetAllAdults();
    IQueryable<Person> GetAllChildren();
    IQueryable<Person> GetAll();
    //void Add(Person person);
    void Add(Person person);
}