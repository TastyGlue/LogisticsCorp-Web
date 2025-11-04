namespace LogisticsCorp.API.Services
{
    public class ClientService : IClientService
    {
        private readonly LogisticsCorpDbContext _context;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public ClientService(LogisticsCorpDbContext context, IUserService userService, UserManager<User> userManager)
        {
            _context = context;
            _userService = userService;
            _userManager = userManager;
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

        public async Task<CustomResult> Create(User user, Client client, string? password = null)
        {
            // Create User
            var createUser = await _userManager.CreateAsync(user, password ?? Constants.DEFAULT_PASSWORD);
            if (!createUser.Succeeded)
            {
                var errors = string.Join(", ", createUser.Errors.Select(e => e.Description));
                return new(new ErrorResult(errors, ErrorCodes.USER_CREATE_FAILED));
            }

            // Get new created User
            var newUser = await _userManager.FindByEmailAsync(user.Email!);

            // Add User to CLIENT role
            var addToRoleResult = await _userService.AddUserToRole(newUser!.Id, SeedConstants.ROLE_CLIENT_NAME, overwriteExisting: true);
            if (!addToRoleResult.Succeeded)
            {
                await _userManager.DeleteAsync(newUser);
                return addToRoleResult;
            }

            // Set new User's password
            var token = await _userManager.GeneratePasswordResetTokenAsync(newUser!);
            var resetResult = await _userManager.ResetPasswordAsync(newUser!, token, password ?? Constants.DEFAULT_PASSWORD);
            if (!resetResult.Succeeded)
            {
                var errors = string.Join(", ", resetResult.Errors.Select(e => e.Description));
                Log.Error($"Failed to reset password for user '{user.UserName}': {errors}");
            }

            // Create Client linked to the new User
            client.UserId = newUser!.Id;
            client.User = null!; // Avoid EF Core trying to insert the User again
            await _context.Clients.AddAsync(client);

            try
            {
                await _context.SaveChangesAsync();

                newUser.AccountId = client.Id;
                await _userManager.UpdateAsync(newUser);
            }
            catch (Exception)
            {
                await _userManager.DeleteAsync(newUser);
                throw;
            }

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
