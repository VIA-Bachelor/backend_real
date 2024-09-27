using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EfcDmPersistence;

public class DomainModelContext(DbContextOptions<DomainModelContext> options) : DbContext(options)
{
    //public DbSet<Guest> Guest => Set<Guest>();
    //public DbSet<VeaEvent> VeaEvent => Set<VeaEvent>();
    //public DbSet<Invitation> Invitation => Set<Invitation>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DomainModelContext).Assembly);
    }
}