using LogisticsCorp.Data.Models;
using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.API.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly LogisticsCorpDbContext _context;

        public OfficeService(LogisticsCorpDbContext context)
        {
            _context = context;
        }

        public async Task<CustomResult> Get(Guid id)
        {
            var office = await _context.Offices
                .Include(o => o.Employees)
                .Include(o => o.ShipmentsFromThisOffice)
                .Include(o => o.ShipmentsToThisOffice)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (office == null)
                return new CustomResult(new ErrorResult($"Office with ID {id} not found.", ErrorCodes.ENTITY_NOT_FOUND));

            return new CustomResult<Office>(office);
        }

        public async Task<CustomResult> GetAll()
        {
            var offices = await _context.Offices
                .Include(o => o.Employees)
                .Include(o => o.ShipmentsFromThisOffice)
                .Include(o => o.ShipmentsToThisOffice)
                .ToListAsync();

            return new CustomResult<IEnumerable<Office>>(offices);
        }

        public async Task<CustomResult> Create(OfficeDto dto)
        {
            var office = dto.Adapt<Office>();
            _context.Offices.Add(office);
            await _context.SaveChangesAsync();
            return new CustomResult<Office>(office);
        }

        public async Task<CustomResult> Update(Guid id, OfficeDto dto)
        {
            if (id != dto.Id)
                return new CustomResult(new ErrorResult("Mismatching ids", ErrorCodes.ENTITY_MISMATCH_ID));

            var office = await _context.Offices.FindAsync(id);
            if (office == null)
                return new CustomResult(new ErrorResult("Office not found", ErrorCodes.ENTITY_NOT_FOUND));

            _context.Entry(office).CurrentValues.SetValues(dto);
            await _context.SaveChangesAsync();

            return new CustomResult<Office>(office);
        }

        public async Task<CustomResult> Delete(Guid id)
        {
            var office = await _context.Offices.FindAsync(id);
            if (office == null)
                return new CustomResult(new ErrorResult("Office not found", ErrorCodes.ENTITY_NOT_FOUND));

            _context.Offices.Remove(office);
            await _context.SaveChangesAsync();

            return new CustomResult<string>("Deleted successfully!");
        }
    }
}
