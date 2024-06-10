using AR.AspNetCore;

var builder = WebApplication.CreateBuilder();
builder.ConfigureAppWithJwt(1232, "Y2F0Y2hlciUyMsddtn134fglkjs"); //secret key for JWT Auth

var app = builder.BuildApp("Sample.Api");
app.Run();