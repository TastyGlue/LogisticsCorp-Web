using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.API.Services
{
    public class CompanyInfoService : ICompanyInfo
    {
        private readonly LogisticsCorpDbContext _context;

        public CompanyInfoService(LogisticsCorpDbContext context)
        {
            _context = context;
        }

        public async Task<CustomResult> Get()
        {
            var companyInfo = await _context.CompanyInfo.FirstOrDefaultAsync();

            if (companyInfo == null)
                return new CustomResult(new ErrorResult($"No company info found ", ErrorCodes.ENTITY_NOT_FOUND));

            return new CustomResult<CompanyInfo>(companyInfo);
        }

        public async Task<CustomResult> Update(CompanyInfoDTO dto)
        {
            var companyInfo = await _context.CompanyInfo.FirstOrDefaultAsync();
            if (companyInfo == null)
                return new CustomResult(new ErrorResult("Company info not found", ErrorCodes.ENTITY_NOT_FOUND));

            _context.Entry(companyInfo).CurrentValues.SetValues(dto);
            await _context.SaveChangesAsync();

            return new CustomResult<CompanyInfo>(companyInfo);
        }
    }
}

