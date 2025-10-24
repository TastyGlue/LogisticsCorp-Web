namespace LogisticsCorp.API.Services;

public class TokenService : ITokenService
{
    private readonly JwtSettings _jwtSettings;

    public TokenService(IOptions<JwtSettings> options)
    {
        _jwtSettings = options.Value;
    }

    public CustomResult<string> GenerateAccessToken(User user)
    {
        if (!user.IsActive)
        {
            var error = new ErrorResult("Cannot generate an access token for a deactivated profile", ErrorCodes.LOGIN_INACTIVE_USER);
            return new(error);
        }

        // Create claims list for this user
        var claims = new List<Claim>()
        {
            new(Claims.USER_ID, user.Id.ToString()),
            new(Claims.USER_ID, user.Id.ToString()),
            new(Claims.FULL_NAME, user.FullName),
            new(Claims.EMAIL, user.Email!)
        };

        foreach (var role in user.Roles)
            claims.Add(new Claim(Claims.ROLE, role.Name!));

        if (user.AccountId is null)
        {
            var error = new ErrorResult("User does not have an associated account", ErrorCodes.USER_NOT_AUTHENTICATED);
            return new(error);
        }

        claims.Add(new Claim(Claims.ACCOUNT_ID, user.AccountId.ToString()!));

        string token = WriteToken(
            claims: claims, 
            expirationMinutes: _jwtSettings.AccessTokenExpirationMinutes,
            securityKey: _jwtSettings.SecurityKey

        );

        return new(token);
    }

    /// <summary>
    /// Generates a JSON Web Token (JWT) based on the provided claims and expiration time.
    /// </summary>
    /// <remarks>The generated token is signed using the HMAC-SHA256 algorithm and a symmetric security key.</remarks>
    /// <param name="claims">A list of claims to include in the token. These claims represent the identity and additional metadata of the
    /// token's subject.</param>
    /// <param name="expirationMinutes">The number of minutes until the token expires. Must be a positive integer.</param>
    /// <param name="securityKey">The security key used for signing the token.</param>
    /// <returns>A string representation of the generated JWT.</returns>
    private static string WriteToken(List<Claim> claims, int expirationMinutes, string securityKey)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(securityKey);

        // Set the key and algorithm for token signing
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(keyBytes),
            SecurityAlgorithms.HmacSha256);

        // Set the description for token creation
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(expirationMinutes),
            SigningCredentials = signingCredentials
        };

        // Create token
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(securityToken);
    }
}
