using LibraryApp.Application.Common.Interfaces;
using LibraryApp.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApp.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        return services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}