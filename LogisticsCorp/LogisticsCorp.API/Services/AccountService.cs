using LogisticsCorp.Shared.Models.DTOs;
using MapsterMapper;

namespace LogisticsCorp.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly LogisticsCorpDbContext _context;
        private readonly IMapper _mapper;

        public AccountService(LogisticsCorpDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomResult> Get(Guid id)
        {
            var account = await _context.Accounts
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (account == null)
                return new CustomResult(new ErrorResult($"Account with ID {id} not found.", ErrorCodes.ENTITY_NOT_FOUND));

            return new CustomResult<Account>(account);
        }

        public async Task<CustomResult> GetAll()
        {
            var accounts = await _context.Accounts
                .Include(a => a.User)
                .ToListAsync();

            return new CustomResult<IEnumerable<Account>>(accounts);
        }

        public async Task<CustomResult> Create(AccountDto dto)
        {
            var account = _mapper.Map<Account>(dto);
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return new CustomResult<Account>(account);
        }

        public async Task<CustomResult> Update(Guid id, AccountDto dto)
        {
            if (id != dto.Id)
                return new CustomResult(new ErrorResult("Mismatching ids", ErrorCodes.ENTITY_MISMATCH_ID));

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
                return new CustomResult(new ErrorResult("Account not found", ErrorCodes.ENTITY_NOT_FOUND));

            _context.Entry(account).CurrentValues.SetValues(dto);
            await _context.SaveChangesAsync();

            return new CustomResult<Account>(account);
        }

        public async Task<CustomResult> Delete(Guid id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
                return new CustomResult(new ErrorResult("Account not found", ErrorCodes.ENTITY_NOT_FOUND));

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return new CustomResult<string>("Deleted successfully!");
        }
    }
}
