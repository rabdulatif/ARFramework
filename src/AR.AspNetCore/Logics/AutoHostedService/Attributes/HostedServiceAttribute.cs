using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace AR.AspNetCore.Logics.AutoHostedService.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class HostedServiceAttribute(Type implement) : Attribute
{
    public void Register(WebApplicationBuilder builder, Type type)
    {
        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton(typeof(IHostedService), type));
    }
}