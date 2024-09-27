using Microsoft.Extensions.DependencyInjection;
using VEA.Core.QueryContracts.QueryDispatching;

namespace Core.QueryContract.Extensions;

public static class ApplicationExtensions
{
    public static void RegisterQueryDispatcher(this IServiceCollection services)
    {
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();
    }   
}