using Pcb.Dto.Security;

namespace Pcb.Security.Authentication
{
	/// <summary>
	/// The Authenticator Interface
	/// </summary>
	public interface IAuthenticator
	{
		/// <summary>
		/// Returns true if the username and password combination can be authenticated
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		bool Authenticate(string username, string password);
	}
}
