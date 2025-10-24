using LogisticsCorp.API.Handlers;
using LogisticsCorp.API.Seeders;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace LogisticsCorp.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterLogisticsCorpServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.Lockout.MaxFailedAccessAttempts = 0;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
            options.User.RequireUniqueEmail = true;
        })
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<LogisticsCorpDbContext>()
            .AddDefaultTokenProviders();

        builder.Services.AddDbContext<LogisticsCorpDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

        builder.Services.AddApplicationServices();

        builder.Services.AddDataSeeders();

        builder.Services.AddSingleton<IAuthorizationMiddlewareResultHandler, CustomAuthorizationMiddlewareResultHandler>();

        return services;
    }

    private static IServiceCollection AddDataSeeders(this IServiceCollection services)
    {
        services.AddTransient<IDataSeeder, RoleSeeder>();
        services.AddTransient<IDataSeeder, OfficeSeeder>();
        services.AddTransient<IDataSeeder, PricingRuleSeeder>();
        services.AddTransient<IDataSeeder, EmployeeSeeder>();
        services.AddTransient<IDataSeeder, ClientSeeder>();
        services.AddTransient<IDataSeeder, ShipmentSeeder>();
        services.AddTransient<IDataSeeder, ShipmentHistorySeeder>();

        return services;
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<ITokenService, TokenService>();

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }

    private static readonly JwtBearerEvents CustomAuthFailureEvent = new()
    {
        OnChallenge = context =>
        {
            context.HandleResponse();

            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";

            var response = new ErrorResult("Request is not authenticated", ErrorCodes.ACCESS_NOT_AUTHENTICATED);

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    };
}
