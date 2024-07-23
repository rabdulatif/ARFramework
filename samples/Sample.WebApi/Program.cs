using AR.AspNetCore;
using AR.AspNetCore.Logics.AutoHostedService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
builder
    .ConfigureAppWithJwt(8091, "Config.SecretKey")
    .AddDbContext<DbContext>()
    // .AddSystemMediator()
    .AddAutoHostedServices()
    .AddNatsHub("Config.NatsUrl", "Config.NatsUser", "Config.NatsPass");


var app = builder.BuildApp("Management.Api");
// app.UseErrors<Errors>();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.UseMigrateDatabase<DbContext>();

// DefaultUser.Seed();

app.Run();