using System.Collections.Generic;
using Pcb.Database.Context.Models;

namespace Pcb.Dto.Security
{
    public class RoleManagement
    {
        public IEnumerable<RoleSummary> Roles { get; set; }

        public IEnumerable<PermissionGroupSummary> PermissionGroups { get; set; }

        public IEnumerable<PermissionSummary> Permissions { get; set; }

        public IEnumerable<RolePermission> RolePermissions { get; set; }
    }
}
