using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VEA.Core.Domain.Common.UnitOfWork;
using VEA.Infrastructure.EfcDmPersistence.UnitOfWork;

namespace Infrastructure.EfcDmPersistence.Extensions;

public static class ApplicationExtensions
{
    public static void RegisterPersistence(this IServiceCollection services, string connectionString)
    {
        // get connection string relative to this files location
        services.AddDbContext<DomainModelContext>(
            options => options.UseSqlite(connectionString)
        );
        
        services.AddScoped<IUnitOfWork, EfcUnitOfWork>();
        
        //services.AddScoped<IEventRepository, VeaEventEfcRepository>();
        //services.AddScoped<IGuestRepository, GuestEfcRepository>();
    }
}