using Castle.DynamicProxy;
using CrossCutting.Proxies.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Proxies.Caching
{
    public class CachingInterceptor : BaseInterceptor
    {
        //private readonly ICache _cache;

        //public ValidationInterceptor(ICache cache)
        //{
        //    _cache = cache;
        //}

        public override void Intercept(IInvocation invocation)
        {
            var attribute = GetAttributeOrDefault<CachedResultAttribute>(invocation);
            if (attribute != null)
            {
                //invocation.ReturnValue = _cache.Get("sdsddsd");
            }
            else
            {
                 invocation.Proceed();
            }
        }
    }
}
