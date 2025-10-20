namespace LogisticsCorp.API.Seeders;

public class OfficeSeeder : IDataSeeder
{
    public int Order => 3;

    public async Task Seed(DbContext context)
    {
        var data = ReadJsonDataFile<Office>("Seeds/OfficeSeedData.json");

        foreach (var office in data)
        {
            if (await context.Set<Office>().AnyAsync(o => o.Id == office.Id)) continue;

            context.Set<Office>().Add(office);
        }

        await context.SaveChangesAsync();
    }
}
