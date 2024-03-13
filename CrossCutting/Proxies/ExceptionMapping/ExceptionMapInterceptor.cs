using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using CrossCutting.Exceptions;

namespace CrossCutting.Proxies.ExceptionMapping
{
    public class ExceptionMapInterceptor : BaseInterceptor
    {
        public override void Intercept(IInvocation invocation)
        {
            var attribute = GetAttributeOrDefault<ExceptionMap>(invocation);
            if (attribute != null)
            {
                try
                {
                    invocation.Proceed();
                }
                catch (Exception e)
                {
                    var domainMessageAttribute = GetAttributeOrDefault<ExceptionDomainMessage>(invocation);
                    var domainMessage = domainMessageAttribute.DomainMessage;
                    var excpetion = (NuMBaseException)Activator.CreateInstance(attribute.ExceptionType, "", domainMessage, e);
                    throw excpetion;
                }
            }
            else
            {
                invocation.Proceed();
            }
        }
    }
}
