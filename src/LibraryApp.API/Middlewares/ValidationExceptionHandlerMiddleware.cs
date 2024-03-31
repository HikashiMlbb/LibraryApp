using System.Net;
using System.Text.Json;
using FluentValidation;
using FluentValidation.Results;

namespace LibraryApp.API.Middlewares;

public class ValidationExceptionHandlerMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException exception)
        {
            var code = HttpStatusCode.BadRequest;
            var result = 
                JsonSerializer.Serialize(
                    exception.Errors.Select(x 
                        => new { Property = x.PropertyName, Message = x.ErrorMessage, Code = x.ErrorCode }));

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            await context.Response.WriteAsync(result);
        }
    }
}