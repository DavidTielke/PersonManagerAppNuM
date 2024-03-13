using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using FluentValidation;

namespace CrossCutting.Proxies.Validation
{
    public class ValidationInterceptor : BaseInterceptor
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidationInterceptor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override void Intercept(IInvocation invocation)
        {
            var attribute = GetAttributeOrDefault(typeof(ValidateByAttribute<>), invocation);
            var validatorType = attribute.GetType().GenericTypeArguments.First();

            //AbstractValidator<> validator = (IValidator)_serviceProvider.GetService(validatorType);
            //validator.Vali
        }
    }
}
