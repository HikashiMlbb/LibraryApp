using LibraryApp.API.Middlewares;

namespace LibraryApp.API.Extensions;

public static class UseCustomExceptionHandlerMiddleware
{
    /// <remarks>Should be used after all exception handler middlewares.</remarks>
    public static IApplicationBuilder UseValidationExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ValidationExceptionHandlerMiddleware>();
    }
}