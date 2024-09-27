using Microsoft.Extensions.DependencyInjection;
using VEA.Core.Application.AppEntry;
using VEA.Core.Application.AppEntry.CommandDispatcher;

namespace Core.Application.Extensions;

public static class ApplicationExtensions
{
    public static void RegisterCommandHandlers(this IServiceCollection services)
    {
        List<Type> handlerTypes = typeof(ApplicationExtensions).Assembly
            .GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false } && t.GetInterfaces().Any(
                i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
            .ToList();
        
        foreach (var handlerType in handlerTypes) 
        {
            var interfaceType = handlerType.GetInterfaces().FirstOrDefault(
                i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>));
            if (interfaceType == null) continue;
            services.AddScoped(interfaceType, handlerType);
        }
    }
    
    public static void RegisterCommandDispatcher(this IServiceCollection services)
        => services.AddScoped<ICommandDispatcher, CommandDispatcher>();
}