using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;
using TaskProjectUnitSolution.Domain;
using TaskProjectUnitSolution.Domain.Repositories;
using TaskProjectUnitSolution.Infastructure.Persistence;
using TaskProjectUnitSolution.Infastructure.Persistence.Repositories;

namespace Microsoft.Extensions.DependencyInjection;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());


        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                        .LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging());
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProjectRepository, ProjectRepository>();


        return services;
    }
}
