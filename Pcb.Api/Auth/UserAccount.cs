using System.ComponentModel.DataAnnotations;

namespace Pcb.Api.Auth
{
	/// <summary>
	/// The User Account Class
	/// </summary>
	public class UserAccount
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UserAccount"/> class.
		/// </summary>
		public UserAccount()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="UserAccount" /> class.
		/// </summary>
		/// <param name="email">Name of the user.</param>
		/// <param name="password">The password.</param>
		public UserAccount(string email, string password)
		{
			Email = email;
			Password = password;
		}

		/// <summary>
		/// Gets or sets the email of the user.
		/// </summary>
		/// <value>
		/// The email of the user.
		/// </value>
		[Required]
		[StringLength(50)]
		[Display(Name = "User name")]
		public string Email { get; set; }

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>
		/// The password.
		/// </value>
		[Required]
		[StringLength(50)]
		public string Password { get; set; }
	}
}
