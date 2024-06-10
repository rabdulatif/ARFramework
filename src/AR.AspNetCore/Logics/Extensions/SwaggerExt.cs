using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AR.AspNetCore;

public static class SwaggerExt
{
    public static IServiceCollection AddApiSwagger(this IServiceCollection services, string version, bool useJwt = true)
    {
        services.AddSwaggerGen(options =>
        {
            AddSwaggerDoc(options, version);
            if (useJwt)
            {
                AddJwtSecurityBearer(options);
                AddJwtSecurityRequirement(options);
            }

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });

        return services;
    }

    private static void AddSwaggerDoc(SwaggerGenOptions swaggerGenOptions, string version)
    {
        swaggerGenOptions.SwaggerDoc(version, new OpenApiInfo
        {
            Version = version,
            Title = "API"
        });
    }

    private static void AddJwtSecurityBearer(SwaggerGenOptions swaggerGenOptions)
    {
        swaggerGenOptions.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
        {
            Description =
                "Заголовок авторизации JWT с использованием схемы Bearer. Пример: \"Bearer { token }\"",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = JwtBearerDefaults.AuthenticationScheme
        });
    }

    private static void AddJwtSecurityRequirement(SwaggerGenOptions swaggerGenOptions)
    {
        swaggerGenOptions.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = JwtBearerDefaults.AuthenticationScheme
                    }
                },
                new string[] { }
            }
        });
    }
}