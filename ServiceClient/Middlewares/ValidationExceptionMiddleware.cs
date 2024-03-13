using FluentValidation;

namespace ServiceClient.Middlewares
{
    public class ValidationExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException e)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(e.Errors);
            }
        }
    }
}
