using System.ComponentModel.DataAnnotations;

namespace Pcb.Api.Auth
{
	/// <summary>
	/// The User Refresh Class
	/// </summary>
	public class UserRefresh
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UserRefresh"/> class.
		/// </summary>
		public UserRefresh()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="UserRefresh" /> class.
		/// </summary>
		/// <param name="username">The username.</param>
		/// <param name="refreshToken">The refresh token.</param>
		public UserRefresh(string username, string refreshToken)
		{
			Username = username;
			RefreshToken = refreshToken;
		}

		/// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		/// <value>
		/// The name of the user.
		/// </value>
		[Required]
		[StringLength(25)]
		[Display(Name = "User name")]
		public string Username { get; set; }

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>
		/// The password.
		/// </value>
		[Required]
		[StringLength(50)]
		public string RefreshToken { get; set; }
	}
}
