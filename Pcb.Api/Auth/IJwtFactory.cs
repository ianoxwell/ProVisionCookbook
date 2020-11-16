using System.Collections.Generic;
using System.Security.Claims;

namespace Pcb.Api.Auth
{
	/// <summary>
	/// JWT Factory Interface
	/// </summary>
	public interface IJwtFactory
	{
		/// <summary>
		/// Generates the token.
		/// </summary>
		/// <param name="claims">The claims.</param>
		/// <returns></returns>
		string GenerateToken(IEnumerable<Claim> claims);
	}
}
