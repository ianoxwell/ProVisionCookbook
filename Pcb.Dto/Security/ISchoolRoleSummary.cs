using System.Collections.Generic;

namespace Pcb.Dto.Security
{
    public interface ISchoolRoleSummary
    {
        string RoleName { get; set; }

         int Rank { get; set; }

        int? SchoolId { get; set; }

        bool IsFacilityWide { get; set; }

        IEnumerable<SecurityPermission> Permissions { get; set; }
    }
}
