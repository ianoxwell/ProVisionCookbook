using Pcb.Common;
using System;

namespace Pcb.Dto.User
{
	public class RegisterUserDto : PcbModel
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }
		public string Password { get; set; }
		public string PhotoUrl { get; set; }
		public DateTime? Verified { get; set; }

		public string LoginProvider { get; set; }
		public string LoginProviderId { get; set; }

	}
}
