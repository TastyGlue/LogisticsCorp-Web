namespace LogisticsCorp.Data;

public class LogisticsCorpDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public LogisticsCorpDbContext(DbContextOptions<LogisticsCorpDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureUserRolesNavigationProperty();

        modelBuilder.ConfigureRestrictDeleteBehavior();
    }
}
