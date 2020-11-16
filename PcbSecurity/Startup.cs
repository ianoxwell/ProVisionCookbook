using Pcb.Security;
using Pcb.Security.Authorisation;
using Pcb.Security.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Pcb.Security
{
	/// <summary>
	/// The Security Services
	/// </summary>
	public static class Startup
	{
		/// <summary>
		/// Adds the Cpt security.
		/// </summary>
		/// <param name="services">The services.</param>
		public static void AddCptSecurityServices(this IServiceCollection services)
		{
			// Security services must be scoped to allow config changes to flow in with each new request.
			services.AddScoped<ISecurityDataRepository, SecurityDataRepository>();
			services.AddScoped<IPcbSecurityService, PcbSecurityService>();

			// Allow in-memory caching.
			services.AddMemoryCache();
		}
	}
}
