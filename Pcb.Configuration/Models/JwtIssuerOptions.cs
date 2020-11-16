namespace Pcb.Configuration.Models
{
	public class JwtIssuerOptions
	{
		public virtual string Issuer { get; set; }

		public virtual string Audience { get; set; }

		public virtual string Key { get; set; }

		// The accepted clock skew, in minutes.
		public virtual int? ClockSkew { get; set; }
	}
}
