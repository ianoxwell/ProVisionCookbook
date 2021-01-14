using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pcb.Dto.Api;
using Pcb.Dto.Security.Accounts;
using Pcb.Dto.User;
using Pcb.Service.Interfaces;

namespace Pcb.Api.Controllers
{
	[Route("api/v1/account")]
	[ApiController]
	[AllowAnonymous]
	[Produces("application/json")]
	public class AccountController : ControllerBase
	{
		/// <summary>
		/// The user service.
		/// </summary>
		private readonly IAccountService AccountService;

		public AccountController(
			IAccountService accountService
			)
		{
			AccountService = accountService;
		}

		[HttpPost("register")]
		[ProducesResponseType(200, Type = typeof(MessageResultDto))]

		public IActionResult Register(RegisterUserDto model)
		{
			if (!AccountService.UserNameExists(model.Email))
			{
				return Ok(new { message = "Email address is already registered" });
			}
			int user = AccountService.RegisterUser(model, Request.Headers["origin"]).Result;

			return Ok(new { message = user });
		}

		[HttpPost("verify-email")]
		[ProducesResponseType(200, Type = typeof(MessageResultDto))]
		public IActionResult VerifyEmail(VerifyTokenRequest model)
		{
			bool result = AccountService.VerifyEmail(model.Token).Result;
			return Ok(new { message = result ? "Verification successful, you can now login" : "Verification Failed" });
		}

		[HttpPost("forgot-password")]
		[ProducesResponseType(200, Type = typeof(MessageResultDto))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public IActionResult ForgotPassword(ForgotPasswordRequest model)
		{
			MessageResultDto result = AccountService.ForgotPassword(model, Request.Headers["origin"]).Result;
			if (result.Message == "No email received")
			{
				return BadRequest(result);
			}
			if (result.Message.Contains("No email address like"))
			{
				return NotFound(result);
			}
			return Ok(result);
		}

		[HttpPost("validate-reset-token")]
		[ProducesResponseType(200, Type = typeof(MessageResultDto))]

		public IActionResult ValidateResetToken(VerifyTokenRequest model)
		{
			bool result = AccountService.ValidateResetToken(model).Result;
			return Ok(new { message = result ? "Token is valid" : "Invalid Token" });
		}

		[HttpPost("reset-password")]
		[ProducesResponseType(200, Type = typeof(MessageResultDto))]
		public IActionResult ResetPassword(ResetPasswordRequest model)
		{
			MessageResultDto result = AccountService.ResetPassword(model).Result;
			return Ok(result);
		}
		[HttpGet("email-available")]
		[ProducesResponseType(200, Type = typeof(bool))]
		public IActionResult CheckEmailAddressUsed(string email)
		{
			bool userNameExists = AccountService.UserNameExists(email);
			return Ok(userNameExists);
		}

		[HttpGet("get-account")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[ProducesResponseType(200, Type = typeof(UserProfileDto))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult GetUserProfile(int id)
		{
			if (id == 0)
			{
				return BadRequest(new { message = "Invalid user ID" });
			}
			UserProfileDto account = AccountService.GetSingleUser(id).Result;
			if (account == null)
			{
				return NotFound(new { message = "Account not found or permitted" });
			}
			return Ok(account);

		}
	}
}
