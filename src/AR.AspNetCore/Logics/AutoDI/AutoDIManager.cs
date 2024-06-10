using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace AR.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public static class AutoDIManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void Init(IServiceCollection services)
        {
            ServiceAssembliesLoadHelper.Load();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(s => s.GetTypes());

            var interfaces = types.Where(w => w.IsInterface).ToList();
            interfaces.ForEach(f => InitInterfaces(f, services));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="services"></param>
        private static void InitInterfaces(Type type, IServiceCollection services)
        {
            var attr = type?.GetCustomAttribute<ServiceAttribute>();
            attr?.Register(services, type);
        }
    }
}
