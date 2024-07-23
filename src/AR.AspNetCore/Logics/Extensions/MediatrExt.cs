using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AR.AspNetCore;

public static class MediatrExt
{
    public static WebApplicationBuilder AddSystemMediator<T>(this WebApplicationBuilder builder) where T : class
    {
        builder.Services.AddMediatR(m =>
        {
            m.RegisterServicesFromAssemblies(typeof(T).Assembly);
        });
        return builder;
    }
}