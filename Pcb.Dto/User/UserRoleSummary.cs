using Pcb.Common;
using System.Collections.Generic;

namespace Pcb.Dto.User
{
    public class UserRoleSummary : PcbModel
    {
        public int RoleId { get; set; }

        public string Role { get; set; }

        public int Rank { get; set; }

        public bool IsFacilityWide { get; set; }

        public IEnumerable<UserFacilitySummary> FacilitySummary { get; set; }
    }
}
