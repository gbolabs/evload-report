using Microsoft.EntityFrameworkCore;
using persistence.Entities;

namespace persistence.EF;

public class MyDataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<ExpenseReport> ExpenseReports { get; set; }
    public DbSet<LoadSession> LoadSessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ExpenseReport>(builder =>
            {
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Timestamp).IsRequired();
                builder.Property(e => e.IsClosed).IsRequired(false);
                builder.Property(e => e.TotalCost).IsRequired(false);
                builder.Property(e => e.TotalEnergy).IsRequired(false);
                builder.HasMany(e => e.LoadSession)
                    .WithOne(ls => ls.ExpenseReport)
                    .HasForeignKey(ls => ls.ExpenseReportId)
                    .IsRequired(false);
            })
            .Entity<LoadSession>(builder =>
            {
                builder.HasKey(ls => ls.Id);
                builder.Property(ls => ls.TotalEnergy);
                builder.Property(ls => ls.Tariff).IsRequired();
                builder.Property(ls => ls.EndEnergy).IsRequired(false);
                builder.Property(ls => ls.StartEnergy).IsRequired();
                builder.Property(ls => ls.StartTimestamp).IsRequired();
                builder.Property(ls => ls.EndTimestamp).IsRequired(false);
                builder.HasOne(ls => ls.ExpenseReport)
                    .WithMany(e => e.LoadSession)
                    .IsRequired(false);
            });
    }
}