using CrossCutting.DomainModel;
using FluentValidation;

namespace Backend.Logic.PersonManagement;

public class PersonAddLogicValidator : AbstractValidator<Person>, IPersonAddLogicValidator
{
    public PersonAddLogicValidator()
    {
        RuleFor(p => p.Name).NotEqual("Max");
        RuleFor(p => p.Age).ExclusiveBetween(0, 100);
    }
}