namespace LogisticsCorp.API.Seeders;

/// <summary>
/// Defines a contract for data seeding operations.
/// Implementations specify their order of execution via the <see cref="Order"/> property
/// and perform database seeding tasks asynchronously using the <see cref="Seed(DbContext)"/> method.
/// </summary>
public interface IDataSeeder
{
    /// <summary>
    /// Gets the order of execution for this item.
    /// </summary>
    int Order { get; }

    /// <summary>
    /// Seeds the specified <see cref="DbContext"/> with initial data.
    /// </summary>
    /// <remarks>This method populates the database with predefined data necessary for application
    /// initialization.</remarks>
    /// <param name="context">The <see cref="DbContext"/> to seed. Cannot be null.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task Seed(DbContext context);
}
