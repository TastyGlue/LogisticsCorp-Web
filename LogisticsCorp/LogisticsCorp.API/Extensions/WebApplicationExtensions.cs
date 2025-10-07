namespace LogisticsCorp.API.Extensions;

public static class WebApplicationExtensions
{
    /// <summary>
    /// Migrates the database to the latest version and seeds it with initial data.
    /// </summary>
    /// <remarks>This method ensures that the database schema is up-to-date by applying any pending
    /// migrations. It also retrieves all registered implementations of <see cref="IDataSeeder"/>, orders them by their
    /// <see cref="IDataSeeder.Order"/> property, and invokes their <see cref="IDataSeeder.Seed"/> method to populate
    /// the database with initial data.</remarks>
    /// <param name="app">The <see cref="WebApplication"/> instance used to access the application's services.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public static async Task MigrateDbAndSeedData(this WebApplication app)
    {
        using var serviceScope = app.Services.CreateScope();
        var serviceProvider = serviceScope.ServiceProvider;
        var dbContext = serviceProvider.GetRequiredService<LogisticsCorpDbContext>();

        // Migrate the database to the latest version or create it if it doesn't exist
        await dbContext.Database.MigrateAsync();

        // Seed the database with initial data
        var seeders = serviceProvider.GetServices<IDataSeeder>().OrderBy(s => s.Order);

        foreach (var seeder in seeders)
            await seeder.Seed(dbContext);
    }
}
