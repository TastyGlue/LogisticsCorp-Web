namespace LogisticsCorp.API.Seeders;

public class PricingRuleSeeder : IDataSeeder
{
    public int Order => 3;

    public async Task Seed(DbContext context)
    {
        var data = ReadJsonDataFile<PricingRule>("Seeds/PricingRuleSeedData.json");

        foreach (var rule in data)
        {
            if (await context.Set<PricingRule>().AnyAsync(pr => pr.Id == rule.Id)) continue;

            context.Set<PricingRule>().Add(rule);
        }

        await context.SaveChangesAsync();
    }
}
