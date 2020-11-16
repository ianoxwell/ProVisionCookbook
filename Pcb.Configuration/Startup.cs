
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pcb.Configuration.Models;

namespace Pcb.Configuration
{
    public static class Startup
    {
        /// <summary>
        /// Adds the Pcb configuration.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void AddPcbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // Allow us to access strongly typed config data
            services.AddOptions();
            services.Configure<AppSettings>(options => configuration.GetSection("PcbAppSettings").Bind(options));
            services.Configure<ConnectionStrings>(options => configuration.GetSection("ConnectionStrings").Bind(options));

            // Must be scoped to allow config file updates to be read into the app while running.
            services.AddScoped<IPcbConfiguration, PcbConfiguration>();
        }
    }
}
