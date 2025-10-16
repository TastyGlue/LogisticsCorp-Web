namespace LogisticsCorp.Data;

public class LogisticsCorpDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public LogisticsCorpDbContext(DbContextOptions<LogisticsCorpDbContext> options)
        : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<ShipmentHistory> ShipmentHistories { get; set; }
    public DbSet<PricingRule> PricingRules { get; set; }
    public DbSet<Office> Offices { get; set; }

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

        // Ensure that each user can have only one role assignment
        modelBuilder.Entity<IdentityUserRole<Guid>>()
            .HasIndex(ur => ur.UserId).IsUnique();

        modelBuilder.ConfigureShipmentTableRelations();

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
