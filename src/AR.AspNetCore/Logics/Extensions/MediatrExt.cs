using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AR.AspNetCore;

public static class MediatrExt
{
    public static WebApplicationBuilder AddSystemMediator(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediator(m => { m.ServiceLifetime = ServiceLifetime.Scoped; });
        return builder;
    }
}