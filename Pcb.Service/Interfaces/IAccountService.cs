using Pcb.Dto.Api;
using Pcb.Dto.Security.Accounts;
using Pcb.Dto.User;
using System.Threading.Tasks;

namespace Pcb.Service.Interfaces
{
	public interface IAccountService
	{
		bool UserNameExists(string name);
		Task<int> RegisterUser(RegisterUserDto userDto, string origin);
		Task<UserProfileDto> GetSingleUser(int userId);
		Task<bool> VerifyEmail(string token);
		Task<MessageResultDto> ForgotPassword(ForgotPasswordRequest model, string origin);
		Task<bool> ValidateResetToken(VerifyTokenRequest model);
		Task<MessageResultDto> ResetPassword(ResetPasswordRequest model);
	}
}
