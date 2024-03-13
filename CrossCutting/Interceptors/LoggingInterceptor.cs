using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace CrossCutting.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                Console.WriteLine($"+++ ENTER {invocation.Method.Name} +++");
                invocation.Proceed();

                Console.WriteLine($"### FINISHED {invocation.Method.Name} ###");
            }
            catch (Exception e)
            {
                Console.WriteLine($"!!! ERROR {invocation.Method.Name} ###");
                throw;
            }
        }
    }
}
