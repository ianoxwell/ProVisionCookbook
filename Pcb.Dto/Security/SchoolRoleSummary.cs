using System.Collections.Generic;

namespace Pcb.Dto.Security
{
    public class SchoolRoleSummary : ISchoolRoleSummary
    {
        public string RoleName { get; set;  }
        public int Rank { get; set; }
        public int? SchoolId { get; set; }

        public bool IsFacilityWide { get; set; }

        public IEnumerable<SecurityPermission> Permissions { get; set; }        
    }
}
