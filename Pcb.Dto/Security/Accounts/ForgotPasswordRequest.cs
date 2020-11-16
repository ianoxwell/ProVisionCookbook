using System.ComponentModel.DataAnnotations;

namespace Pcb.Dto.Security.Accounts
{
	public class ForgotPasswordRequest
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
	}
}
