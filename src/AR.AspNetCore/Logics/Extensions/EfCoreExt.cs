using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AR.AspNetCore;

public static class EfCoreExt
{
    public static WebApplicationBuilder AddDbContext<T>(this WebApplicationBuilder builder) where T : DbContext
    {
        builder.Services.AddDbContext<T>();
        return builder;
    }
    
    public static void UseMigrateDatabase<TContext>(this IApplicationBuilder app) where TContext : DbContext
    {
        var factory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = factory.ServiceProvider.GetService<TContext>();
        context?.Database?.Migrate(); // Add if not exists Npgsql.EntityFrameworkCore.PostgreSQL
    }
}