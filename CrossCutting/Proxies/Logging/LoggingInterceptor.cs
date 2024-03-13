using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace CrossCutting.Proxies.Logging
{
    public class LoggingInterceptor : AbstractInterceptor
    {
        public override void Intercept(IInvocation invocation)
        {
            var attribute = GetAttributeOrDefault<LogWorkflowAttribute>(invocation);

            if (attribute != null)
            {
                try
                {
                    Console.WriteLine($"+++ ENTER {invocation.Method.Name} +++");
                    invocation.Proceed();

                    Console.WriteLine($"#ä## FINISHED {invocation.Method.Name} ###");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"!!! ERROR {invocation.Method.Name} ###");
                    throw;
                }
            }
            else
            {
                invocation.Proceed();
            }
        }
    }
}
