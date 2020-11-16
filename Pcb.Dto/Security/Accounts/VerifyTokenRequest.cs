using System.ComponentModel.DataAnnotations;

namespace Pcb.Dto.Security.Accounts
{
	public class VerifyTokenRequest
	{
		[Required]
		public string Token { get; set; }
	}
}
