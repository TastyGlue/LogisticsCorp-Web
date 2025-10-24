namespace LogisticsCorp.Data;

public class LogisticsCorpDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public LogisticsCorpDbContext(DbContextOptions<LogisticsCorpDbContext> options)
        : base(options) { }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<ShipmentHistory> ShipmentHistories { get; set; }
    public DbSet<PricingRule> PricingRules { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Set the CreatedOn and ModifiedOn properties of entities when saving changes 
        SetAudit();

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Set up TPT inheritance mapping for Account, Employee, and Client
        modelBuilder.Entity<Account>().ToTable("Accounts");
        modelBuilder.Entity<Employee>().ToTable("Employees");
        modelBuilder.Entity<Client>().ToTable("Clients");

        modelBuilder.ConfigureUserRolesNavigationProperty();

        // Ensure that each user can have only one role assignment
        modelBuilder.Entity<IdentityUserRole<Guid>>()
            .HasIndex(ur => ur.UserId).IsUnique();

        modelBuilder.ConfigureShipmentTableRelations();

        modelBuilder.ConfigureRestrictDeleteBehavior();
    }

    /// <summary>
    /// Updates audit information for entities implementing the <see cref="IAuditedEntity"/> interface  that are being
    /// tracked by the change tracker.
    /// </summary>
    /// <remarks>Sets the <see cref="IAuditedEntity.CreatedOn"/> property to the current UTC time for entities
    /// in the <see cref="EntityState.Added"/> state. For entities in the <see cref="EntityState.Modified"/>  state,
    /// updates the <see cref="IAuditedEntity.ModifiedOn"/> property to the current UTC time.</remarks>
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
