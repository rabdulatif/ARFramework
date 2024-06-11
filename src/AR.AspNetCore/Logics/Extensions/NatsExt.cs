using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NATS.Client;

namespace AR.AspNetCore;

public static class NatsExt
{
    public static WebApplicationBuilder AddNatsHub(this WebApplicationBuilder builder, string natsUrl, string login,
        string pass)
    {
        var options = ConnectionFactory.GetDefaultOptions();

        options.Servers = new string[]
        {
            natsUrl
        };
        options.Password = pass;
        options.User = login;
        var connection = new ConnectionFactory().CreateConnection(options);
        builder.Services.AddSingleton<IConnection>(connection);
        return builder;
    }
}