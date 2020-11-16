using Pcb.Common;
using Pcb.Dto.School;
using Pcb.Dto.Security;
using System;

namespace Pcb.Dto.User
{
    public class UserRoleDto : PcbModel
    {

        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int? SchoolId { get; set; }
        public bool IsCountryWide { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public SchoolDto School { get; set; }
        public RoleDto Role { get; set; }
    }
}
