namespace LogisticsCorp.API.Interfaces;

public interface IAuthService
{
    Task<CustomResult> LoginWithCredentials(LoginCredentials credentials);
}
