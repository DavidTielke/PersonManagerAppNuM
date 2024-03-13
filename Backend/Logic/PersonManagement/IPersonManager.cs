using CrossCutting.DomainModel;
using FluentValidation.Results;

namespace Backend.Logic.PersonManagement;

public interface IPersonManager
{
    IQueryable<Person> GetAllAdults();
    IQueryable<Person> GetAllChildren();
    IQueryable<Person> GetAll();
    void Add(Person person);
    ValidationResult ValidateForAdd(Person person);
}