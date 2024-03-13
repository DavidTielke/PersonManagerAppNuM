using System.Diagnostics.Tracing;
using Castle.DynamicProxy;

namespace ServiceClient.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProxiedTransient<TContract, TImplementation>(this IServiceCollection source)
        where TContract : class
        where TImplementation : class, TContract
        {
            source.AddTransient<TImplementation>();
            source.AddTransient<TContract>(sp =>
            {
                var proxyGenerator = sp.GetRequiredService<ProxyGenerator>();
                var target = sp.GetRequiredService<TImplementation>();
                var inceptor = sp.GetServices<IInterceptor>().ToArray();
                var proxy = (TContract)proxyGenerator.CreateInterfaceProxyWithTarget(typeof(TContract), target, inceptor);
                return proxy;
            });

            return source;
        }
    }
}
