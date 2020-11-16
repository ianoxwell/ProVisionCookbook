using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pcb.Dto.Security;
using Pcb.Dto.User;
using Pcb.Security.Authorisation;
using Pcb.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pcb.Api.Controllers.Admin
{
    /// <summary>
    /// The User Controller
    /// </summary>
    /// <seealso cref="Controller" />
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/v1/admin/users")]
    [ApiController]
    public class UserController : Controller
    {
        /// <summary>
        /// The user service instance from DI.
        /// </summary>
        private IUserService UserService { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        /// <summary>
        /// Returns a user based on their user id
        /// </summary>
        /// <param name="id">The user's id</param>
        /// <returns>A user, their roles and the facilities those roles are applied in.</returns>
        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            // there will be no users with a 0 or below id.
            if (id <= 0)
            {
                return new BadRequestResult();
            }

            var user = await UserService.GetAsync(id);

            // nothing found? return a no content result.
            if (user == null)
            {
                return new NoContentResult();
            }

            return Json(user);
        }

        /// <summary>
        /// Returns a list of users given a sort, order, filter and page number.
        /// </summary>
        /// <param name="sort">Target property for sorting</param>
        /// <param name="order">Target property order e.g. asc or desc</param>
        /// <param name="filter">Search applied to log messages</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <returns>
        /// A list of users that meet the provided parameters
        /// </returns>
        [Route("")]
        [HttpGet]
        [PermissionRequirement(SecurityPermission.AdministerUsers)]
        public async Task<IActionResult> GetList(string sort = "familyName", string order = "asc", string filter = "", int pageIndex = 0)
        {
            var users = await UserService.GetUserSummaryAsync(sort, order, filter, pageIndex);
            return Json(users);
        }

        /// <summary>
        /// Gets the user profile based on their user id.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        /// <returns></returns>
        [Route("profile/{id:int}")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProfile(int id)
        {
            // there will be no users with a 0 or below id.
            if (id <= 0)
            {
                return new BadRequestResult();
            }

            var user = await UserService.GetProfileAsync(id);

            // nothing found? return a no content result.
            if (user == null)
            {
                return new NoContentResult();
            }

            return Json(user);
        }

        /// <summary>
        /// Saves the users profile settings
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        [Route("profile")]
        [HttpPost]
        [Authorize]
        public IActionResult SaveProfile([FromBody] UserProfile data)
        {
            var result = UserService.SaveProfile(data);
            return Json(result);
        }

        /// <summary>
        /// Saves the user and its associated role/facility mapping
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        [Route("save")]
        [HttpPost]
        [PermissionRequirement(SecurityPermission.AdministerUsers)]
        public IActionResult SaveUserAndRoles([FromBody] UserRoleFacility data)
        {
            var result = UserService.SaveUserAndRoles(data, true, false);
            return Json(result);
        }

        /// <summary>
        /// Toggles the active status for the given user
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        [Route("togglestatus")]
        [HttpPost]
        [PermissionRequirement(SecurityPermission.AdministerUsers)]
        public IActionResult ToggleUserStatus([FromBody] UserSummary data)
        {
            var result = UserService.ToggleUserStatus(data);
            return Json(result);
        }

        /// <summary>
        /// Adds a user selected in the user search dialog to the selected facility
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        [Authorize]
        [Route("addusertofacility")]
        [HttpPost]
        [PermissionRequirement(SecurityPermission.AdministerUsers)]
        public async Task<IActionResult> AddUserToFacility([FromBody] AddUserToFacilityRequest data)
        {
            var isSuccessful = await UserService.AddUserToFacilityAsync(data.UserInfo, data.FacilityIds, data.RoleId);
            return Json(isSuccessful);
        }

        /// <summary>
        /// Gets the list of users in a given facility
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="includeIds">The include ids.</param>
        /// <returns></returns>
        [Route("facilityusers")]
        [HttpGet]
        [Authorize]
        public IActionResult GetUsersInFacility(int facilityId, string includeIds = null)
        {
            IEnumerable<int> includedIds = null;

            // Sanity
            if (!string.IsNullOrWhiteSpace(includeIds))
            {
                // User can pass in multiple ids
                includedIds = includeIds.Split(',').Select(int.Parse).ToList();
            }

            var users = UserService.GetUsersInFacility(facilityId, includedIds);
            return Json(users);
        }

        /// <summary>
        /// Gets the list of users
        /// </summary>
        /// <returns></returns>
        [Route("allusers")]
        [HttpGet]
        [Authorize]
        public IActionResult GetAllUsers()
        {
            var users = UserService.GetAllUsers();
            return Json(users);
        }

        /// <summary>
        /// Gets the users for user search dialog box in transfer form
        /// </summary>
        /// <param name="familyName">The family name.</param>
        /// <param name="givenNames">The given names.</param>
        /// <returns></returns>
        [Route("usersearchprefill")]
        [HttpGet]
        [Authorize]
        public IActionResult GetUsersForUserSearch(string familyName, string givenNames)
        {
            var users = UserService.GetUsersForUserSearch(familyName, givenNames);
            return Json(users);
        }
    }
}
