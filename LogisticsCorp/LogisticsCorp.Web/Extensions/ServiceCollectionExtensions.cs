﻿using MudExtensions.Services;

namespace LogisticsCorp.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        // Add UI Component Library
        builder.Services.AddMudServices(config =>
        {
            config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
            config.SnackbarConfiguration.PreventDuplicates = false;
            config.SnackbarConfiguration.NewestOnTop = false;
            config.SnackbarConfiguration.ShowCloseIcon = true;
            config.SnackbarConfiguration.HideTransitionDuration = 500;
            config.SnackbarConfiguration.ShowTransitionDuration = 500;
            config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
        });
        builder.Services.AddMudLocalization();
        builder.Services.AddMudExtensions();

        // Add Authentication and Authorization
        builder.Services.AddCascadingAuthenticationState();

        builder.Services.AddHttpClient(Constants.API_CLIENT_NAME, client =>
        {
            client.BaseAddress = new Uri(builder.Configuration.GetSection("ApiAddress").Value!);
        });

        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

        builder.Services.AddTransient<HttpClientService>();

        builder.Services.AddScoped<LoaderService>();
        builder.Services.AddScoped<UserStateContainer>();

        return builder;
    }
}
