using System;
using System.Net.Http;
using System.Threading.Tasks;
using DevTestHelperTools.Models.DI;
using DevTestHelperTools.Services.DI;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DevTestHelperTools
{
    /// <summary>
    /// Application start class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main application entry point.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            _ = builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
                                .AddModelsServices()
                                .AddServices();

            await builder.Build().RunAsync().ConfigureAwait(false);
        }
    }
}
