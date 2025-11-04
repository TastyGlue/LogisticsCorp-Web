using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.API.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly LogisticsCorpDbContext _context;

        public ShipmentService(LogisticsCorpDbContext context)
        {
            _context = context;
        }

        public async Task<CustomResult> Get(Guid id)
        {
            var shipment = await _context.Shipments
                .Include(s => s.Sender).ThenInclude(x => x.User)
                .Include(s => s.Recipient).ThenInclude(x => x.User)
                .Include(s => s.RegisteredByEmployee).ThenInclude(x => x.User)
                .Include(s => s.Courier).ThenInclude(x => x.User)
                .Include(s => s.OriginOffice)
                .Include(s => s.DestinationOffice)
                .Include(s => s.History)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (shipment == null)
                return new CustomResult(new ErrorResult($"Shipment with ID {id} not found.", ErrorCodes.ENTITY_NOT_FOUND));

            var shipmentDto = shipment.Adapt<ShipmentDto>();
            return new CustomResult<ShipmentDto>(shipmentDto);
        }

        public async Task<CustomResult> GetAll()
        {
            var shipments = await _context.Shipments
                .Include(s => s.Sender).ThenInclude(x => x.User)
                .Include(s => s.Recipient).ThenInclude(x => x.User)
                .Include(s => s.RegisteredByEmployee).ThenInclude(x => x.User)
                .Include(s => s.Courier).ThenInclude(x => x.User)
                .Include(s => s.OriginOffice)
                .Include(s => s.DestinationOffice)
                .Include(s => s.History)
                .ToListAsync();

            var shipmentDtos = shipments.Adapt<List<ShipmentDto>>();
            return new CustomResult<IEnumerable<ShipmentDto>>(shipmentDtos);
        }


        public async Task<CustomResult> Create(ShipmentDto dto)
        {
            var shipment = dto.Adapt<Shipment>();
            _context.Shipments.Add(shipment);
            await _context.SaveChangesAsync();
            return new CustomResult<Shipment>(shipment);
        }

        public async Task<CustomResult> Update(Guid id, ShipmentDto dto)
        {
            if (id != dto.Id)
                return new CustomResult(new ErrorResult("Mismatching ids", ErrorCodes.ENTITY_MISMATCH_ID));

            var shipment = await _context.Shipments.FindAsync(id);
            if (shipment == null)
                return new CustomResult(new ErrorResult("Shipment not found", ErrorCodes.ENTITY_NOT_FOUND));

            _context.Entry(shipment).CurrentValues.SetValues(dto);
            await _context.SaveChangesAsync();

            return new CustomResult<Shipment>(shipment);
        }

        public async Task<CustomResult> Delete(Guid id)
        {
            var shipment = await _context.Shipments.FindAsync(id);
            if (shipment == null)
                return new CustomResult(new ErrorResult("Shipment not found", ErrorCodes.ENTITY_NOT_FOUND));

            _context.Shipments.Remove(shipment);
            await _context.SaveChangesAsync();

            return new CustomResult<string>("Deleted successfully!");
        }
    }
}
