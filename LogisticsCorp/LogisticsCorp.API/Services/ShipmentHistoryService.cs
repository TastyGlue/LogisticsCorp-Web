using LogisticsCorp.Shared.Models.DTOs;
using MapsterMapper;

namespace LogisticsCorp.API.Services
{
    public class ShipmentHistoryService : IShipmentHistoryService
    {
        private readonly LogisticsCorpDbContext _context;
        private readonly IMapper _mapper;

        public ShipmentHistoryService(LogisticsCorpDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomResult> Get(Guid id)
        {
            var history = await _context.ShipmentHistories
                .Include(h => h.Shipment)
                .Include(h => h.Employee)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (history == null)
                return new CustomResult(new ErrorResult($"ShipmentHistory with ID {id} not found.", ErrorCodes.ENTITY_NOT_FOUND));

            return new CustomResult<ShipmentHistory>(history);
        }

        public async Task<CustomResult> GetAll()
        {
            var histories = await _context.ShipmentHistories
                .Include(h => h.Shipment)
                .Include(h => h.Employee)
                .ToListAsync();

            return new CustomResult<IEnumerable<ShipmentHistory>>(histories);
        }

        public async Task<CustomResult> Create(ShipmentHistoryDto dto)
        {
            var history = _mapper.Map<ShipmentHistory>(dto);
            _context.ShipmentHistories.Add(history);
            await _context.SaveChangesAsync();
            return new CustomResult<ShipmentHistory>(history);
        }

        public async Task<CustomResult> Update(Guid id, ShipmentHistoryDto dto)
        {
            if (id != dto.Id)
                return new CustomResult(new ErrorResult("Mismatching ids", ErrorCodes.ENTITY_MISMATCH_ID));

            var history = await _context.ShipmentHistories.FindAsync(id);
            if (history == null)
                return new CustomResult(new ErrorResult("ShipmentHistory not found", ErrorCodes.ENTITY_NOT_FOUND));

            _context.Entry(history).CurrentValues.SetValues(dto);
            await _context.SaveChangesAsync();

            return new CustomResult<ShipmentHistory>(history);
        }

        public async Task<CustomResult> Delete(Guid id)
        {
            var history = await _context.ShipmentHistories.FindAsync(id);
            if (history == null)
                return new CustomResult(new ErrorResult("ShipmentHistory not found", ErrorCodes.ENTITY_NOT_FOUND));

            _context.ShipmentHistories.Remove(history);
            await _context.SaveChangesAsync();

            return new CustomResult<string>("Deleted successfully!");
        }
    }

}
