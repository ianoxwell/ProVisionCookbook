namespace Pcb.Dto.User
{
    /// <summary>
    /// This class is used to display user role facility details in user profile.
    /// </summary>
    public class UserProfileRoleFacilties
    {
        /// <summary>
        /// The user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The role id.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// The role.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Is role assigned for all facilities.
        /// </summary>
        public bool IsFacilityWide { get; set; }

        /// <summary>
        /// The facility names.
        /// </summary>
        public string Facilities { get; set; }
    }
}
