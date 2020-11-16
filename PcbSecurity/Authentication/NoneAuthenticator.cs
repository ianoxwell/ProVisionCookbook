using Pcb.Configuration;
using Pcb.Security.Authorisation;
using Pcb.Dto.Security;
using Microsoft.Extensions.Logging;

namespace Pcb.Security.Authentication
{
	/// <inheritdoc cref="IAuthenticator" />
	internal class NoneAuthenticator : AuthenticatorBase, IAuthenticator
	{
		/// <inheritdoc cref="IAuthenticator" />
		public NoneAuthenticator(IPcbConfiguration config, ILogger<PcbSecurityService> logger)
			: base(config, logger)
		{
		}

		/// <inheritdoc />
		public bool Authenticate(string username, string password)
		{
			Logger.LogWarning($"Please note: User Authentication is set to None. Users are not currently authenticated at login.");
			return IsUsernameAndPasswordValid(username, password);
		}

	}
}
