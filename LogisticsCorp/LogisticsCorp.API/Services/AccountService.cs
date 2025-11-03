using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly LogisticsCorpDbContext _context;

        public AccountService(LogisticsCorpDbContext context)
        {
            _context = context;
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
            var account = dto.Adapt<Account>();
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
