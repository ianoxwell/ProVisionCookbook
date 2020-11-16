using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Pcb.Common;
using Pcb.Configuration;
using Pcb.Database.Context.Models;
using Pcb.Dto.Security;
using Pcb.Security.Authentication;
using Pcb.Security.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;

[assembly: InternalsVisibleTo("Pcb.Security.Tests")]

namespace Pcb.Security.Authorisation
{
	/// <summary>
	/// Primary security service for Cpt. Handles authentication and authorisation
	/// </summary>
	internal class PcbSecurityService : IPcbSecurityService
	{
		/// <summary>
		/// Pcb Configuration from appsettings.json
		/// </summary>
		private IPcbConfiguration Configuration { get; }

		/// <summary>
		/// Pcb Logger
		/// </summary>
		private ILogger<PcbSecurityService> Logger { get; }

		/// <summary>
		/// Repository for accessing security related data
		/// </summary>
		private ISecurityDataRepository SecurityRepository { get; }

		/// <summary>
		/// Aspnet core http context, used for retrieving the current authenticated user.
		/// Replaces the old Thread.CurrentPrincipal as that wasn't injectable.
		/// </summary>
		private readonly IHttpContextAccessor Context;

		/// <summary>
		/// Allows us to cache security information about the logged in user.
		/// </summary>
		private IMemoryCache MemoryCache { get; }


		/// <summary>
		/// Initializes a new instance of the <see cref="PcbSecurityService"/> class.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		/// <param name="logger">The logger.</param>
		/// <param name="repository">The repository.</param>
		/// <param name="context">The context.</param>
		/// <param name="memoryCache">The memory cache.</param>
		public PcbSecurityService(
			IPcbConfiguration configuration,
			ILogger<PcbSecurityService> logger,
			ISecurityDataRepository repository,
			IHttpContextAccessor context,
			IMemoryCache memoryCache = null)
		{
			Configuration = configuration;
			Logger = logger;
			SecurityRepository = repository;
			Context = context;
			MemoryCache = memoryCache;
		}

		/// <summary>
		/// Authenticate a user against the authentication method provided in appsettings.json.
		/// </summary>
		/// <param name="username">the user's username</param>
		/// <param name="password">the user's password</param>
		/// <returns>
		/// Empty list of claims if not authenticated
		/// </returns>
		public IEnumerable<Claim> Authenticate(string username, string password, bool isSocial)
		{
			var user = SecurityRepository.GetUser(username);

			// Can't find the user in the database
			if (user == null || user.Id <= 0)
			{
				Logger.LogInformation($"Authentication: Unable to find user with username '{username}'.");
				List<Claim> messageList = new List<Claim>();
				messageList.Add(new Claim("user", "register"));
				return messageList;
			}

			// User is deactivated
			if (!user.IsActive)
			{
				Logger.LogInformation($"Authentication: User is currently deactivated '{username}'.");

				// Return claims with no userId to tell the upper level we failed auth.
				var claims = new List<Claim>
				{
					new Claim(JwtRegisteredClaimNames.Sub, "0"),
				};

				return claims;
			}

			int maxAttempts = Configuration.PcbAppSettings.DataSettings.MaxLoginAttempts;
			int waitMin = Configuration.PcbAppSettings.DataSettings.LockOutTime;
			if (user.FailedLoginAttempt >= maxAttempts && user.LastFailedLoginAttempt.AddMinutes(waitMin) > DateTime.UtcNow)
			{
				Logger.LogInformation($"Authentication: User is currently locked out '{username}'.");
				List<Claim> messageList = new List<Claim>
				{
					new Claim("authentication", user.FailedLoginAttempt.ToString())
				};
				return messageList;
			}

			// User is not yet verified
			if (!user.IsVerified)
			{
				Logger.LogInformation($"Authentication: User has not yet verified '{username}'.");
				List<Claim> messageList = new List<Claim>
				{
					new Claim("verify", "notVerified")
				};
				return messageList;
			}


			// Can't Authenticate!
			if (!isSocial && !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
			{
				Logger.LogInformation($"Authentication: Login failed for user '{username}'.");
				return new List<Claim>();
			}

			// no reason not to log the user in - increment login values
			bool increment = SecurityRepository.IncrementLoginValues(user.Id).Result;
			if (increment == false)
			{
				Logger.LogInformation($"Error incrementing login values for user '{username}'.");
				throw new AppException($"Error incrementing login values for user '{username}'.");
			}

			return GenerateClaims(user, username);
		}

		/// <summary>
		/// Creates the user claims.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <returns></returns>
		public IEnumerable<Claim> CreateUserClaims(string username)
		{
			var user = SecurityRepository.GetUser(username);

			// Can't find the user in the database
			if (user == null || user.Id <= 0)
			{
				Logger.LogInformation($"User Claims: Unable to find user with username '{username}'.");
				return new List<Claim>();
			}

			return GenerateClaims(user, username);
		}

		public string GetTokenUserIdValue()
		{
			// Precondition - Context Exists
			if (Context.HttpContext == null)
			{
				return null;
			}

			if (!Context.HttpContext.User.Identity.IsAuthenticated)
			{
				return null;
			}

			var name = Context.HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))?.Value;
			if (string.IsNullOrEmpty(name))
			{
				return null;
			}
			return name;
		}

		/// <summary>
		/// Returns the authenticated user or null if no user is authenticated
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns>
		/// Authenticated User or null if no user is authenticated
		/// </returns>
		public IAuthenticatedUser GetAuthenticatedUser(string name = null)
		{
			if (string.IsNullOrEmpty(name))
			{
				// Precondition - Context Exists
				if (Context.HttpContext == null)
				{
					return null;
				}

				if (!Context.HttpContext.User.Identity.IsAuthenticated)
				{
					return null;
				}

				name = Context.HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"))?.Value;
				if (string.IsNullOrEmpty(name))
				{
					return null;
				}
			}

			if (MemoryCache == null)
			{
				return SecurityRepository.GetAuthenticatedUser(name);
			}

			return MemoryCache.GetOrCreate(GetCacheKey(name), f => SecurityRepository.GetAuthenticatedUser(name));
		}

		/// <inheritdoc />
		public bool IsAuthorised(SecurityPermission permission, int? facilityId = null, string username = null)
		{
			var authenticatedUser = GetAuthenticatedUser(username);

			if (authenticatedUser == null)
			{
				// Log the warning
				Logger.LogInformation($"Authorisation: Could retrieve the authenticated user '{username}' when checking the users permissions.");
				return false;
			}

			var isAuthorised = authenticatedUser.Roles
				.Any(r => (
					(facilityId.HasValue && r.SchoolId == facilityId.Value) || r.IsFacilityWide)
					&& r.Permissions.Any(p => p == permission));

			if (!isAuthorised)
			{
				// Log the warning
				Logger.LogInformation($"Authorisation: An attempt was made to access a resource protected by the permission '{Enum.GetName(typeof(SecurityPermission), permission)}' by the user '{username}'.");
			}

			return isAuthorised;
		}

		/// <inheritdoc />
		public bool IsAuthorisedInAnyFacility(SecurityPermission permission, string username = null)
		{
			var user = GetAuthenticatedUser(username);
			return user.Roles.Any(r => r.Permissions.Any(p => p == permission));
		}

		/// <inheritdoc />
		public void CheckAuthorisationInAnyOneFacility(SecurityPermission permission, int?[] facilityIds)
		{
			// Get the current logged in user
			var authenticatedUser = GetAuthenticatedUser();

			if (authenticatedUser == null)
			{
				// Log the unauthorised access
				Logger.LogError($"Permission Check: Couldn't retrieve the current authenticated user when checking the users permissions.");
				throw new UnauthorizedAccessException();
			}

			// Determine whether the user is permitted
			var isAuthorised = authenticatedUser.Roles
				.Any(r => (r.IsFacilityWide || facilityIds.Contains(r.SchoolId))
					&& r.Permissions.Any(p => p == permission));

			// Unauthorised!
			if (!isAuthorised)
			{
				// Log the unauthorised access
				Logger.LogError(new EventId(authenticatedUser.Id), $"Permission Check: User '{authenticatedUser.Username}' attempted to access a restricted resource. The user was not in at least one facility in the following list: '{string.Join(",", facilityIds)}'.");
				throw new UnauthorizedAccessException();
			}

			// Success!
			return;
		}

		/// <inheritdoc />
		public IEnumerable<int> GetExplicitlyAuthorisedFacilities(SecurityPermission permission, string username)
		{
			var user = GetAuthenticatedUser(username);
			var roles = user.Roles
							.Where(r => !r.IsFacilityWide && r.Permissions.Any(p => p == permission))
							.Select(f => f.SchoolId.Value).ToList();

			return roles;
		}

		/// <inheritdoc />
		public bool IsAuthorisedFacilityWide(SecurityPermission permission, string username = null)
		{
			var user = GetAuthenticatedUser(username);
			return user.Roles.Any(r => r.IsFacilityWide && r.Permissions.Any(p => p == permission));
		}

		private static string GetCacheKey(string username)
		{
			return $"Cpt_Security_User_{username}";
		}

		/// <summary>
		/// Generates the claims.
		/// </summary>
		/// <param name="user">The user.</param>
		/// <param name="username">The username.</param>
		/// <returns></returns>
		private IEnumerable<Claim> GenerateClaims(User user, string username)
		{
			// Get the user
			//var authUser = SecurityRepository.GetAuthenticatedUser(username);

			var expiresIn =
				new DateTimeOffset(DateTime.Now.AddMinutes(Configuration.PcbAppSettings.DataSettings.JwtLifetime)).ToUnixTimeSeconds().ToString();

			// Generate the base claims
			// TODO: Make the claims JwtRegisteredClaimNames RFC Compliant!!!
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
				new Claim("email", user.EmailAddress),
				new Claim("givenname", user.GivenNames),
				new Claim("surname", user.FamilyName),
				new Claim(JwtRegisteredClaimNames.Exp, expiresIn)

				// Include this when you'd like to invalidate roles when you change a users role in the app and want
				// their cookie to expire.
				// new Claim("LastChanged", {Database Value})
			};

			// Add roles, and collect permissions as we go.
			var permissions = new Dictionary<SecurityPermission, HashSet<int>>();
			var roles = new List<string>();
			foreach (var role in user.UserRole)
			{
				// Add role name if it doesn't already exist in our list.
				if (!roles.Any(r => string.Equals(r.ToLower(new CultureInfo("en-AU")), role.Role.Title.ToLower(new CultureInfo("en-AU")), StringComparison.Ordinal)))
				{
					roles.Add(role.Role.Title);
					roles.Add(role.Role.Rank.ToString());
					roles.Add(role.IsCountryWide.ToString());
					roles.Add(role.SchoolId.ToString());
				}
				// TODO add permissions in later
				//foreach (var permission in role.)
				//{
				//	// Get the permission
				//	var permissionName = Enum.GetName(typeof(SecurityPermission), permission);

				//	Debug.Assert(
				//		!string.IsNullOrEmpty(permissionName),
				//		"A security permission exists in the database that you haven't added to the enum SecurityPermission.");

				//	// The permission has to exist in the Enum!
				//	if (string.IsNullOrEmpty(permissionName))
				//	{
				//		Logger.LogError("Authentication: A security permission exists in the database that you haven't added to the enum SecurityPermission. This permission will be ignored.");
				//		continue;
				//	}

				//	// If this permission has been initialised by another role, add to it.
				//	if (permissions.ContainsKey(permission))
				//	{
				//		// If already facility wide, loop
				//		var permissionFacilities = permissions[permission];
				//		var isFacilityWide = permissionFacilities == null || permissionFacilities.Count == 0;
				//		if (isFacilityWide)
				//		{
				//			continue;
				//		}

				//		// If this permission is facility wide, clear exists values to mark it as facility wide
				//		if (role.IsFacilityWide)
				//		{
				//			permissionFacilities.Clear();
				//			continue;
				//		}

				//		// Add this facility to the list
				//		permissionFacilities.Add(role.SchoolId.Value);
				//		continue;
				//	}

				//	// Add this permission to the list
				//	permissions.Add(permission, new HashSet<int>(!role.IsFacilityWide ? new[] { role.SchoolId.Value } : Array.Empty<int>()));
				//}
			}

			// Add the users role as a claim
			var rolesJson = Newtonsoft.Json.JsonConvert.SerializeObject(roles);
			claims.Add(new Claim("roles", rolesJson));

			// Add the new permissions claims
			//var permissionsJson = Newtonsoft.Json.JsonConvert.SerializeObject(permissions);
			//claims.Add(new Claim("permissions", permissionsJson));

			MemoryCache?.Remove(GetCacheKey(user.EmailAddress));

			// We authenticated!
			Logger.LogInformation($"Authentication: Login successful for user '{user.EmailAddress}'.");
			return claims;
		}

		/// <summary>
		/// Returns the authenticator configured in appsettings.json
		/// </summary>
		/// <returns></returns>
		private IAuthenticator GetAuthenticator()
		{
			switch (Configuration.PcbAppSettings.SecuritySettings.UseType)
			{
				default:
					return new NoneAuthenticator(Configuration, Logger);

			}
		}
	}
}
