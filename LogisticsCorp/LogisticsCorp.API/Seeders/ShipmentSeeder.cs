namespace LogisticsCorp.API.Seeders;

public class ShipmentSeeder : IDataSeeder
{
    public int Order => 7;

    public async Task Seed(DbContext context)
    {
        var data = ReadJsonDataFile<Shipment>("Seeds/ShipmentSeedData.json");

        foreach (var shipment in data)
        {
            if (await context.Set<Shipment>().AnyAsync(s => s.Id == shipment.Id)) continue;

            context.Set<Shipment>().Add(shipment);
        }

        await context.SaveChangesAsync();
    }
}
