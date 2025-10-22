namespace LogisticsCorp.API.Seeders;

public class ShipmentHistorySeeder : IDataSeeder
{
    public int Order => 8;

    public async Task Seed(DbContext context)
    {
        var data = ReadJsonDataFile<ShipmentHistory>("Seeds/ShipmentHistorySeedData.json");

        foreach (var history in data)
        {
            if (await context.Set<ShipmentHistory>().AnyAsync(sh => sh.Id == history.Id)) continue;

            context.Set<ShipmentHistory>().Add(history);
        }

        await context.SaveChangesAsync();
    }
}
