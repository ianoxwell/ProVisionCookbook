using Microsoft.Extensions.Logging;
using Pcb.Common;
using Pcb.Configuration;
using Pcb.Database;
using Pcb.Database.Context;
using Pcb.Database.Context.Models;
using Pcb.Dto.Security;
using Pcb.Security;
using Pcb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pcb.Service.Implementations
{
	/// <inheritdoc cref="ISecurityService" />
	internal class SecurityService : ServiceBase<PcbDbContext>, ISecurityService
	{
		private IPcbSecurityService Security { get; }
		private IPcbConfiguration Config;

		/// <inheritdoc cref="ISecurityService" />
		public SecurityService(
			IPcbSecurityService securityService,
			IPcbConfiguration configurationService,
			ILogger<IPcbSecurityService> logger) : base(configurationService, logger)
		{
			Security = securityService;
			Config = configurationService;

		}

		/// <inheritdoc />
		public bool SaveRolePermissions(SavingRoles rolePermissions)
		{
			// Get the DB Context
			using (var db = GetReadWriteDbContext())
			{
				// Process the deletes first
				foreach (var rp in rolePermissions.Delete)
				{
					// Find the record to delete
					var rolePermission = db.RolePermission.FirstOrDefault(r => r.RoleId == rp.RoleId && r.PermissionId == rp.PermissionId);

					// Make sure we found a record
					if (rolePermission == null)
					{
						Logger.LogError("Save Roles: Item to delete was not found");
						return false;
					}

					// Remove the record
					db.RolePermission.Remove(rolePermission);
				}

				// Process the records to save
				foreach (var rp in rolePermissions.Save)
				{
					// Construct the record
					var rolePermission = new RolePermission
					{
						RoleId = rp.RoleId,
						PermissionId = rp.PermissionId
					};

					// Add the record
					db.RolePermission.Add(rolePermission);
				}

				// Apply the changes
				db.SaveChanges();
			}

			// Success
			return true;
		}

		/// <inheritdoc />
		IEnumerable<RoleSummary> ISecurityService.GetActiveRoles()
		{
			using (var db = GetReadOnlyDbContext())
			{
				// Get a list of active roles
				var roles = db.Role
					.Select(p => new RoleSummary
					{
						Id = p.Id,
						Title = p.Title,
						IsAdmin = p.IsAdmin,
						IsUser = p.IsUser,
						Summary = p.Summary,
						EndDate = p.EndDate,
						StartDate = p.StartDate,
						CreatedAt = p.CreatedAt
					})
					.OrderBy(r => r.Title)
					.ToList()
					.Where(r => IsActive(r.StartDate, r.EndDate));

				return roles;
			}
		}

		/// <summary>
		/// return boolean value to indicate if the logged in user can edit acontext user
		/// </summary>
		/// <param name="currentUserId">currentUserId</param>
		/// <param name="facilityId">contextUserId</param>
		/// <returns>Top position role for user</returns>
		string ISecurityService.GetUserRoleForPostion(int currentUserId, int? facilityId)
		{
			string getTopPosition = string.Empty;

			using (var db = GetReadOnlyDbContext())
			{
				if (facilityId.HasValue)
				{
					var rolesInFacility = db.UserRole.Where(ur => ur.UserId == currentUserId && ur.SchoolId == facilityId.Value).Select(ur => ur.Role).ToList();
					if (rolesInFacility != null && rolesInFacility.Count > 0)
					{
						getTopPosition = GetTopPosition(rolesInFacility);
					}
				}

				if (string.IsNullOrEmpty(getTopPosition))
				{
					var facilityWideRoles = db.UserRole.Where(ur => ur.UserId == currentUserId && ur.IsCountryWide).Select(ur => ur.Role).ToList();
					if (facilityWideRoles != null && facilityWideRoles.Count > 0)
					{
						getTopPosition = GetTopPosition(facilityWideRoles);
					}
				}

				if (string.IsNullOrEmpty(getTopPosition))
				{
					var facilityWideRoles = db.UserRole.Where(ur => ur.UserId == currentUserId).Select(ur => ur.Role).ToList();
					if (facilityWideRoles != null && facilityWideRoles.Count > 0)
					{
						getTopPosition = GetTopPosition(facilityWideRoles);
					}
				}

				return getTopPosition;
			}
		}

		/// <inheritdoc />
		public RoleManagement GetRolePermissions()
		{
			using (var db = GetReadOnlyDbContext())
			{
				// Get a list of roles
				var roles = db.Role
					.Select(p => new RoleSummary
					{
						Id = p.Id,
						Title = p.Title,
						Summary = p.Summary,
						EndDate = p.EndDate,
						StartDate = p.StartDate,
						CreatedAt = p.CreatedAt
					})
					.OrderBy(r => r.Title)
					.ToList()
					.Where(r => IsActive(r.StartDate, r.EndDate));

				// Get a list of permission groups
				var permissionGroups = db.PermissionGroup
					.Select(p => new PermissionGroupSummary
					{
						Id = p.Id,
						Title = p.Title,
						Summary = p.Summary,
						CreatedAt = p.CreatedAt
					})
					.OrderBy(p => p.Title)
					.ToList()
					.Where(p => IsActive(p.StartDate, p.EndDate));

				// Get all permissions
				var permissions = db.Permission
					.Select(p => new PermissionSummary
					{
						Id = p.Id,
						Title = p.Title,
						Summary = p.Summary,
						PermissionGroupId = p.PermissionGroupId,
						StartDate = p.StartDate,
						EndDate = p.EndDate,
						CreatedAt = p.CreatedAt
					})
					.OrderBy(p => p.Title)
					.ToList()
					.Where(p => IsActive(p.StartDate, p.EndDate));

				// Get the role permission data
				var rolePermissions = db.RolePermission
					.Select(p => new RolePermission
					{
						Id = p.Id,
						RoleId = p.RoleId,
						PermissionId = p.PermissionId,
						CreatedAt = p.CreatedAt,
						RowVer = p.RowVer,
						Permission = p.Permission,
						Role = p.Role
					})
				.ToList();

				// Construct the return class
				var returnValue = new RoleManagement
				{
					Roles = roles,
					PermissionGroups = permissionGroups,
					Permissions = permissions,
					RolePermissions = rolePermissions
				};

				return returnValue;
			}
		}

		/// <inheritdoc />
		public string GenerateRefreshToken(string email, string ipAddress = "127.0.0.1", string refreshToken = "", bool isReissuing = false)
		{

			var refreshLength = GetJwtRefreshLifetime();

			// Get the DB Context
			using (var db = GetReadWriteDbContext())
			{
				User user = db.User.SingleOrDefault(x => x.EmailAddress.Trim().ToLower() == email.Trim().ToLower());
				if (user == null) { throw new AppException("Unable to find user account"); }
				RefreshToken newRefreshToken = GenerateRefreshTokenItem(ipAddress);
				// brand new refresh Token
				if (!isReissuing)
				{
					// Add a new refresh token
					user.RefreshTokens.Add(newRefreshToken);

					// Remove any old tokens
					RemoveOldRefreshTokens(user);
				}
				// update refresh token
				else
				{
					// Do we have a refresh token already?
					var t = user.RefreshTokens.Single(rt => rt.Token == refreshToken);

					// No token found?
					if (t == null)
					{
						// Log expiry
						Logger.LogInformation($"Refresh token for user '{email}' does not exist, or has expired.");
						throw new AppException($"Refresh token for user '{email}' does not exist, or has expired.");
					}

					// Revoke the old token
					t.Revoked = DateTime.UtcNow;
					t.RevokedByIp = ipAddress;
					t.ReplacedByToken = newRefreshToken.Token;
					t.ModifiedAt = DateTimeOffset.Now;
					user.RefreshTokens.Add(newRefreshToken);
				}
				db.Update(user);
				// Apply the update/add changes
				db.SaveChanges();
				return newRefreshToken.Token;
			}
		}


		/// <inheritdoc />
		public bool IsRefreshTokenValid(string email, string refreshToken)
		{
			RefreshToken token;
			var refreshLength = GetJwtRefreshLifetime();

			using (var db = GetReadOnlyDbContext())
			{
				// Find the token
				User user = db.User.SingleOrDefault(u => u.EmailAddress.Trim().ToLower() == email.Trim().ToLower());
				token = user.RefreshTokens.FindAll(t => t.Token == refreshToken)
														.Find(x => IsActive(x.ModifiedAt.UtcDateTime, x.ModifiedAt.AddMinutes(refreshLength).UtcDateTime));
			}

			// Not found
			if (token == null)
			{
				Logger.LogInformation($"Refresh token for user '{email}' has expired.");
				return false;
			}

			// Valid!
			Logger.LogInformation($"Refresh token for user '{email}' is valid.");
			return true;
		}

		/// <inheritdoc cref="ICptSecurityService" />
		public void PurgeOldEventLogs()
		{
			// 6 Months
			const int timeToExpire = 6;

			// Setup the db context
			using (var db = GetReadWriteDbContext())
			{
				// Determine the refresh tokens that have expired
				var logsToDelete = db.EventLog.ToList().Where(rt => !IsActive(rt.CreatedAt.UtcDateTime, rt.CreatedAt.AddMonths(timeToExpire).UtcDateTime));

				// Remove these event logs
				db.RemoveRange(logsToDelete);

				// Apply the changes
				db.SaveChanges();
			}
		}

		/// <summary>
		/// return boolean value to indicate if the logged in user can edit acontext user
		/// </summary>
		/// <param name="currentUserId">currentUserId</param>
		/// <param name="contextUserId">contextUserId</param>
		/// <returns></returns>
		public bool CanEditUser(string currentUserId, string contextUserId)
		{
			using (var db = GetReadOnlyDbContext())
			{
				int currentId = Convert.ToInt16(currentUserId);
				int contextId = Convert.ToInt16(contextUserId);

				var currentUser = db.User.Where(u => u.Id == currentId);
				var contextUser = db.User.Where(u => u.Id == contextId);
				if (currentUser == null || contextUser == null)
				{
					return false;
				}

				var currentUserRoleRanks = db.UserRole.Where(ur => ur.UserId == currentId).Select(ur => ur.Role.Rank);
				var contextUserRoleRanks = db.UserRole.Where(ur => ur.UserId == contextId).Select(ur => ur.Role.Rank);
				var currentUserRank = currentUserRoleRanks.Where(r => r == currentUserRoleRanks.Min()).FirstOrDefault();
				var contextUserRank = contextUserRoleRanks.Where(r => r == contextUserRoleRanks.Min()).FirstOrDefault();
				var currentUserApplicableRole = currentUser.Select(u => u.UserRole).FirstOrDefault().Where(r => r.RoleId == db.Role.Where(role => role.Rank == currentUserRank).Select(i => i.Id).FirstOrDefault());
				var contextUserApplicableRole = contextUser.Select(u => u.UserRole).FirstOrDefault().Where(r => r.RoleId == db.Role.Where(role => role.Rank == contextUserRank).Select(i => i.Id).FirstOrDefault());

				ApplicableRank currentUserapplicableRank = PopulateApplicableRank(currentId, currentUser, currentUserRank, currentUserApplicableRole);
				ApplicableRank contextUserapplicableRank = PopulateApplicableRank(contextId, contextUser, contextUserRank, contextUserApplicableRole);
				return CanCurrentUserEditContextUser(currentUserapplicableRank, contextUserapplicableRank);
			}
		}

		public void FailedPasswordAttempt(string email, bool reset = false)
		{
			using var _db = GetReadWriteDbContext();
			User user = _db.User.SingleOrDefault(u => u.EmailAddress.Trim().ToLower() == email.Trim().ToLower());
			if (reset == true)
			{
				user.FailedLoginAttempt = 0;
				user.LastFailedLoginAttempt = new DateTime();
			}
			else
			{
				user.FailedLoginAttempt += 1;
				user.LastFailedLoginAttempt = DateTime.UtcNow;
			}
			_db.Update(user);
			_db.SaveChanges();
		}

		/// <summary>
		/// return string value. used to get the top user role
		/// </summary>
		/// <param name="roles">currentUserapplicableRank</param>
		/// <returns>string</returns
		private static string GetTopPosition(List<Role> roles)
		{
			var topRole = roles.OrderBy(r => r.Rank).FirstOrDefault<Role>();
			if (topRole != null)
			{
				if (topRole.IsAdmin)
				{
					return "Administrator";
				}

				if (topRole.IsUser)
				{
					return "User";
				}

				// ...
				return string.Empty;
			}

			return string.Empty;
		}

		/// <summary>
		/// return boolean value to indicate if the logged in user can edit a context user
		/// </summary>
		/// <param name="currentUserapplicableRank">currentUserapplicableRank</param>
		/// <param name="contextUserapplicableRank">contextUserapplicableRank</param>
		/// <returns></returns>
		private static bool CanCurrentUserEditContextUser(ApplicableRank currentUserapplicableRank, ApplicableRank contextUserapplicableRank)
		{
			// if current user and context user have same rank ;
			if (currentUserapplicableRank.Rank == contextUserapplicableRank.Rank)
			{
				if (currentUserapplicableRank.IsFacilityWide)
				{
					return true;
				}

				if (!currentUserapplicableRank.IsFacilityWide)
				{
					if (currentUserapplicableRank.FacilityId.Count() > 0)
					{
						var intersection = currentUserapplicableRank.FacilityId.Intersect(contextUserapplicableRank.FacilityId);
						if (intersection.Count() > 0)
						{
							return true;
						}
						else
						{
							return false;
						}
					}
				}
			}

			// If current user rank is higher return true
			if (currentUserapplicableRank.Rank < contextUserapplicableRank.Rank)
			{
				return true;
			}

			// if context user rank is higher return false
			if (currentUserapplicableRank.Rank > contextUserapplicableRank.Rank)
			{
				return false;
			}

			return false;
		}

		/// <summary>
		/// populate Applicable rank object
		/// </summary>
		/// <param name="userId">userId</param>
		/// <param name="user">user</param>
		/// <param name="userRank">userRank</param>
		/// <param name="userApplicableRole">userApplicableRole</param>
		/// <returns></returns>
		private static ApplicableRank PopulateApplicableRank(int userId, IQueryable<User> user, int userRank, IEnumerable<UserRole> userApplicableRole)
		{
			var userapplicableRank = new ApplicableRank();

			if ((user != null) && userApplicableRole.Any())
			{
				userapplicableRank.Rank = userRank;
				userapplicableRank.UserId = userId;
				userapplicableRank.IsFacilityWide = userApplicableRole.FirstOrDefault().IsCountryWide;
				userapplicableRank.FacilityId = userApplicableRole.Select(r => r.SchoolId);
			}

			return userapplicableRank;
		}

		/// <summary>
		/// Determines whether the specified start date is active.
		/// </summary>
		/// <param name="startDate">The start date.</param>
		/// <param name="endDate">The end date.</param>
		/// <returns>
		///   <c>true</c> if the specified start date is active; otherwise, <c>false</c>.
		/// </returns>
		private static bool IsActive(DateTime startDate, DateTime? endDate)
		{
			var today = DateTime.Now;
			return startDate <= today && (endDate <= today || endDate == null);
		}

		private RefreshToken GenerateRefreshTokenItem(string ipAddress)
		{
			// Generate a Refresh Token - unique GUID
			var token = Guid.NewGuid().ToString().Replace("-", string.Empty, StringComparison.Ordinal);
			return new RefreshToken
			{
				Expires = DateTime.UtcNow.AddMinutes(GetJwtRefreshLifetime()),
				CreatedAt = DateTime.UtcNow,
				Token = token,
				CreatedByIp = ipAddress
			};
		}

		private void RemoveOldRefreshTokens(User user)
		{
			user.RefreshTokens.RemoveAll(x =>
				!x.IsActive &&
				x.CreatedAt.AddMinutes(GetJwtRefreshLifetime()) <= DateTime.UtcNow);
		}
		/// <summary>
		/// Gets the JWT refresh lifetime from app settings.
		/// </summary>
		/// <returns></returns>
		private int GetJwtRefreshLifetime()
		{
			return Configuration.PcbAppSettings.DataSettings.JwtRefreshLifetime;
		}
	}
}
