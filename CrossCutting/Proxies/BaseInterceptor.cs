using System.Reflection;
using Castle.DynamicProxy;

namespace CrossCutting.Proxies;

public abstract class BaseInterceptor : IInterceptor
{
    public Attribute GetAttributeOrDefault(Type attributeType, IInvocation invocation)
    {
        var attribute = invocation.Method.GetCustomAttribute(attributeType);
        if (attribute != null) return attribute;

        attribute = invocation.Method.DeclaringType.GetCustomAttribute(attributeType);
        if (attribute != null) return attribute;

        attribute = invocation.Method.DeclaringType.Assembly.GetCustomAttribute(attributeType);
        if (attribute != null) return attribute;

        return null;
    }

    public TAttribute GetAttributeOrDefault<TAttribute>(IInvocation invocation)
        where TAttribute : Attribute
    {
        return (TAttribute)GetAttributeOrDefault(typeof(TAttribute), invocation);
    }

    public abstract void Intercept(IInvocation invocation);
}