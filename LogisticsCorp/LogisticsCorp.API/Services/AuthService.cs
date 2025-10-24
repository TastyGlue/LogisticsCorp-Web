namespace LogisticsCorp.API.Services;

public class AuthService : IAuthService
{
    private readonly LogisticsCorpDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly JwtSettings _jwtSettings;
    private readonly ITokenService _tokenService;

    public AuthService(UserManager<User> userManager, ITokenService tokenService, LogisticsCorpDbContext context, IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _context = context;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<CustomResult<TokensResponse>> LoginWithCredentials(LoginCredentials credentials)
    {
        (string email, string password) = (credentials.Email, credentials.Password);

        var user = await _context.Users
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.NormalizedEmail == email.ToUpper());

        if (user is null)
        {
            var error = new ErrorResult($"Incorrect email or password", ErrorCodes.LOGIN_CREDENTIALS);
            return new(error);
        }

        if (!user.IsActive)
        {
            var error = new ErrorResult("User is not active", ErrorCodes.LOGIN_INACTIVE_USER);
            return new(error);
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);

        if (!isPasswordValid)
        {
            var error = new ErrorResult("Incorrect email or password", ErrorCodes.LOGIN_CREDENTIALS);
            return new(error);
        }

        return await GenerateTokens(user);
    }

    public async Task<CustomResult<TokensResponse>> RefreshToken(string refreshToken)
    {
        // Find refresh token in database
        var token = await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == refreshToken);

        // Check if refresh token is valid
        if (token == null)
        {
            var error = new ErrorResult("Invalid refresh token", ErrorCodes.LOGIN_FAILED);
            return new(error);
        }

        // Check if refresh token is expired
        if (DateTime.UtcNow > token.ExpireOn)
        {
            var error = new ErrorResult("Refresh token has expired", ErrorCodes.LOGIN_FAILED);
            return new(error);
        }

        var user = await _context.Users
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.Id == token.UserId);

        if (user == null)
        {
            var error = new ErrorResult("User not found", ErrorCodes.API_UNEXPECTED_ERROR);
            return new(error);
        }

        // Generate new tokens
        var tokensResult = await GenerateTokens(user);

        if (!tokensResult.Succeeded)
        {
            // Remove old refresh token from database
            _context.RefreshTokens.Remove(token);

            await _context.SaveChangesAsync();
        }

        return tokensResult;
    }

    /// <summary>
    /// Generates access and refresh tokens for the specified user.
    /// </summary>
    /// <remarks>This method requires the user to have at least one role assigned. It generates an access
    /// token and a refresh token, and saves the refresh token to the database. If the user has no roles or if token
    /// generation fails, an error result is returned.</remarks>
    /// <param name="user">The user for whom the tokens are generated. The user must have at least one role assigned.</param>
    /// <returns>A <see cref="CustomResult{TokensResponse}"/> containing the generated tokens if successful; otherwise, an error
    /// result.</returns>
    private async Task<CustomResult<TokensResponse>> GenerateTokens(User user)
    {
        // Get user role
        if (user.Roles.Count == 0)
        {
            var error = new ErrorResult("User does not have a role assigned", ErrorCodes.USER_NOT_AUTHENTICATED);
            return new(error);
        }

        var roles = user.Roles.Select(x => x.NormalizedName!).ToList();

        // Generate tokens
        var accessTokenResult = _tokenService.GenerateAccessToken(user);
        if (!accessTokenResult.Succeeded)
        {
            var error = accessTokenResult.Error!;
            return new(error);
        }
        string accessToken = accessTokenResult.Value;

        string refreshToken = _tokenService.GenerateRefreshToken();

        await SaveRefreshTokenToDb(user.Id, refreshToken);

        var tokensResponse = new TokensResponse(accessToken, refreshToken);
        return new(tokensResponse);
    }

    private async Task SaveRefreshTokenToDb(Guid userId, string refreshToken)
    {
        // Add refresh token to database
        _context.RefreshTokens.Add(new()
        {
            UserId = userId,
            Token = refreshToken,
            ExpireOn = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationDays)
        });

        await _context.SaveChangesAsync();
    }
}
