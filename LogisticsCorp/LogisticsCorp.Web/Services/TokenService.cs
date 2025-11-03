namespace LogisticsCorp.Web.Services;

public class TokenService
{
    private readonly ProtectedLocalStorage _localStorage;
    private readonly NavigationManager _navigationManager;

    public TokenService(ProtectedLocalStorage localStorage, NavigationManager navigationManager)
    {
        _localStorage = localStorage;
        _navigationManager = navigationManager;
    }

    public async Task<string> GetToken(string tokenKey = Constants.ACCESS_TOKEN_KEY, bool navigateOnMissingToken = true)
    {
        var token = (await _localStorage.GetAsync<string>(tokenKey)).Value;
        if (token is null)
        {
            if (navigateOnMissingToken)
            {
                _navigationManager.NavigateTo("/login", forceLoad: true);
            }

            return string.Empty;
        }

        return token;
    }
}
