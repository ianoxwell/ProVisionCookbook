using System.Collections.Generic;

namespace Pcb.Dto.User
{
	public class AddUserToFacilityRequest
	{
		public UserSummary UserInfo { get; set; }
		public List<int> FacilityIds { get; set; }
		public int RoleId { get; set; }
	}
}
