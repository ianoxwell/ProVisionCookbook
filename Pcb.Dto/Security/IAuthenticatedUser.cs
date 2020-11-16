
using System.Collections.Generic;

namespace Pcb.Dto.Security
{
    public interface IAuthenticatedUser
    {
        int Id { get; }

        string Username { get; }

        string GivenNames { get; }

        string FamilyName { get; }

        IEnumerable<ISchoolRoleSummary> Roles { get; }
    }
}
