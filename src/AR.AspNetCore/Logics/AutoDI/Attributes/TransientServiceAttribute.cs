using Microsoft.Extensions.DependencyInjection;

namespace AR.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public class TransientServiceAttribute : ServiceAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="implement"></param>
        public TransientServiceAttribute(Type implement) : base(implement)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="interfaceType"></param>
        public override void Register(IServiceCollection services, Type interfaceType)
        {
            services.AddTransient(interfaceType, Implement);
        }
    }
}
