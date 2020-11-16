using System.Collections.Generic;

namespace Pcb.Dto.User
{
    /// <summary>
    /// Summary class for user, their roles and the facilities those roles belong to.
    /// </summary>
    public class UserRoleFacility : UserSummary
    {
        /// <summary>
        /// The Role summary for this user
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserRoleSummary> RoleSummary { get; set; }
    }
}
