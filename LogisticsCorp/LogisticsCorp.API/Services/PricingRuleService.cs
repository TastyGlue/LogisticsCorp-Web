using LogisticsCorp.Shared.Models.DTOs;
using MapsterMapper;

namespace LogisticsCorp.API.Services
{
    public class PricingRuleService : IPricingRuleService
    {
        private readonly LogisticsCorpDbContext _context;
        private readonly IMapper _mapper;

        public PricingRuleService(LogisticsCorpDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomResult> Get(Guid id)
        {
            var rule = await _context.PricingRules.FirstOrDefaultAsync(r => r.Id == id);
            if (rule == null)
                return new CustomResult(new ErrorResult($"PricingRule with ID {id} not found.", ErrorCodes.ENTITY_NOT_FOUND));

            return new CustomResult<PricingRule>(rule);
        }

        public async Task<CustomResult> GetAll()
        {
            var rules = await _context.PricingRules.ToListAsync();
            return new CustomResult<IEnumerable<PricingRule>>(rules);
        }

        public async Task<CustomResult> Create(PricingRuleDto dto)
        {
            var rule = _mapper.Map<PricingRule>(dto);
            _context.PricingRules.Add(rule);
            await _context.SaveChangesAsync();
            return new CustomResult<PricingRule>(rule);
        }

        public async Task<CustomResult> Update(Guid id, PricingRuleDto dto)
        {
            if (id != dto.Id)
                return new CustomResult(new ErrorResult("Mismatching ids", ErrorCodes.ENTITY_MISMATCH_ID));

            var rule = await _context.PricingRules.FindAsync(id);
            if (rule == null)
                return new CustomResult(new ErrorResult("PricingRule not found", ErrorCodes.ENTITY_NOT_FOUND));

            _context.Entry(rule).CurrentValues.SetValues(dto);
            await _context.SaveChangesAsync();

            return new CustomResult<PricingRule>(rule);
        }

        public async Task<CustomResult> Delete(Guid id)
        {
            var rule = await _context.PricingRules.FindAsync(id);
            if (rule == null)
                return new CustomResult(new ErrorResult("PricingRule not found", ErrorCodes.ENTITY_NOT_FOUND));

            _context.PricingRules.Remove(rule);
            await _context.SaveChangesAsync();

            return new CustomResult<string>("Deleted successfully!");
        }
    }
}
