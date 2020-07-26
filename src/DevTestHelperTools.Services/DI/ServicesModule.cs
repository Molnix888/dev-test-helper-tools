using DevTestHelperTools.Services.Abstraction;
using DevTestHelperTools.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace DevTestHelperTools.Services.DI
{
    /// <summary>
    /// Provides services module for Services.
    /// </summary>
    public static class ServicesModule
    {
        /// <summary>
        /// Adds Services services to service descriptors.
        /// </summary>
        /// <param name="service">ServiceCollection instance.</param>
        /// <returns>Reference to ServiceCollection instance.</returns>
        public static IServiceCollection AddServices(this IServiceCollection service) => service
            .AddBase64Service()
            .AddHashService();

        /// <summary>
        /// Adds Base64Service service to service descriptors.
        /// </summary>
        /// <param name="service">ServiceCollection instance.</param>
        /// <returns>Reference to ServiceCollection instance.</returns>
        public static IServiceCollection AddBase64Service(this IServiceCollection service) => service.AddSingleton<IBase64Service, Base64Service>();

        /// <summary>
        /// Adds HashService service to service descriptors.
        /// </summary>
        /// <param name="service">ServiceCollection instance.</param>
        /// <returns>Reference to ServiceCollection instance.</returns>
        public static IServiceCollection AddHashService(this IServiceCollection service) => service.AddSingleton<IHashService, HashService>();
    }
}
