using System;
using System.Collections.Generic;
using System.Text;

namespace Pcb.Dto.Security
{
    public class ApplicableRank 
    {
        public int UserId { get; set; }
        public int Rank { get; set; }
        public IEnumerable<int?> FacilityId { get; set; }
        public bool IsFacilityWide { get; set; }
    }
}
