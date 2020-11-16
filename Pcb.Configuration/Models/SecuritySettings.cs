namespace Pcb.Configuration.Models
{
	public class SecuritySettings
	{
		/// <summary>
		/// The authentication type the application will use.
		/// Current valid strings: "ActiveDirectory", "None"
		/// </summary>
		public virtual string UseType { get; set; }

		/// <summary>
		/// Minimum password length. Allows us to save a hit to the authentication
		/// service for obviously incorrect passwords.
		/// </summary>
		public virtual int MinimumPasswordLength { get; set; } = 1;

		/// <summary>
		/// Minimum username length. Allows us to save a hit to the authentication
		/// service for obviously incorrect usernames.
		/// </summary>
		public virtual int MinimumUsernameLength { get; set; } = 1;

		/// <summary>
		/// Jwt (JSON Web Token) options.
		/// </summary>
		public virtual JwtIssuerOptions JwtIssuerOptions { get; set; }
	}
}
