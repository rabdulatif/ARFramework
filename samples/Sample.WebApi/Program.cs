using AR.AspNetCore;
using AR.AspNetCore.Logics.AutoHostedService;
using Microsoft.EntityFrameworkCore;
using Sample.WebApi.Models.Enums;

var builder = WebApplication.CreateBuilder();
builder
    .ConfigureAppWithJwt(8091, "Config.SecretKey")
    // .AddDbContext<DbContext>()
    .AddSystemMediator<Program>()
    .AddAutoHostedServices()
    .AddNatsHub("Config.NatsUrl", "Config.NatsUser", "Config.NatsPass");


var app = builder.BuildApp("Management.Api");
app.UseErrors<Errors>();
// AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); //To write DateTime on postgresql

// app.UseMigrateDatabase<DbContext>(); //AutoMigration

app.Run();