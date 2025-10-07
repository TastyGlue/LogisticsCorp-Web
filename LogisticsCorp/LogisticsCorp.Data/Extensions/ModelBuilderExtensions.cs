namespace LogisticsCorp.Data.Extensions;

public static class ModelBuilderExtensions
{
    /// <summary>
    /// Configures the delete behavior for all foreign key relationships in the model to use <see
    /// cref="DeleteBehavior.Restrict"/>.
    /// </summary>
    /// <remarks>This method iterates through all foreign key relationships in the model and sets their delete
    /// behavior to  <see cref="DeleteBehavior.Restrict"/>, ensuring that dependent entities are not automatically
    /// deleted when  their principal entities are removed. Use this method to enforce referential integrity constraints
    /// in the database.</remarks>
    /// <param name="modelBuilder">The <see cref="ModelBuilder"/> used to configure the entity model.</param>
    public static void ConfigureRestrictDeleteBehavior(this ModelBuilder modelBuilder)
    {
        foreach (var foreignKey in modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

    /// <summary>
    /// Configures the navigation property for the many-to-many relationship between users and roles.
    /// </summary>
    /// <param name="modelBuilder">The <see cref="ModelBuilder"/> used to configure the entity relationships.</param>
    public static void ConfigureUserRolesNavigationProperty(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany()
                .UsingEntity<IdentityUserRole<Guid>>(
                    l => l.HasOne<IdentityRole<Guid>>().WithMany().HasForeignKey(ur => ur.RoleId),
                    r => r.HasOne<User>().WithMany().HasForeignKey(ur => ur.UserId)
                );
    }
}
