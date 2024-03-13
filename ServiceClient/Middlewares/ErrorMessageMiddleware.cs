using CrossCutting.Exceptions;

namespace ServiceClient.Middlewares;

public class ErrorMessageMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorMessageMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NuMBaseException e)
        {
            var errorMessages = new List<string>();
            var exception = e;
            errorMessages.Add(exception.DomainMessage);
            while (exception.InnerException != null)
            {
                if (exception.InnerException is NuMBaseException numException)
                {
                    exception = numException;
                    errorMessages.Add(exception.DomainMessage);
                }
                else
                {
                    break;
                }

            }

            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(errorMessages);
        }
    }
}

public class ExceptionErrorCodeMappingMiddleware
{
    private readonly RequestDelegate _next;

    private readonly Dictionary<Type, int> _mappings;

    public ExceptionErrorCodeMappingMiddleware(RequestDelegate next)
    {
        _next = next;

        _mappings = new Dictionary<Type, int>
        {
            [typeof(ArgumentNullException)] = 500,
        };
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            var exceptionType = e.GetType();
            var code = _mappings[exceptionType];
            context.Response.StatusCode = code;
        }
    }
}