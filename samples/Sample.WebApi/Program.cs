using AR.AspNetCore;
using AR.AspNetCore.Logics.AutoHostedService;

var builder = WebApplication.CreateBuilder();
builder
    .ConfigureAppWithJwt(8091, "Config.SecretKey")
    //.AddDbContext<ManagementDbContext>()
    .AddSystemMediator()
    .AddAutoHostedServices()
    .AddNatsHub("Config.NatsUrl", "Config.NatsUser", "Config.NatsPass");

var app = builder.BuildApp("Management.Api");
// AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.Run();