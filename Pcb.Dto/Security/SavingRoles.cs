using System.Collections.Generic;

namespace Pcb.Dto.Security
{
    /// <summary>
    /// The class that defines the data for saving roles
    /// </summary>
    public class SavingRoles
    {
        /// <summary>
        /// The delete permissions mapping array
        /// </summary>
        public IEnumerable<RolePermissionMapping> Delete { get; set; }

        /// <summary>
        /// The save permissions mapping array
        /// </summary>
        public IEnumerable<RolePermissionMapping> Save { get; set; }
}
}
