using System.Reflection;
using AR.AspNetCore.Logics.AutoHostedService.Attributes;
using Microsoft.AspNetCore.Builder;

namespace AR.AspNetCore.Logics.AutoHostedService;

public static class AutoHostedServiceManager
{
    public static WebApplicationBuilder AddAutoHostedServices(this WebApplicationBuilder builder)
    {
        ServiceAssembliesLoadHelper.Load();
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var types = assemblies.SelectMany(s => s.GetTypes());

        var interfaces = types.Where(w => w.IsClass).ToList();
        interfaces.ForEach(f => InitServices(f, builder));
        
        return builder;
    }

    private static void InitServices(Type type, WebApplicationBuilder builder)
    {
        var attr = type?.GetCustomAttribute<HostedServiceAttribute>();
        attr?.Register(builder, type);
    }
}