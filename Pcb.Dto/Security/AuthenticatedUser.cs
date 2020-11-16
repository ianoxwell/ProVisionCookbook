using System.Collections.Generic;

namespace Pcb.Dto.Security
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string GivenNames { get; set; }

        public string FamilyName { get; set; }

        public IEnumerable<ISchoolRoleSummary> Roles { get; set; }
    }
}
