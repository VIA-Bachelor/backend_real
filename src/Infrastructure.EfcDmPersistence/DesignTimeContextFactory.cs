using Infrastructure.EfcDmPersistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace VEA.Infrastructure.EfcDmPersistence;

public class DesignTimeContextFactory : IDesignTimeDbContextFactory<DomainModelContext>
{
    public DomainModelContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<DomainModelContext> optionsBuilder = new();
        optionsBuilder.UseSqlite(@"Data Source = VEADatabaseProduction.db");
        return new DomainModelContext(optionsBuilder.Options);
    }
}