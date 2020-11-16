using Pcb.Dto.Security;
using System.Collections.Generic;

namespace Pcb.Service.Interfaces
{
	/// <summary>
	/// The Security Service Interface
	/// </summary>
	public interface ISecurityService
	{
		/// <summary>
		/// save the role permissions assignments.
		/// </summary>
		/// <param name="rolePermissions">The role permissions.</param>
		/// <returns></returns>
		bool SaveRolePermissions(SavingRoles rolePermissions);

		/// <summary>
		/// Gets the role permissions asynchronous.
		/// </summary>
		/// <returns></returns>
		RoleManagement GetRolePermissions();

		/// <summary>
		/// Gets the Active Roles only
		/// </summary>
		/// <returns></returns>
		IEnumerable<RoleSummary> GetActiveRoles();

		/// <summary>
		/// Generates the refresh token used to reissue expired access tokens.
		/// </summary>
		/// <param name="username">Name of the user.</param>
		/// <param name="refreshToken">The refresh token.</param>
		/// <param name="isReissuing">if set to <c>true</c> [is reissuing].</param>
		/// <param name="ipAddress">IP address of request</param>
		/// <returns></returns>
		string GenerateRefreshToken(string username, string ipAddress = "127.0.0.1", string refreshToken = "", bool isReissuing = false);

		/// <summary>
		/// Determines whether [is refresh token valid] [the specified user name].
		/// </summary>
		/// <param name="username">Name of the user.</param>
		/// <param name="refreshToken">The refresh token.</param>
		/// <returns>
		///   <c>true</c> if [is refresh token valid] [the specified user name]; otherwise, <c>false</c>.
		/// </returns>
		bool IsRefreshTokenValid(string username, string refreshToken);

		/// <summary>
		/// Hangfire job: Purges the old event logs.
		/// </summary>
		void PurgeOldEventLogs();

		/// <summary>
		/// return boolean value to indicate if the logged in user can edit acontext user
		/// </summary>
		/// <param name="currentUserId">currentUserId</param>
		/// <param name="contextUserId">contextUserId</param>
		/// <returns></returns>
		bool CanEditUser(string currentUserId, string contextUserId);

		/// <summary>
		/// Gets the Active Roles for a user in a facility
		/// </summary>
		/// /// <param name="currentUserId">currentUserId</param>
		/// <param name="facilityId">contextUserId</param>
		/// <returns></returns>
		string GetUserRoleForPostion(int currentUserId, int? facilityId);

		/// <summary>
		/// Increment failed password or reset
		/// </summary>
		/// <param name="email"></param>
		/// <param name="reset"></param>
		void FailedPasswordAttempt(string email, bool reset = false);
	}
}
