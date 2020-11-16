using System;

namespace Pcb.Dto.Security
{
    public class PermissionGroupSummary
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
