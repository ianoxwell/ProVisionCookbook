using Pcb.Common;
using Pcb.Dto.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pcb.Service.Interfaces
{
	/// <summary>
	/// The User Service Interface
	/// </summary>
	public interface IUserService
	{
		/// <summary>
		/// Toggles the user's active status.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <returns></returns>
		bool ToggleUserStatus(UserSummary user);

		/// <summary>
		/// Saves the User profile.
		/// </summary>
		/// <param name="rolePermissions">The role permissions.</param>
		/// <returns></returns>
		bool SaveProfile(UserProfile rolePermissions);

		/// <summary>
		/// Saves the User and associated roles.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <param name="notifyFacility">Boolean value to indicate if an email needs to be sent to the facility.</param>
		/// <param name="isRegistration">Is self-registration process.</param>
		/// <returns></returns>
		int SaveUserAndRoles(UserRoleFacility user, bool notifyFacility, bool isRegistration);

		/// <summary>
		/// Returns a user, their roles and the facilities those roles belong to.
		/// </summary>
		/// <param name="userId">The user identifier.</param>
		/// <returns></returns>
		Task<UserRoleFacility> GetAsync(int userId);

		/// <summary>
		/// Gets the user profile details asynchronously.
		/// </summary>
		/// <param name="userId">The identifier.</param>
		/// <returns></returns>
		Task<UserProfile> GetProfileAsync(int userId);

		/// <summary>
		/// Get a short paged user summary
		/// </summary>
		/// <param name="sort">property to sort on</param>
		/// <param name="order">asc or desc</param>
		/// <param name="filter">search filter applied across users name properties</param>
		/// <param name="page">the page number of the results</param>
		/// <returns></returns>
		Task<IPagedResult<UserSummary>> GetUserSummaryAsync(string sort = "createdAt", string order = "asc", string filter = "", int page = 1);

		/// <summary>
		/// Returns the list of all users in the given facility
		/// </summary>
		/// <param name="facilityId">The facility identifier.</param>
		/// <param name="includedIds">The included ids.</param>
		/// <returns></returns>
		IEnumerable<UserSummary> GetUsersInFacility(int facilityId, IEnumerable<int> includedIds = null);

		/// <summary>
		/// Returns the list of all users
		/// </summary>
		/// <returns></returns>
		IEnumerable<UserSummary> GetAllUsers();

		/// <summary>
		/// Gets the users for user search dialog box in transfer form
		/// </summary>
		/// <param name="familyName">The family name.</param>
		/// <param name="givenNames">The given names.</param>
		/// <returns></returns>
		IEnumerable<UserSummary> GetUsersForUserSearch(string familyName, string givenNames);

		/// <summary>
		/// Adds the user to facility.
		/// </summary>
		/// <param name="userId">The user identifier.</param>
		/// <param name="facilityIds">The facility identifiers.</param>
		/// <param name="roleId">The role id.</param>
		/// <returns></returns>
		Task<UserSearchResponse> AddUserToFacilityAsync(UserSummary userId, IEnumerable<int> facilityIds, int roleId);

	}
}
