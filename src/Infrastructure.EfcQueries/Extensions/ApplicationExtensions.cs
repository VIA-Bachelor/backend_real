using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VEA.Core.QueryContracts.Contract;

namespace Infrastructure.EfcQueries.Extensions;

public static class ApplicationExtensions
{
    public static void RegisterQueryHandlers(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DatabaseProductionContext>(options =>
        {
            options.UseSqlite(connectionString);
        });
        
        List<Type> handlerTypes = typeof(ApplicationExtensions).Assembly
            .GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false } && t.GetInterfaces().Any(
                i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)))
            .ToList();

        foreach (var handlerType in handlerTypes)
        {
            var interfaceType = handlerType.GetInterfaces().FirstOrDefault(
                i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>));
            if (interfaceType == null) continue; 
            services.AddScoped(interfaceType, handlerType);
        }
    }   
}