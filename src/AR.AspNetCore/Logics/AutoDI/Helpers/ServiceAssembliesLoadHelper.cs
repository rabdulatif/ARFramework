using System.Reflection;

namespace AR.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceAssembliesLoadHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Load()
        {
            var startUpAssembly = Assembly.GetEntryAssembly();
            var referencedAssemblies = startUpAssembly.GetReferencedAssemblies().ToList();
            referencedAssemblies.ForEach(f => Assembly.Load(f));
        }
    }
}
