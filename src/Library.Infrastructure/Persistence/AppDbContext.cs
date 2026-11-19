using Library.Infrastructure.Persistence.Common;
using Library.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<BookEntity> Books => Set<BookEntity>();
    public DbSet<BookCopyEntity> BookCopies => Set<BookCopyEntity>();
    public DbSet<BookBorrowingEntity> BookBorrowings => Set<BookBorrowingEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    private void UpdateAuditProperties()
    {
        // TODO implement auth & current user service
        var currentUserId = Guid.Parse("4fc189ff-e6a2-4d7e-917b-4991b8797ed6"); // _currentUserService.UserId;

        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.SetCreated(currentUserId);
                    break;

                case EntityState.Modified:
                    entry.Entity.SetUpdated(currentUserId);
                    break;
            }
        }
    }

    public override int SaveChanges()
    {
        UpdateAuditProperties();

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditProperties();

        return base.SaveChangesAsync(cancellationToken);
    }
}
