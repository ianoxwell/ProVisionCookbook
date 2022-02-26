using Pcb.Dto.Security;
using System.Collections.Generic;
using System.Security.Claims;

namespace Pcb.Security
{
	/// <summary>
	/// The Security Service Interface
	/// </summary>
	public interface IPcbSecurityService
	{
		/// <summary>
		/// Authenticate a user with username and password.
		/// </summary>
		/// <param name="username">the user's username</param>
		/// <param name="password">the user's password</param>
		/// <returns>A list of claims if successfully authenticated otherwise empty list.</returns>
		IEnumerable<Claim> Authenticate(string username, string password, bool isSocial);

		/// <summary>
		/// Is the current authenticated user authorised for a particular security permission.
		/// </summary>
		/// <param name="permission">the security permission that which authorisation will be checked</param>
		/// <param name="facilityId">the facility the security permission will be checked against</param>
		/// <param name="username">Optional, will use the logged in user if none provided.</param>
		/// <returns></returns>
		bool IsAuthorised(SecurityPermission permission, int? facilityId = null, string username = null);

		/// <summary>
		/// Is the user authorised for the permission in at least one network
		/// </summary>
		/// <param name="permission">The subject of authorisation</param>
		/// <param name="username">Optional, will use the logged in user if none provided.</param>
		/// <returns></returns>
		bool IsAuthorisedInAnyFacility(SecurityPermission permission, string username = null);

		/// <summary>
		/// Checks the authorisation in any one facility.
		/// </summary>
		/// <param name="permission">The permission.</param>
		/// <param name="facilityIds">The facility ids.</param>
		void CheckAuthorisationInAnyOneFacility(SecurityPermission permission, int?[] facilityIds);

		/// <summary>
		/// Returns the facilities the user is explicity authorised for. Permissions that belong to
		/// a facility wide user role will be ignored. An empty array returned means no facilities have
		/// been explicitly assigned.
		/// It is assumed you have already checked the facility wide flag before calling this method.
		/// </summary>
		/// <param name="permission">The subject of authorisation</param>
		/// <param name="username">Optional, will use the logged in user if none provided.</param>
		/// <returns></returns>
		IEnumerable<int> GetExplicitlyAuthorisedFacilities(SecurityPermission permission, string username = null);

		/// <summary>
		/// Is the permission authorised facility wide
		/// </summary>
		/// <param name="permission">The subject of authorisation</param>
		/// <param name="username">Optional, will use the logged in user if none provided.</param>
		/// <returns></returns>
		bool IsAuthorisedFacilityWide(SecurityPermission permission, string username = null);

		/// <summary>
		/// Gets the authenticated user.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		IAuthenticatedUser GetAuthenticatedUser(string name = null);

		/// <summary>
		/// Creates the user claims.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <returns></returns>
		IEnumerable<Claim> CreateUserClaims(string username);
		string GetTokenUserIdValue();
	}
}
