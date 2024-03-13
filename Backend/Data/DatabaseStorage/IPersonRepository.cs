using System.Reflection;
using CrossCutting.DomainModel;
using CrossCutting.Proxies.Logging;
using FluentValidation.Results;

[assembly:LogWorkflow]

namespace Backend.Data.DatabaseStorage;
public interface IPersonRepository
{
    IQueryable<Person> GetAllPersons();
    void Insert(Person person);
    ValidationResult ValidateForInsert(Person person);
}