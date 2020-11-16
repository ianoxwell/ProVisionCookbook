using Pcb.Common;
using System;

namespace Pcb.Dto.User
{
	public class UserSummary : PcbModel
	{
		public string Username { get; set; }

		public string GivenNames { get; set; }

		public string FamilyName { get; set; }

		public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public bool IsActive { get; set; }

		public bool? IsAdmin { get; set; } = null;

		public bool IsNewUser { get; set; }
	}
}
