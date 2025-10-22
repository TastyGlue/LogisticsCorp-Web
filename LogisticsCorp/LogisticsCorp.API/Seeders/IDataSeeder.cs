namespace LogisticsCorp.API.Seeders;

/// <summary>
/// Defines a contract for data seeding operations.
/// Implementations specify their order of execution via the <see cref="Order"/> property
/// and perform database seeding tasks asynchronously using the <see cref="Seed(DbContext)"/> method.
/// </summary>
public interface IDataSeeder
{
    int Order { get; }
    Task Seed(DbContext context);
}
