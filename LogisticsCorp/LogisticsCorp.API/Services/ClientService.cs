using LogisticsCorp.Shared.Models.DTOs;
using MapsterMapper;

namespace LogisticsCorp.API.Services
{
    public class ClientService : IClientService
    {
        private readonly LogisticsCorpDbContext _context;

        public ClientService(LogisticsCorpDbContext context)
        {
            _context = context;
        }

        public async Task<CustomResult> Get(Guid id)
        {
            var client = await _context.Clients
                .Include(c => c.SentShipments)
                .Include(c => c.ReceivedShipments)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
                return new CustomResult(new ErrorResult($"Client with ID {id} not found.", ErrorCodes.ENTITY_NOT_FOUND));

            return new CustomResult<Client>(client);
        }

        public async Task<CustomResult> GetAll()
        {
            var clients = await _context.Clients
                .Include(c => c.User)
                .Include(c => c.SentShipments)
                .Include(c => c.ReceivedShipments)
                .ToListAsync();

            return new CustomResult<IEnumerable<Client>>(clients);
        }

        public async Task<CustomResult> Create(ClientDto dto)
        {
            var client = dto.Adapt<Client>();
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return new CustomResult<Client>(client);
        }

        public async Task<CustomResult> Update(Guid id, ClientDto dto)
        {
            if (id != dto.Id)
                return new CustomResult(new ErrorResult("Mismatching ids", ErrorCodes.ENTITY_MISMATCH_ID));

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
                return new CustomResult(new ErrorResult("Client not found", ErrorCodes.ENTITY_NOT_FOUND));

            _context.Entry(client).CurrentValues.SetValues(dto);
            await _context.SaveChangesAsync();

            return new CustomResult<Client>(client);
        }

        public async Task<CustomResult> Delete(Guid id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
                return new CustomResult(new ErrorResult("Client not found", ErrorCodes.ENTITY_NOT_FOUND));

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return new CustomResult<string>("Deleted successfully!");
        }
    }
}
