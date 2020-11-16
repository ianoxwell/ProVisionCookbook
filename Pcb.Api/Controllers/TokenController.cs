using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pcb.Api.Auth;
using Pcb.Configuration;
using Pcb.Security;
using Pcb.Security.Authorisation;
using Pcb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Pcb.Api.Controllers
{
	/// <summary>
	/// Primary JWT controller used for authentication.
	/// </summary>
	//[Route("api/v1/token")]

	[ApiController]
	[Produces("application/json")]
	[AllowAnonymous]
	public class TokenController : Controller
	{
		/// <summary>
		/// The configuration instance from DI.
		/// </summary>
		private IPcbConfiguration Config { get; }

		/// <summary>
		/// The Pcb security service instance from DI.
		/// </summary>
		private IPcbSecurityService PcbSecurityService { get; }

		/// <summary>
		/// The security service instance from DI.
		/// </summary>
		private ISecurityService SecurityService { get; }

		/// <summary>
		/// The Jwt factory instance from DI.
		/// </summary>
		private IJwtFactory JwtFactory { get; }

		/// <summary>
		/// The logger instance from DI.
		/// </summary>
		private ILogger<TokenController> Logger { get; }

		/// <summary>
		/// The user service.
		/// </summary>
		private IUserService UserService;

		/// <summary>
		/// Initialises a new instance of the <see cref="TokenController"/> class.
		/// Constructor
		/// </summary>
		/// <param name="userService">The user service.</param>
		/// <param name="config">The configuration.</param>
		/// <param name="pcbSecurityService">The Pcb security service.</param>
		/// <param name="securityService">The security service.</param>
		/// <param name="jwtFactory">The JWT factory.</param>
		/// <param name="logger">The logger.</param>
		public TokenController(
				IUserService userService,
				IPcbConfiguration config,
				IPcbSecurityService pcbSecurityService,
				ISecurityService securityService,
				IJwtFactory jwtFactory,
				ILogger<TokenController> logger)
		{
			UserService = userService;
			Config = config;
			PcbSecurityService = pcbSecurityService;
			SecurityService = securityService;
			JwtFactory = jwtFactory;
			Logger = logger;
		}

		/// <summary>
		/// Creates a bearer jwt based on a username and password.
		/// </summary>
		/// <param name="model">Username and password</param>
		/// <returns>
		/// A JWT with appropriate claims and a refresh token
		/// </returns>
		[Route("api/v1/token/create")]
		[HttpPost]
		public IActionResult Create([FromBody] UserAccount model)
		{
			// Validate input
			if (!ModelState.IsValid)
			{
				Logger.LogInformation("Token Controller: The model provided to the controller was not valid!");
				return BadRequest();
			}


			// Try and generate a token
			return TryPassword(model.Email, model.Password, false);
		}

		/// <summary>
		/// Attempts to reissue a access token using a refresh token (GUID)
		/// </summary>
		/// <param name="model">Username and Refresh Token</param>
		/// <returns>
		/// A JWT with appropriate claims and a refresh token
		/// </returns>
		[Route("api/v1/token/refresh")]
		[HttpPost]
		public IActionResult Refresh([FromBody] UserRefresh model)
		{
			// Validate input
			if (!ModelState.IsValid)
			{
				Logger.LogInformation("Refresh Token: The model provided to the controller was not valid!");
				return BadRequest();
			}

			// We can only refresh if we have a token!
			if (string.IsNullOrWhiteSpace(model.RefreshToken))
			{
				Logger.LogInformation("Refresh Token: No Refresh Token was provided in the request!");
				return BadRequest();
			}

			// Try to reissue the token
			return TryRefreshToken(model.RefreshToken, model.Username);
		}

		/// <summary>
		/// Creates a bearer jwt based on a username and password.
		/// </summary>
		/// <param name="email">Users google email address</param>
		/// <returns>
		/// A JWT with appropriate claims and a refresh token
		/// </returns>
		[Route("/token/google")]
		[GoogleAuthorise]
		[HttpGet]
		public IActionResult CreateJwtFromGooggle(string email)
		{
			// Try and generate a token
			return TryPassword(email, null, true);
		}

		/// <summary>
		/// Gets the JWT and constructs the result.
		/// </summary>
		/// <param name="refreshToken">The refresh token.</param>
		/// <param name="claims">The claims.</param>
		/// <returns></returns>
		private JsonResult GetJwt(string refreshToken, IEnumerable<Claim> claims)
		{
			var token = JwtFactory.GenerateToken(claims);

			var response = new
			{
				token,
				expiresIn = (int)TimeSpan.FromMinutes(Config.PcbAppSettings.DataSettings.JwtLifetime).TotalSeconds,
				refreshToken
			};

			return new JsonResult(response);
		}

		/// <summary>
		/// Issues an access token and a refresh token.
		/// </summary>
		/// <param name="email">Name of the user.</param>
		/// <param name="password">The password.</param>
		/// <param name="isSocial">is the login attempt already authenticated using a social Provider like Google.</param>
		/// <returns></returns>
		private IActionResult TryPassword(string email, string password, bool isSocial)
		{
			// Authenticate with credentials
			var claims = PcbSecurityService.Authenticate(email, password, isSocial).ToList();

			// Are there any claims?
			if (!claims.Any())
			{
				Logger.LogError($"Login: Password is invalid for '{email}'.");
				// increment failed attempt
				SecurityService.FailedPasswordAttempt(email, false);
				return BadRequest(new { message = "Password is invalid" });
			}
			if (claims.Count == 1 && claims[0].Type == "user")
			{
				return Ok(new { message = "Register new account" });
			}

			if (claims.Count == 1 && claims[0].Type == "verify")
			{
				return Ok(new { message = "Account not verified, please check your emails." });
			}

			if (claims.Count == 1 && claims[0].Type == "authentication")
			{
				return Ok(new { message = $"Lockout: {claims[0].Value}" });
			}

			// Failed Auth - Deactivated user
			if (claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub && c.Value == "0") != null)
			{
				Logger.LogError($"Login: Deactivated user attempted to login with username '{email}'.");
				return Forbid();
			}

			// Obtain a refresh token
			var refreshToken = SecurityService.GenerateRefreshToken(email, IpAddress());

			// Did we even get a token?
			if (string.IsNullOrWhiteSpace(refreshToken))
			{
				Logger.LogError("Login: No refresh token was generated from the security service.");
				return BadRequest(new { message = "No refresh token was generated from the security service." });
			}
			// Should be a successful login - reset any failed history
			SecurityService.FailedPasswordAttempt(email, true);

			var jwtToken = GetJwt(refreshToken, claims);


			// Return our tokens all polished up and ready to go!
			return jwtToken;
		}

		/// <summary>
		/// Tries the refresh token.
		/// On Success - Returns a new access token and a new refresh token
		/// </summary>
		/// <param name="refreshToken">The refresh token.</param>
		/// <param name="email">Name of the user.</param>
		/// <param name="ipAddress">IP Address of the request.</param>
		/// <returns></returns>
		private IActionResult TryRefreshToken(string refreshToken, string email)
		{
			// Refresh Token Valid?
			if (!SecurityService.IsRefreshTokenValid(email, refreshToken))
			{
				Logger.LogInformation("Refreshing Token: Cannot reissue a refresh token because the current refresh token has expired!");
				return NotFound();
			}

			// Get new claims
			var claims = PcbSecurityService.CreateUserClaims(email).ToList();

			// Are there any claims?
			if (!claims.Any())
			{
				Logger.LogError($"Refreshing Token: Cannot create claims for user '{email}'.");
				return Unauthorized();
			}

			// Expire the old refresh token
			// Create a new refresh token
			var newRefreshToken = SecurityService.GenerateRefreshToken(email, IpAddress(), refreshToken, true);

			// Did we even get a token?
			if (string.IsNullOrWhiteSpace(newRefreshToken))
			{
				Logger.LogError("Refreshing Token: No refresh token was generated from the security service.");
				return NotFound();
			}

			// Return our shiny tokens!
			return GetJwt(newRefreshToken, claims);
		}
		private string IpAddress()
		{
			if (Request.Headers.ContainsKey("X-Forwarded-For"))
				return Request.Headers["X-Forwarded-For"];
			else
				return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
		}

	}
}
