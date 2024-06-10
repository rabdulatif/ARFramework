using Microsoft.Extensions.DependencyInjection;

namespace AR.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public class ServiceAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public Type Implement { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="implement"></param>
        public ServiceAttribute(Type implement)
        {
            Implement = implement;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="interfaceType"></param>
        public virtual void Register(IServiceCollection services, Type interfaceType)
        {
        }
    }
}
