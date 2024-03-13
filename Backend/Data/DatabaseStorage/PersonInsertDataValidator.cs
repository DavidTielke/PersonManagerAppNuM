using CrossCutting.DomainModel;
using FluentValidation;

namespace Backend.Data.DatabaseStorage;

public class PersonInsertDataValidator : AbstractValidator<Person>, IPersonInsertDataValidator
{
    public PersonInsertDataValidator()
    {
        RuleFor(p => p.Id).Equal(0);
        RuleFor(p => p.Name).NotEmpty().NotNull().MinimumLength(2).MaximumLength(255);
    }
}