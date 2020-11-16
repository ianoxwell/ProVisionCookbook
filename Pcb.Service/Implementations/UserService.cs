using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pcb.Common;
using Pcb.Configuration;
using Pcb.Database;
using Pcb.Database.Context;
using Pcb.Database.Context.Models;
using Pcb.Dto.Security;
using Pcb.Dto.User;
using Pcb.Security;
using Pcb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pcb.Service.Implementations
{
	/// <inheritdoc cref="IUserService"/>
	internal class UserService : ServiceBase<PcbDbContext>, IUserService
	{
		/// <summary>
		/// The security service object.
		/// </summary>
		private IPcbSecurityService SecurityService { get; }


		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="referenceService">The reference service.</param>
		/// <param name="securityService">The security service.</param>
		/// <param name="configurationService">The configuration service.</param>
		/// <param name="emailService">The email service.</param>
		/// <param name="logger">The logger.</param>
		public UserService(
			IPcbSecurityService securityService,

			IPcbConfiguration configurationService,

			ILogger<UserService> logger)
			: base(configurationService, logger)
		{
			SecurityService = securityService;

		}


		/// <inheritdoc />
		public bool ToggleUserStatus(UserSummary user)
		{
			// Get the DB Context
			using (var db = GetReadWriteDbContext())
			{
				// Get the user record
				var userEntity = db.User.FirstOrDefault(u => u.Id == user.Id);
				if (userEntity == null)
				{
					Logger.LogError(new EventId(user.Id), "Saving Active status Failed: User could not be found");
					return false;
				}

				// Update the user record
				userEntity.IsActive = !userEntity.IsActive;

				// Apply the changes
				db.SaveChanges();
			}

			return true;
		}

		/// <inheritdoc />
		public bool SaveProfile(UserProfile profile)
		{
			var loggedInUser = SecurityService.GetAuthenticatedUser();

			if (profile.UserId != loggedInUser.Id)
			{
				Logger.LogError($"Save Profile Error: User '{loggedInUser.Username}' with Id '{loggedInUser.Id}' attempted to save a users profile with a userId of '{profile.UserId}'.");
				throw new UnauthorizedAccessException();
			}

			var isSaveSuccessful = true;
			using (var context = GetReadWriteDbContext())
			{
				RetryExecution(context).Execute(() =>
				{
					using (var db = GetReadWriteDbContext())
					using (var tran = GetTransactionScope())
					{
						// Save user phone number.
						var usr = db.User.Where(u => u.Id == profile.UserId).SingleOrDefault();
						if (usr != null)
						{
							usr.PhoneNumber = !string.IsNullOrWhiteSpace(profile.PhoneNumber) ? profile.PhoneNumber : null;
						}

						// Save the changes to the profile
						db.SaveChanges();

						// Complete the transaction
						tran.Complete();
					}
				});
			}

			// Saving Complete!
			Logger.LogInformation(new EventId(profile.Id), "Successfully saved user profile.");
			return isSaveSuccessful;
		}


		/// <inheritdoc />
		public int SaveUserAndRoles(UserRoleFacility user, bool notifyFacility, bool isRegistration)
		{
			using (var context = GetReadWriteDbContext())
			{
				RetryExecution(context).Execute(() =>
				{
					using (var db = GetReadWriteDbContext())
					using (var tran = GetTransactionScope())
					{
						// Get the user record
						var userEntity = db.User.FirstOrDefault(u => u.Id == user.Id);

						// No user found and it is not new?
						if (userEntity == null && !user.IsNewUser)
						{
							// No user, and editing an existing user
							Logger.LogError(new EventId(user.Id), $"Saving User failed: User with id {user.Id} could not be found, and the user passed in is not a new user!");

							user.Id = 0;
							return;
						}

						// New User
						if (user.IsNewUser)
						{
							// Save the new user
							user.Id = SaveNewUser(db, user);

							// Couldn't save!
							if (user.Id == 0)
							{
								return;
							}
						}

						// Existing User
						if (!user.IsNewUser)
						{
							UpdateExistingUser(db, user, userEntity);
						}

						// Update the user roles with facility permissions
						UpdateUserRoles(db, user);

						// Attempt a save
						db.SaveChanges();

						// Send email to facility if required.
						if (notifyFacility)
						{
							var facilities = db.School.ToList();
							var roles = db.Role.ToList();
							//SendUserAddedToFacilityEmail(user, facilities, roles);
						}

						// Commit the transaction
						tran.Complete();

						var loggingText = string.Empty;
						if (isRegistration)
						{
							loggingText = $"{user.Username} is successfully registered.";
						}
						else
						{
							// Get the current user
							var loggedInUser = SecurityService.GetAuthenticatedUser();

							// Construct the correct message to log
							loggingText = user.IsNewUser
								? $"User '{loggedInUser.Username}' has successfully saved the new user '{user.Username}'."
								: $"User '{loggedInUser.Username}' has changed the user permissions for user '{user.Username}'";
						}

						// Log the changes
						Logger.LogInformation(new EventId(user.Id), loggingText);
					}
				});
			}

			return user.Id;
		}

		/// <inheritdoc />
		public async Task<UserRoleFacility> GetAsync(int userId)
		{
			using (var db = GetReadOnlyDbContext())
			{
				var user = await db.User.Where(u => u.Id == userId)
							.Select(u => new UserRoleFacility
							{
								Id = u.Id,
								Username = u.Username,
								FamilyName = u.FamilyName,
								GivenNames = u.GivenNames,
								Email = u.EmailAddress,
								PhoneNumber = u.PhoneNumber,
								IsActive = u.IsActive
							}).SingleOrDefaultAsync();

				user.RoleSummary = await GetUserRoleSummaryAsync(userId);
				return user;
			}
		}

		/// <inheritdoc />
		public async Task<UserProfile> GetProfileAsync(int userId)
		{
			var loggedInUser = SecurityService.GetAuthenticatedUser();

			if (userId != loggedInUser.Id)
			{
				Logger.LogError($"GET Profile Error: User '{loggedInUser.Username}' with Id '{loggedInUser.Id}' attempted to save a users profile with a userId of '{userId}'.");
				throw new UnauthorizedAccessException();
			}

			using (var db = GetReadOnlyDbContext())
			{
				// Get all facilities the user is assigned to
				var userFacilities = await db.UserRole
					.Where(u => u.UserId == userId)
					.Select(u => new { u.SchoolId, u.IsCountryWide })
					.Distinct()
					.ToListAsync();

				// Are any of the designations facility wide?
				var isFacilityWide = userFacilities.Count > 0 && userFacilities.FirstOrDefault(u => u.IsCountryWide) != null;

				List<School> facilities = new List<School>();

				// Filter the facilities based global permissions
				if (!isFacilityWide)
				{
					// Only assign designated facilities
					//TODO : Get only active ones
					var userFacilityIds = userFacilities.Select(userFac => userFac.SchoolId);
					facilities = await db.School.Where(f => userFacilityIds.Contains(f.Id)).ToListAsync();
				}
				else
				{
					// Assign all facilities
					//TODO : Get only active ones
					facilities = db.School.ToList();
				}

				/* Start - Generating role facilities mapping for a user to display in profile page */
				var userRoles = await db.UserRole.Where(ur => ur.UserId == userId).ToListAsync();
				var distinctRoles = (from ur in userRoles
									 join r in db.Role on ur.RoleId equals r.Id
									 select new
									 {
										 UserId = ur.UserId,
										 Role = r.Title,
										 RoleId = r.Id,
										 ur.IsCountryWide,
										 ur.SchoolId
									 }).ToList();

				var distinctRoleIds = distinctRoles.Select(ur => ur.RoleId).Distinct().ToList<int>();
				var userRoleFacilities = new List<UserProfileRoleFacilties>();

				if (distinctRoleIds != null && distinctRoleIds.Count > 0)
				{
					distinctRoleIds.ForEach(r =>
					{
						var distinctRole = distinctRoles.Where(dr => dr.RoleId == r).ToList();
						var roleItem = distinctRole.First();
						var facilityNames = string.Empty;
						if (!distinctRole.First().IsCountryWide)
						{
							var facilitySummary = (from f in facilities
												   join d in distinctRole on f.Id equals d.SchoolId
												   orderby f.Title
												   select f.Title).ToList<string>();
							facilityNames = string.Join(", ", facilitySummary);
						}
						else
						{
							facilityNames = "All (Facility Wide)";
						}

						userRoleFacilities.Add(new UserProfileRoleFacilties()
						{
							UserId = roleItem.UserId,
							RoleId = r,
							Role = roleItem.Role,
							IsFacilityWide = roleItem.IsCountryWide,
							Facilities = facilityNames
						});
					});
				}

				/* End - Generating role facilities mapping for a user to display in profile page */

				var profile = await db.User.Where(u => u.Id == userId)
					.Select(u => new UserProfile
					{
						//Id = Id,
						UserId = u.Id,
						GivenNames = u.GivenNames,
						FamilyName = u.FamilyName,
						Email = u.EmailAddress,
						PhoneNumber = u.PhoneNumber,
						//RefItems = new UserProfileReferenceData
						//{
						//	Facilities = facilities,
						//	Sorting = homepageSorting,
						//	UserRoleFacilities = userRoleFacilities
						//}
					}).SingleOrDefaultAsync();

				return profile;
			}
		}

		/// <inheritdoc />
		public async Task<IPagedResult<UserSummary>> GetUserSummaryAsync(
			string sort = "createdAt", string order = "asc", string filter = "", int page = 1)
		{
			var pagedResult = new PagedResult<UserSummary>
			{
				Items = new List<UserSummary>(),
				TotalCount = 0
			};

			// we only want to return users that have permissions in the facility the authenticated user has
			// administerUsers permission. I.e. if the current user has AdministerUsers in bowen, we only want to
			// return the users who have permissions in bowen. This will include facility wide users as well.
			var isAuthFacilityWide = SecurityService.IsAuthorisedFacilityWide(SecurityPermission.AdministerUsers);
			var explicitFacilities = SecurityService.GetExplicitlyAuthorisedFacilities(SecurityPermission.AdministerUsers);

			if (!isAuthFacilityWide && !explicitFacilities.Any())
			{
				Logger.LogWarning("Security Exception: An attempt was made to retrieve system users and their roles without the required permission.");
				return pagedResult;
			}

			var filteredFacilities = isAuthFacilityWide
				? Array.Empty<int>()
				: explicitFacilities;

			var pageSize = Configuration.PcbAppSettings.DataSettings.PageSize;
			var p = page > 0 ? page : 0;

			using (var db = GetReadOnlyDbContext())
			{
				var skip = p * pageSize;

				var users = db.User
					.Where(l => string.IsNullOrEmpty(filter) ||
								l.EmailAddress.Contains(filter) ||
								l.FamilyName.Contains(filter) ||
								l.GivenNames.Contains(filter) ||
								l.Username.Contains(filter));

				// only show users in the facilities the current user has permissions for.
				if (filteredFacilities.Any())
				{
					users = users.Where(u => u.UserRole.Any(ur => ur.IsCountryWide || filteredFacilities.Contains(ur.SchoolId.Value)));
				}

				users = order.Equals("asc", StringComparison.OrdinalIgnoreCase)
					? users.OrderByMember(sort)
					: users.OrderByMemberDescending(sort);

				var adminRoleId = db.Role.Where(y => y.IsAdmin == true).FirstOrDefault().Id;

				pagedResult.TotalCount = await users.CountAsync();
				pagedResult.Items = await users.Skip(skip).Take(pageSize)
					.Include(u => u.UserRole)
					.Select(u => new UserSummary
					{
						Id = u.Id,
						Username = u.Username,
						FamilyName = u.FamilyName,
						GivenNames = u.GivenNames,
						Email = u.EmailAddress,
						PhoneNumber = u.PhoneNumber,
						IsActive = u.IsActive,
						IsAdmin = u.UserRole.Where(y => y.RoleId == adminRoleId).FirstOrDefault() != null ? true : false
					}).ToListAsync();

				return pagedResult;
			}
		}

		/// <summary>
		/// Returns the list of all users in the given facility.
		/// This is called when a user clicks a facility drop down list in the transfer form page.
		/// </summary>
		/// <param name="facilityId">The facility identifier.</param>
		/// <param name="includedIds">The included ids.</param>
		/// <returns>
		/// A list of users
		/// </returns>
		/// <inheritdoc />
		public IEnumerable<UserSummary> GetUsersInFacility(int facilityId, IEnumerable<int> includedIds = null)
		{
			using (var db = GetReadOnlyDbContext())
			{
				var userList = db.User
					.Where(u =>
						u.UserRole.Any(ur => ur.IsCountryWide
											|| (ur.SchoolId.HasValue && ur.SchoolId.Value == facilityId)
											|| (includedIds != null && includedIds.Any() && includedIds.Contains(ur.UserId))))
					.Include(u => u.UserRole)
					.Select(u => new UserSummary
					{
						Id = u.Id,
						Username = u.Username,
						FamilyName = u.FamilyName,
						GivenNames = u.GivenNames,
						Email = u.EmailAddress,
						PhoneNumber = u.PhoneNumber,
						IsActive = u.IsActive
					}).ToList();

				return userList;
			}
		}

		/// <summary>
		/// Returns the list of all users
		/// </summary>
		/// <param name="facilityId">The facility identifier.</param>
		/// <param name="includedIds">The included ids.</param>
		/// <returns></returns>
		public IEnumerable<UserSummary> GetAllUsers()
		{
			using (var db = GetReadOnlyDbContext())
			{
				var userList = db.User
					.Where(u =>
						u.UserRole.Any(ur => ur.IsCountryWide || ur.SchoolId.HasValue))
					.Include(u => u.UserRole)
					.Select(u => new UserSummary
					{
						Id = u.Id,
						Username = u.Username,
						FamilyName = u.FamilyName,
						GivenNames = u.GivenNames,
						Email = u.EmailAddress,
						PhoneNumber = u.PhoneNumber,
						IsActive = u.IsActive
					}).ToList();

				return userList;
			}
		}

		/// <inheritdoc/>
		public IEnumerable<UserSummary> GetUsersForUserSearch(string familyName, string givenNames)
		{
			familyName = familyName.Trim();
			givenNames = givenNames.Trim();

			var userList = new List<UserSummary>();

			// Get existing users in Pcb
			foreach (var existingUser in GetAllUsersUserMatchingFirstNameLastName(givenNames, familyName))
			{
				userList.Add(existingUser);
			}

			return userList;
		}

		/// <inheritdoc />
		public async Task<UserSearchResponse> AddUserToFacilityAsync(UserSummary userInfo, IEnumerable<int> facilityIds, int roleId)
		{
			var isANewUser = userInfo.Id == 0 ? true : false;
			var targetFacilityIds = facilityIds.ToList();
			if (userInfo.Id != 0)
			{
				var user = await GetAsync(userInfo.Id);

				// Check if existing user
				if (user != null)
				{
					userInfo.IsNewUser = false;

					// check if user is in selected facility
					var userRoleSummary = await GetUserRoleSummaryAsync(userInfo.Id);

					// check if user has a facility wide role
					var hasFacilityWideRole = userRoleSummary.FirstOrDefault(x => x.IsFacilityWide == true && x.RoleId == roleId) != null ? true : false;
					if (hasFacilityWideRole)
					{
						// dont save
						return new UserSearchResponse
						{
							IsSuccess = false,
							HasEmail = false
						};
					}

					// Get the facility ids which are not assigned to the user for the role.
					var listOfRoleSummaries = userRoleSummary.Where(ur => ur.RoleId == roleId).ToList();
					targetFacilityIds = new List<int>();
					var userCurrentRoleFacilities = new List<int>();
					foreach (var roleSummary in listOfRoleSummaries)
					{
						var ids = roleSummary.FacilitySummary.Select(fs => fs.Id);
						userCurrentRoleFacilities.AddRange(ids);
					}

					targetFacilityIds = facilityIds.ToList().Except(userCurrentRoleFacilities).ToList();

					if (targetFacilityIds == null || targetFacilityIds.Count == 0)
					{
						// do not save
						return new UserSearchResponse
						{
							IsSuccess = false,
							HasEmail = false
						};
					}
				}
			}

			var hasTempEmail = false;
			if (userInfo.Email == null)
			{
				// Temporary email for users without an email
				hasTempEmail = true;
				userInfo.Email = $"{userInfo.Username}@Pcb.com.au";
			}

			targetFacilityIds = targetFacilityIds.Distinct().ToList();
			var newUser = await CreateUserWithFacilityDetailsAsync(userInfo, targetFacilityIds, roleId, isANewUser);

			// Save the user
			SaveUserAndRoles(newUser, true, false);

			if (hasTempEmail)
			{
				return new UserSearchResponse
				{
					IsSuccess = true,
					HasEmail = true,
					UserEmail = $"{userInfo.Username}@Pcb.com.au"
				};
			}

			// New user logic
			return new UserSearchResponse
			{
				IsSuccess = true,
				HasEmail = false
			};
		}

		/// <summary>
		/// Gets users role summary based on user's Id.
		/// </summary>
		/// <param name="id">Id of user</param>
		/// <returns></returns>
		private async Task<IEnumerable<UserRoleSummary>> GetUserRoleSummaryAsync(int id)
		{
			using (var db = GetReadOnlyDbContext())
			{
				var userRoles = await db.UserRole
					.Include(x => x.Role)
					.Include(y => y.School)
					.Where(ur => ur.UserId == id).ToListAsync();

				var roleSummary =
				(from ur in userRoles
				 group ur by new { ur.RoleId, ur.Role.Title, ur.Role.Rank, ur.IsCountryWide } into rg
				 select new UserRoleSummary
				 {
					 Id = id,
					 RoleId = rg.Key.RoleId,
					 Role = rg.Key.Title,
					 Rank = rg.Key.Rank,
					 IsFacilityWide = rg.Key.IsCountryWide,

					 // We don't want to get a record if it doesn't have a facility Id because it is most likely
					 // an all facility wide record and currently the front end expects it this way.
					 FacilitySummary = (from f in rg
										where f.SchoolId != null
										select new UserFacilitySummary
										{
											Id = f.SchoolId.GetValueOrDefault(0),
											Facility = f.School.Title
										}).ToList()
				 }).ToList();

				return roleSummary;
			}
		}

		/// <summary>
		/// return all users form Pcb matching firstname and lastname
		/// </summary>
		/// <param name="firstName">The first name</param>
		/// <param name="lastName">the last name</param>
		/// <returns></returns>
		private IEnumerable<UserSummary> GetAllUsersUserMatchingFirstNameLastName(string firstName, string lastName)
		{
			using (var db = GetReadOnlyDbContext())
			{
				var userList = db.User
					.Where(u => EF.Functions.Like(u.FamilyName, lastName) && EF.Functions.Like(u.GivenNames, firstName))
					.Include(u => u.UserRole)
					.Select(u => new UserSummary
					{
						Id = u.Id,
						Username = u.Username,
						FamilyName = u.FamilyName,
						GivenNames = u.GivenNames,
						Email = u.EmailAddress,
						PhoneNumber = u.PhoneNumber,
						IsActive = u.IsActive
					}).ToList();

				return userList;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="UserService" /> class.
		/// </summary>
		/// <param name="db">The database.</param>
		/// <param name="user">The user.</param>
		private void UpdateUserRoles(PcbDbContext db, UserRoleFacility user)
		{
			foreach (var userRole in user.RoleSummary)
			{
				// Get the User role record if exists
				var userRoleEntity = db.UserRole.FirstOrDefault(u => u.UserId == user.Id && u.RoleId == userRole.RoleId);

				// No user role?
				if (userRoleEntity == null)
				{
					// We don't have any, create one or many based on IsFacilityWide flag
					if (userRole.IsFacilityWide)
					{
						// Facility wide role
						db.UserRole.Add(new UserRole
						{
							UserId = user.Id,
							RoleId = userRole.RoleId,
							IsCountryWide = true
						});

						// Next
						continue;
					}

					// Not facility wide
					userRole.FacilitySummary.ToList().ForEach(ufs =>
					{
						// Add the new role facility
						db.UserRole.Add(new UserRole
						{
							UserId = user.Id,
							RoleId = userRole.RoleId,
							SchoolId = ufs.Id,
							IsCountryWide = false
						});
					});

					// Next
					continue;
				}

				// Already facility wide?
				if (userRoleEntity.IsCountryWide && userRole.IsFacilityWide)
				{
					// Next
					continue;
				}

				// Becoming non-facility wide
				if (userRoleEntity.IsCountryWide && !userRole.IsFacilityWide)
				{
					// Remove existing facility wide role
					var removeFacilityWideRoles = db.UserRole.Where(ur => ur.UserId == user.Id && ur.RoleId == userRole.RoleId);
					db.UserRole.RemoveRange(removeFacilityWideRoles);

					// Add the individual role facilities
					userRole.FacilitySummary
						.ToList()
						.ForEach(ufs =>
						{
							db.UserRole.Add(new UserRole
							{
								UserId = user.Id,
								RoleId = userRole.RoleId,
								SchoolId = ufs.Id,
								IsCountryWide = false
							});
						});

					// Next
					continue;
				}

				// Becoming facility wide
				if (!userRoleEntity.IsCountryWide && userRole.IsFacilityWide)
				{
					// Remove every role
					var rolesToRemove = db.UserRole.Where(ur => ur.UserId == user.Id && ur.RoleId == userRole.RoleId);
					db.UserRole.RemoveRange(rolesToRemove);

					// Add a new facility wide role
					db.UserRole.Add(new UserRole
					{
						UserId = user.Id,
						RoleId = userRole.RoleId,
						IsCountryWide = true
					});

					// Next
					continue;
				}

				// Add new role facilities - selective add/remove of the new facilities
				userRole.FacilitySummary
					.Where(fs => !db.UserRole.Any(ur => ur.UserId == user.Id && ur.RoleId == userRole.RoleId && ur.SchoolId == fs.Id))
					.ToList()
					.ForEach(ufs =>
					{
						db.UserRole.Add(new UserRole
						{
							UserId = user.Id,
							RoleId = userRole.RoleId,
							SchoolId = ufs.Id,
							IsCountryWide = false
						});
					});

				// Remove un-matching user role facilities
				var removeUnusedRoles = db.UserRole.Where(ur => ur.UserId == user.Id
																&& ur.RoleId == userRole.RoleId).ToList()
																.Where(x => userRole.FacilitySummary.All(fs => fs.Id != x.SchoolId));

				db.UserRole.RemoveRange(removeUnusedRoles);
			}

			// Remove the user roles which doesn't exist in incoming
			var removeUnusedIncomingRoles = db.UserRole.Where(ur => ur.UserId == user.Id).ToList().Where(x => user.RoleSummary.All(rs => rs.RoleId != x.RoleId)).ToList();
			db.UserRole.RemoveRange(removeUnusedIncomingRoles);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="UserService" /> class.
		/// </summary>
		/// <param name="db">The database.</param>
		/// <param name="user">The user.</param>
		/// <param name="userEntity">The user entity.</param>
		private void UpdateExistingUser(PcbDbContext db, UserRoleFacility user, User userEntity)
		{
			// Update the user details
			userEntity.GivenNames = user.GivenNames;
			userEntity.FamilyName = user.FamilyName;
			userEntity.EmailAddress = user.Email;
			userEntity.PhoneNumber = user.PhoneNumber;
			userEntity.IsActive = user.IsActive;
		}

		/// <summary>
		/// Updates the new user.
		/// </summary>
		/// <param name="db">The database.</param>
		/// <param name="user">The user.</param>
		/// <returns></returns>
		private int SaveNewUser(PcbDbContext db, UserRoleFacility user)
		{
			// Create the new user object
			var newUser = new User
			{
				Username = user.Username,
				GivenNames = user.GivenNames,
				FamilyName = user.FamilyName,
				EmailAddress = user.Email,
				PhoneNumber = user.PhoneNumber,
				IsActive = user.IsActive
			};

			// Add the new user entity
			db.User.Add(newUser);

			// Attempt a new user save (including defaults)
			db.SaveChanges();

			// Return the newly created user id!
			return newUser.Id;
		}

		/// <summary>
		/// Creates the user with facility details.
		/// </summary>
		/// <param name="userInfo">The user information.</param>
		/// <param name="facilityIds">The facility identifiers.</param>
		/// <param name="roleId">The role id.</param>
		/// <param name="isANewUser">if set to <c>true</c> [is a new user].</param>
		/// <returns></returns>
		private async Task<UserRoleFacility> CreateUserWithFacilityDetailsAsync(UserSummary userInfo, IEnumerable<int> facilityIds, int roleId, bool isANewUser)
		{
			using (var db = GetReadOnlyDbContext())
			{
				// Query the DB for the medical officer role ID value
				var userRole = db.Role.Where(role => role.Id == roleId).Single();
				var facilityDetails = (facilityIds != null) ? db.School.Where(facility => facilityIds.Contains(facility.Id)).ToList() : new List<School>();

				// Create the save object
				var newUserReadOnlyRoleSummary = new UserRoleSummary()
				{
					Id = 0,
					RowVer = string.Empty,
					RoleId = userRole.Id,
					Role = userRole.Title,
					IsFacilityWide = false,
					FacilitySummary = facilityDetails.Select(f => new UserFacilitySummary { Id = f.Id, Facility = f.Title, RowVer = string.Empty }).ToList()
				};

				var newUserRoleSummaryList = new List<UserRoleSummary> { newUserReadOnlyRoleSummary };
				var listOfExistingRoleSummaries = await GetUserRoleSummaryAsync(userInfo.Id);

				// Add in all the existing role summaries if any
				/*
				foreach (var roleSummary in listOfExistingRoleSummaries)
				{
					// Add all the existing readonly roles in other facilities that the user has
					if (roleSummary.Id == userRole.Id)
					{
						newUserReadOnlyRoleSummary.FacilitySummary = newUserReadOnlyRoleSummary.FacilitySummary.Concat(roleSummary.FacilitySummary);
						continue;
					}

					newUserRoleSummaryList.Add(roleSummary);
				}
				*/

				var newUser = new UserRoleFacility()
				{
					Id = userInfo.Id,
					Username = userInfo.Username,
					FamilyName = userInfo.FamilyName,
					GivenNames = userInfo.GivenNames,
					Email = userInfo.Email,
					PhoneNumber = userInfo.PhoneNumber,
					IsActive = userInfo.IsActive,
					IsNewUser = isANewUser,
					RowVer = string.Empty,
					RoleSummary = newUserRoleSummaryList
				};
				return newUser;
			}
		}

		/// <summary>
		/// Get user Id
		/// </summary>
		/// <param name="db">The database.</param>
		/// <param name="userId">The user identifier.</param>
		/// <param name="username">The username.</param>
		/// <returns></returns>
		private static int? GetUserId(PcbDbContext db, int? userId, string username = null)
		{
			if (userId.HasValue)
			{
				return userId;
			}

			if (username != null && username.Trim().Length > 1)
			{
				userId = db.User.FirstOrDefault(u => u.Username == username)?.Id;
			}

			return userId ?? null;
		}


	}
}
