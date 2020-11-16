using Pcb.Common;
using System;

namespace Pcb.Dto.Security
{
    public class RoleDto : PcbModel
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public int Rank { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsUser { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
