using System.Reflection;
using AR.AspNetCore.Logics.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace AR.AspNetCore;

public static class StartupExt
{
    public static WebApplicationBuilder ConfigureAppWithJwt(this WebApplicationBuilder builder, int port,
        string secretKey)
    {
        builder.RunPort(port)
            .AddDefaultConfigureServices(secretKey);

        return builder;
    }

    public static WebApplication BuildApp(this WebApplicationBuilder builder, string serviceName)
    {
        var app = builder.Build();
        app.UseDeveloperExceptionPage();
        app.UseDefaultConfiguration(serviceName);
        return app;
    }

    private static WebApplicationBuilder AddDefaultConfigureServices(this WebApplicationBuilder builder,
        string secretKey)
    {
        builder.Services.AddApiCors();
        builder.Services.AddJwtAuth(secretKey);
        builder.Services.AddControllers().AddNewtonsoftJson(x =>
            x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

        builder.Services.AddAutoDI();
        builder.Services.AddApiSwagger("v1");
        builder.Services.AddHttpContextAccessor();

        return builder;
    }

    public static WebApplication UseDefaultConfiguration(this WebApplication app, string serviceName)
    {
        if (app.Environment.IsDevelopment())
            app.UseDeveloperExceptionPage();


        app.UseLanguageMiddleware();
        app.UseErrorHandlingMiddleware();
        app.UseAuthentication();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{serviceName.ToUpper()} SERVICE API V1");
        });

        app.UseRouting();
        app.UseApiCors();
        app.MapControllers();
        app.UseAuthorization();

        if (app.Services.GetService<IHttpContextAccessor>() != null)
            HttpContextHelper.Accessor = app.Services.GetRequiredService<IHttpContextAccessor>();

        return app;
    }
}