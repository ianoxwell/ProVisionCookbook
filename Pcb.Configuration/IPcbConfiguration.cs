using Pcb.Configuration.Models;

namespace Pcb.Configuration
{
	/// <summary>
	/// Config object must be added as scoped to the DI container for IOptionsSnapshot
	/// to work and flow config changes through to consuming services.
	/// Note that this means consuming services cannot be singletons.
	/// </summary>
	public interface IPcbConfiguration
	{
		/// <summary>
		/// Gets the iht application settings.
		/// </summary>
		/// <value>
		/// The iht application settings.
		/// </value>
		AppSettings PcbAppSettings { get; }
	}
}
