using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossCutting.DomainModel;
using FluentValidation;

namespace Backend.Logic.PersonManagement
{
    public interface IPersonAddLogicValidator : IValidator<Person>
    {
    }
}
