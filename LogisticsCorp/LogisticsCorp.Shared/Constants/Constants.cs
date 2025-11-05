namespace LogisticsCorp.Shared.Constants;

public static class Constants
{
    public const string DEFAULT_PASSWORD = "P@ssw0rd";

    public const string API_CLIENT_NAME = "LogisticsCorpAPIClient";

    public const string ACCESS_TOKEN_KEY = "accessToken";

    public const string REFRESH_TOKEN_KEY = "refreshToken";

    public const string EMAIL_FORMAT_REGEX = @"^[a-zA-Z0-9._%±]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$";

    public const string PHONE_FORMAT_REGEX = @"^\+?\d{3}[- .]?\d{3}[- .]?\d{4}$";
}
