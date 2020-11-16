using System.Runtime.CompilerServices;
using Pcb.Configuration.Models;
using Microsoft.Extensions.Options;

[assembly: InternalsVisibleTo("Pcb.Configuration.Tests")]

namespace Pcb.Configuration
{
	/// <inheritdoc />
	internal class PcbConfiguration : IPcbConfiguration
	{
		/// <inheritdoc />
		public AppSettings PcbAppSettings { get; }

		/// <summary>
		/// Note options snapshot to allow appsettings.json changes to flow in while the app is running.
		/// </summary>
		/// <param name="PcbAppSettings">The Pcb application settings.</param>
		/// <param name="connectionStrings">The connection strings.</param>
		public PcbConfiguration(IOptionsSnapshot<AppSettings> pcbAppSettings, IOptionsSnapshot<ConnectionStrings> connectionStrings)
		{
			PcbAppSettings = pcbAppSettings.Value;
			PcbAppSettings.ConnectionStrings = connectionStrings.Value;
		}
	}
}
