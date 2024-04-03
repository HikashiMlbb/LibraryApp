using FluentValidation;
using LibraryApp.Application.Common.Behaviors;
using LibraryApp.Application.Common.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<AutoMapperProfile>();
        });
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        return services;
    }
}