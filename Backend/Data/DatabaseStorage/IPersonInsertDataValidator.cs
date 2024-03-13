using CrossCutting.DomainModel;
using FluentValidation;

namespace Backend.Data.DatabaseStorage;

public interface IPersonInsertDataValidator : IValidator<Person>
{
}