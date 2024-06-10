using System.Text;
using AR.AspNetCore.Logics.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AR.AspNetCore;

public static class ServiceCollectionExt
{
    /// <summary>
    /// Runs application in specific port
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="port"></param>
    /// <returns></returns>
    public static WebApplicationBuilder RunPort(this WebApplicationBuilder builder, int port)
    {
        builder.WebHost.UseKestrel(option =>
        {
            option.ListenAnyIP(port,
                listenOption => { listenOption.Protocols = HttpProtocols.Http1AndHttp2AndHttp3; });
        });

        return builder;
    }
    
    /// <summary>
    /// Allows any method, header
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddApiCors(this IServiceCollection services)
    {
        services.AddCors(
            options => options.AddPolicy("AllowCors",
                builder =>
                {
                    builder
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .SetIsOriginAllowed(host => true)
                        .AllowAnyHeader();
                })
        );

        return services;
    }
    
    public static IServiceCollection AddAutoDI(this IServiceCollection services)
    {
        AutoDIManager.Init(services);
        return services;
    }
    
    public static IServiceCollection AddJwtAuth(this IServiceCollection services, string secretKey)
    {
        var keyByteArray = Encoding.ASCII.GetBytes(secretKey);
        var signingKey = new SymmetricSecurityKey(keyByteArray);

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = signingKey,

            ValidateIssuer = true,
            ValidIssuer = AuthHelper.PARAM_ISS,

            ValidateAudience = true,
            ValidAudience = AuthHelper.PARAM_AUD,

            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o => { o.TokenValidationParameters = tokenValidationParameters; });

        return services;
    }
}