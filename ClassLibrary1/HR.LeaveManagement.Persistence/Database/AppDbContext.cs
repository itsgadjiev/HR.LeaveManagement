using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Domain.Common.abstracts;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);


        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var item in base.ChangeTracker.Entries<IAuditable>()
            .Where(x => x.State == EntityState.Modified || x.State == EntityState.Added))
        {
            if (item.State == EntityState.Added)
            {
                item.Entity.UpdatedAt = DateTime.UtcNow;
                item.Entity.CreatedAt = DateTime.UtcNow;
            }
            else if (item.State == EntityState.Modified)
            {
                item.Entity.UpdatedAt = DateTime.UtcNow;

            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
    public DbSet<LeaveRequest> LeaveRequest { get; set; }
}
