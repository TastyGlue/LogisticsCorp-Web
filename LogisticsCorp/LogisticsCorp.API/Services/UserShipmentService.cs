namespace LogisticsCorp.API.Services
{
    public class UserShipmentService : IUserShipmentService
    {
        private readonly LogisticsCorpDbContext _context;

        public UserShipmentService(LogisticsCorpDbContext context)
        {
            _context = context;
        }
        public async Task<CustomResult> GetAll(Guid id)
        {
            var shipments = await _context.Shipments.Where(x => x.SenderId == id || x.RecipientId == id).ToListAsync();

            return new CustomResult<IEnumerable<Shipment>>(shipments);
        }
    }
}
