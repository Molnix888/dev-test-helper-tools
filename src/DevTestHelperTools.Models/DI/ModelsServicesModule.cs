using Microsoft.Extensions.DependencyInjection;

namespace DevTestHelperTools.Models.DI
{
    /// <summary>
    /// Provides services module for Models.
    /// </summary>
    public static class ModelsServicesModule
    {
        /// <summary>
        /// Adds Models services to service descriptors.
        /// </summary>
        /// <param name="service">ServiceCollection instance.</param>
        /// <returns>Reference to ServiceCollection instance.</returns>
        public static IServiceCollection AddModelsServices(this IServiceCollection service) => service
            .AddBase64ModelService()
            .AddHashModelService();

        /// <summary>
        /// Adds Base64Model service to service descriptors.
        /// </summary>
        /// <param name="service">ServiceCollection instance.</param>
        /// <returns>Reference to ServiceCollection instance.</returns>
        public static IServiceCollection AddBase64ModelService(this IServiceCollection service) => service.AddTransient<Base64Model>();

        /// <summary>
        /// Adds HashModel service to service descriptors.
        /// </summary>
        /// <param name="service">ServiceCollection instance.</param>
        /// <returns>Reference to ServiceCollection instance.</returns>
        public static IServiceCollection AddHashModelService(this IServiceCollection service) => service.AddTransient<HashModel>();
    }
}
