using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EfcQueries;

public partial class DatabaseProductionContext : DbContext
{
    public DatabaseProductionContext()
    {
    }

    public DatabaseProductionContext(DbContextOptions<DatabaseProductionContext> options)
        : base(options)
    {
    }

//     public virtual DbSet<Guest> Guests { get; set; }
//
//     public virtual DbSet<Invitation> Invitations { get; set; }
//
//     public virtual DbSet<Participation> Participations { get; set; }
//
//     public virtual DbSet<VeaEvent> VeaEvents { get; set; }
//
// //     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
// //         => optionsBuilder.UseSqlite("Data Source=C:\\Users\\miloA\\OneDrive\\Skrivebord\\Skole\\Fag\\6_Semester\\DCA\\DCA1_VEA\\src\\Infrastructure\\VEA.Infrastructure.EfcDmPersistence\\VEADatabaseProduction.db");
//
//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.Entity<Guest>(entity =>
//         {
//             entity.ToTable("Guest");
//         });
//
//         modelBuilder.Entity<Invitation>(entity =>
//         {
//             entity.ToTable("Invitation");
//
//             entity.HasIndex(e => e.EventId, "IX_Invitation_EventId");
//
//             entity.HasIndex(e => e.GuestId, "IX_Invitation_GuestId");
//
//             entity.HasOne(d => d.Event).WithMany(p => p.Invitations).HasForeignKey(d => d.EventId);
//
//             entity.HasOne(d => d.Guest).WithMany(p => p.Invitations).HasForeignKey(d => d.GuestId);
//         });
//
//         modelBuilder.Entity<Participation>(entity =>
//         {
//             entity.HasKey(e => new { e.EventId, e.GuestId });
//
//             entity.ToTable("Participation");
//
//             entity.HasIndex(e => e.GuestId, "IX_Participation_GuestId");
//
//             entity.HasIndex(e => e.Id, "IX_Participation_Id");
//
//             entity.HasOne(d => d.Event).WithMany(p => p.Participations).HasForeignKey(d => d.EventId);
//
//             entity.HasOne(d => d.Guest).WithMany(p => p.Participations).HasForeignKey(d => d.GuestId);
//         });
//
//         modelBuilder.Entity<VeaEvent>(entity =>
//         {
//             entity.ToTable("VeaEvent");
//         });
//
//         OnModelCreatingPartial(modelBuilder);
//     }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
