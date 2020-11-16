using Pcb.Common;
using System;
using System.Collections.Generic;

namespace Pcb.Dto.User
{
	public class UserProfileDto : PcbModel
	{

		public string FullName { get; set; }
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }
		public string PhotoUrl { get; set; }
		public DateTime? Verified { get; set; }

		public bool IsVerified { get; set; }

		public bool IsActive { get; set; }
		public bool IsStudent { get; set; }

		public string LoginProvider { get; set; }
		public string LoginProviderId { get; set; }
		public int TimesLoggedIn { get; set; }
		public DateTime FirstLogin { get; set; }

		public DateTime LastLogin { get; set; }
		public DateTime? Updated { get; set; }
		public DateTimeOffset CreatedAt { get; set; }
		public List<UserRoleDto> UserRole { get; set; }
	}
}
