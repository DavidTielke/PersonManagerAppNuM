using CrossCutting.DomainModel;
using CrossCutting.Proxies.Caching;
using CrossCutting.Proxies.ExceptionMapping;
using CrossCutting.Proxies.Logging;
using CrossCutting.Proxies.Validation;
using FluentValidation.Results;

namespace Backend.Logic.PersonManagement;

[ExceptionMap(typeof(PersonManagementException))]
public interface IPersonManager
{
    IQueryable<Person> GetAllAdults();
    IQueryable<Person> GetAllChildren();

    [LogWorkflow]
    IQueryable<Person> GetAll();

    [ExceptionDomainMessage("Kann Person logisch nicht hinzufügen")]
    void Add(Person person);
    ValidationResult ValidateForAdd(Person person);
}