using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.RepositoryImplementations.Users;
using CleanArchitecture.Infrastructure.ServiceImplementations.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace CleanArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DefaultDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DbConnection"), b => b.MigrationsAssembly(typeof(DefaultDbContext).Assembly.FullName)));

        Dependency(services);
        return services;
    }
    public static void Dependency(this IServiceCollection services)
    {
        var assembliesToScan = new[]
        {
            Assembly.GetExecutingAssembly(),
            Assembly.GetAssembly(typeof(UserService)),
            Assembly.GetAssembly(typeof(UserRepository))
        };
        services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
            .Where(c => c.Name.EndsWith("Service") || c.Name.EndsWith("Repository"))
            .AsPublicImplementedInterfaces();
    }
}
