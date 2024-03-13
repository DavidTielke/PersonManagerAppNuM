using CrossCutting.DomainModel;
using FluentValidation.Results;

namespace Backend.Data.DatabaseStorage;

public interface IPersonRepository
{
    IQueryable<Person> GetAllPersons();
    void Insert(Person person);
    ValidationResult ValidateForInsert(Person person);
}