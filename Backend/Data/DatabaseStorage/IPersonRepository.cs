using System.Reflection;
using CrossCutting.DomainModel;
using CrossCutting.Proxies.ExceptionMapping;
using CrossCutting.Proxies.Logging;
using FluentValidation.Results;

[assembly:LogWorkflow]

namespace Backend.Data.DatabaseStorage;

[ExceptionMap(typeof(DatabaseStorageException))]
public interface IPersonRepository
{
    IQueryable<Person> GetAllPersons();

    [ExceptionDomainMessage("Person konnte nicht in Datenbank hinzugefügt werden")]
    void Insert(Person person);
    ValidationResult ValidateForInsert(Person person);
}