using Pcb.Configuration;
using Pcb.Security.Authorisation;
using Microsoft.Extensions.Logging;

namespace Pcb.Security.Authentication
{
	/// <summary>
	/// The Authenticator Base
	/// </summary>
	internal class AuthenticatorBase
	{
		/// <summary>
		/// Gets or sets the configuration.
		/// </summary>
		/// <value>
		/// The configuration.
		/// </value>
		protected IPcbConfiguration Config { get; set; }

		/// <summary>
		/// Gets or sets the logger.
		/// </summary>
		/// <value>
		/// The logger.
		/// </value>
		protected ILogger<PcbSecurityService> Logger { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AuthenticatorBase"/> class.
		/// </summary>
		/// <param name="config">The configuration.</param>
		/// <param name="logger">The logger.</param>
		protected AuthenticatorBase(IPcbConfiguration config, ILogger<PcbSecurityService> logger)
		{
			Config = config;
			Logger = logger;
		}

		/// <summary>
		/// Basic validation of minimum username and password lengths and other validations before
		/// any call to external service or database is required.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <returns>
		/// True if username and password are valid.
		/// </returns>
		protected bool IsUsernameAndPasswordValid(string username, string password)
		{
			// Don't accept null or whitespace user-names and passwords.
			if (string.IsNullOrWhiteSpace(username))
			{
				return false;
			}

			if (string.IsNullOrWhiteSpace(password))
			{
				return false;
			}

			if (username.Length < Config.PcbAppSettings.SecuritySettings.MinimumUsernameLength)
			{
				return false;
			}

			if (password.Length < Config.PcbAppSettings.SecuritySettings.MinimumPasswordLength)
			{
				return false;
			}

			return true;
		}
	}
}
