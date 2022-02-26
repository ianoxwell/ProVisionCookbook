using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Pcb.Database.Context.Models;
using Pcb.Dto.Security;

[assembly: InternalsVisibleTo("Pcb.Security.Tests")]

namespace Pcb.Security.Data
{
	/// <summary>
	/// The security data repository interface
	/// </summary>
	internal interface ISecurityDataRepository
	{
		/// <summary>
		/// Gets the user.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <returns></returns>
		User GetUser(string username);

		/// <summary>
		/// Gets the authenticated user.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <returns></returns>
		IAuthenticatedUser GetAuthenticatedUser(string username);

		/// <summary>
		/// Gets the permissions.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="facilityId">The facility identifier.</param>
		/// <returns></returns>
		IEnumerable<Permission> GetPermissions(string username, int? facilityId = null);

		/// <summary>
		/// Increments the number of times the user has logged on and sets last login.
		/// Additional if the first login is not set (prior date to start of 2020)
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		Task<bool> IncrementLoginValues(int userId = 0);
	}
}
