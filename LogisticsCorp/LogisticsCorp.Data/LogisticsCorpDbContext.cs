namespace LogisticsCorp.Data;

public class LogisticsCorpDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public LogisticsCorpDbContext(DbContextOptions<LogisticsCorpDbContext> options)
        : base(options) { }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Set the CreatedOn and ModifiedOn properties of entities when saving changes 
        SetAudit();

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureUserRolesNavigationProperty();

        modelBuilder.ConfigureRestrictDeleteBehavior();
    }

    private void SetAudit()
    {
        var entries = ChangeTracker.Entries<IAuditedEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedOn = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.ModifiedOn = DateTime.UtcNow;
            }
        }
    }
}
