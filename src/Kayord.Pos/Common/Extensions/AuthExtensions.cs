using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Kayord.Pos.Common.Extensions;

public static class AuthExtensions
{
    public static IServiceCollection ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication()
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
            {
                o.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hub"))
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
                o.Authority = configuration["Auth:ValidIssuer"];
                o.Audience = configuration["Auth:Audience"];
                o.TokenValidationParameters.ValidIssuer = configuration["Auth:ValidIssuer"];
                o.MapInboundClaims = false;
            });

        services.AddAuthorization();
        return services;
    }
}