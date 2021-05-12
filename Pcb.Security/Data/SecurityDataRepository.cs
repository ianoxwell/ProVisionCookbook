using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pcb.Configuration;
using Pcb.Database.Context;
using Pcb.Database.Context.Models;
using Pcb.Dto.Security;
using Pcb.Security.Authorisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Cpt.Security.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Pcb.Security.Data
{
    /// <inheritdoc cref="ISecurityDataRepository" />
    internal class SecurityDataRepository : ISecurityDataRepository
    {
        private IPcbConfiguration Configuration;
        private ILogger<PcbSecurityService> Logger;

        /// <inheritdoc cref="ISecurityDataRepository" />
        public SecurityDataRepository(IPcbConfiguration configuration, ILogger<PcbSecurityService> logger)
        {
            Configuration = configuration;
            Logger = logger;
        }

        /// <summary>
        /// Get a user by username
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public User GetUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return null;
            }

            using var _db = GetQueryDbContext();
            return _db.User.Where(u => u.EmailAddress.ToLower() == username.ToLower().Trim())
                .Include(x => x.UserRole).ThenInclude(y => y.Role)
                .FirstOrDefault();
        }

        /// <summary>
        /// Return a user from the DB as an IAuthenticatedUser. Note, this method
        /// does is not concerned with whether the user is actually authenticated. Rather it just
        /// returns the data for an Authentication service to use.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public IAuthenticatedUser GetAuthenticatedUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return null;
            }

            using var db = GetQueryDbContext();
            var authuser = db.User.Where(u => u.Username.Equals(username)).Select(au => new AuthenticatedUser
            {
                Id = au.Id,
                Username = au.Username,
                GivenNames = au.GivenNames,
                FamilyName = au.FamilyName
            }).SingleOrDefault();

            if (authuser == null)
            {
                return null;
            }

            authuser.Roles = db.UserRole.Where(ur => ur.UserId == authuser.Id).Select(rs => new SchoolRoleSummary
            {
                SchoolId = rs.SchoolId,
                IsFacilityWide = rs.IsCountryWide,
                RoleName = rs.Role.Title,
                Rank = rs.Role.Rank,
                Permissions = rs.Role.RolePermission.Select(p => (SecurityPermission)p.PermissionId).ToArray()
            }).ToList();

            return authuser;
        }

        /// <summary>
        /// Return permissions for a user in a facility
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="facilityId">The facility identifier.</param>
        /// <returns></returns>
        public IEnumerable<Permission> GetPermissions(string username, int? facilityId = null)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return Array.Empty<Permission>();
            }

            using var db = GetQueryDbContext();
            var permissions =
                    from u in db.User.Where(u => u.Username.Equals(username))
                    join ur in db.UserRole on u.Id equals ur.UserId
                    join rp in db.RolePermission on ur.RoleId equals rp.RoleId
                    join p in db.Permission on rp.PermissionId equals p.Id
                    where ur.IsCountryWide || (ur.SchoolId == facilityId)
                    select p;

            return permissions;
        }

        /// <summary>
        /// Increments the number of times the user has logged on and sets last login.
        /// Additional if the first login is not set (prior date to start of 2020)
        /// </summary>
        /// <param name="userId">The user Id to update</param>
        /// <returns></returns>
        public async Task<bool> IncrementLoginValues(int userId)
        {
            if (userId == 0) { return false; }
            var _db = GetCommandDbContext();
            var user = await _db.User.Where(u => u.Id == userId).SingleOrDefaultAsync();
            if (user == null) { return false; }
            user.LastLogin = DateTime.UtcNow;
            user.TimesLoggedIn += 1;
            DateTime testDate = new DateTime(2020, 1, 1, 0, 0, 0);
            if (DateTime.Compare(user.FirstLogin, testDate) < 0)
            {
                user.FirstLogin = DateTime.UtcNow;
            }
            _db.User.Update(user);
            return _db.SaveChanges() != 0;
        }

        /// <summary>
        /// Return the Pcb Security Db Context
        /// </summary>
        /// <returns></returns>
        private PcbDbContext GetQueryDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PcbDbContext>();
            optionsBuilder.UseSqlServer(Configuration.PcbAppSettings.ConnectionStrings.Query, t =>
            {
                t.EnableRetryOnFailure(maxRetryCount: 3);
                t.CommandTimeout(10);
            });

            return new PcbDbContext(optionsBuilder.Options);
        }

        private PcbDbContext GetCommandDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PcbDbContext>();
            optionsBuilder.UseSqlServer(Configuration.PcbAppSettings.ConnectionStrings.Command, t =>
            {
                t.EnableRetryOnFailure(maxRetryCount: 3);
                t.CommandTimeout(10);
            });

            return new PcbDbContext(optionsBuilder.Options);
        }
    }
}
