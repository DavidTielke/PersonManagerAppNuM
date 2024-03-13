using System.Reflection;
using Castle.DynamicProxy;

namespace CrossCutting.Proxies.Logging;

public abstract class AbstractInterceptor : IInterceptor
{
    public TAttribute GetAttributeOrDefault<TAttribute>(IInvocation invocation)
        where TAttribute : Attribute
    {
        var attribute = invocation.Method.GetCustomAttribute<TAttribute>();
        if (attribute != null) return attribute;

        attribute = invocation.Method.DeclaringType.GetCustomAttribute<TAttribute>();
        if (attribute != null) return attribute;

        attribute = invocation.Method.DeclaringType.Assembly.GetCustomAttribute<TAttribute>();
        if (attribute != null) return attribute;

        return null;
    }

    public abstract void Intercept(IInvocation invocation);
}