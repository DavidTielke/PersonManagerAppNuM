using CrossCutting.DomainModel;
using CrossCutting.Proxies.Logging;
using FluentValidation.Results;

namespace Backend.Logic.PersonManagement;

public interface IPersonManager
{
    IQueryable<Person> GetAllAdults();
    IQueryable<Person> GetAllChildren();
    [LogWorkflow]
    IQueryable<Person> GetAll();
    void Add(Person person);
    ValidationResult ValidateForAdd(Person person);
}