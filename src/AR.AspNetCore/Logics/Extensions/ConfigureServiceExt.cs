using AR.AspNetCore.Logics.Helpers.Errors;
using AR.AspNetCore.Logics.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace AR.AspNetCore;

public static class ConfigureServiceExt
{
    public static WebApplication UseApiSwagger(this WebApplication app, string serviceName)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{serviceName.ToUpper()} SERVICE API V1");
        });

        return app;
    }
    
    public static WebApplication UseApiCors(this WebApplication app)
    {
        app.UseCors("AllowCors");
        // app.UseCors(s => s
        //     .AllowAnyMethod()
        //     .AllowAnyHeader()
        //     .SetIsOriginAllowed(origin => true)
        //     .AllowCredentials());
            
        return app;
    }

    public static WebApplication UseLanguageMiddleware(this WebApplication app)
    {
        app.UseMiddleware<LanguageMiddleware>();
        return app;
    }

    public static WebApplication UseErrorHandlingMiddleware(this WebApplication app)
    {
        app.UseMiddleware<ErrorHandlingMiddleware>();
        return app;
    }

    public static WebApplication UseErrors<T>(this WebApplication app) where T : Enum
    {
        var errorMigrator = new ErrorsMigrator<T>();
        errorMigrator.Migrate();
        return app;
    }
}