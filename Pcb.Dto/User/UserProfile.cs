using Pcb.Common;

namespace Pcb.Dto.User
{
	public class UserProfile : PcbModel
	{
		public int UserId { get; set; }

		public string GivenNames { get; set; }

		public string FamilyName { get; set; }

		public string Email { get; set; }

		public string PhoneNumber { get; set; }
	}
}
