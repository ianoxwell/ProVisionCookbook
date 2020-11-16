namespace Pcb.Dto.Security
{
    /// <summary>
    /// The class that defines a role permission mapping
    /// </summary>
    public class RolePermissionMapping
    {
        /// <summary>
        /// The permission identifier
        /// </summary>
        public int PermissionId { get; set; }

        /// <summary>
        /// The role identifier
        /// </summary>
        public int RoleId { get; set; }
    }
}
