using LibraryApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApp.Infrastructure;

public static class DependencyInjection
{
    private const string DefaultConnection = "SqlServer_Dev";
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config, string? connection = null)
    {
        services.AddDbContext<LibraryDatabaseContext>(opt =>
        {
            opt.UseSqlServer(config.GetConnectionString(connection ?? DefaultConnection));
        });

        return services;
    }
}