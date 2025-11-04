
namespace LogisticsCorp.API.Seeders
{
    public class CompanyInfoSeeder : IDataSeeder
    {
        public int Order => 101;

        public async Task Seed(DbContext context)
        {
            var data = ReadJsonDataFile<CompanyInfo>("Seeds/CompanyInfoSeedData.json");

            foreach (var companyInfo in data)
            {
                if (await context.Set<CompanyInfo>().AnyAsync(o => o.Id == companyInfo.Id)) continue;

                context.Set<CompanyInfo>().Add(companyInfo);
            }

            await context.SaveChangesAsync();
        }
    }
}
