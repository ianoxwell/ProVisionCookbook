namespace Pcb.Configuration.Models
{
	public class DataSettings
	{
		public virtual string Website { get; set; }

		public virtual int PageSize { get; set; }

		public virtual int QueryRetryCount { get; set; }

		public virtual int QueryTimeout { get; set; }

		public virtual int CommandRetryCount { get; set; }

		public virtual int CommandTimeout { get; set; }

		public virtual int JwtLifetime { get; set; }

		public virtual int JwtRefreshLifetime { get; set; }
		public virtual int MaxLoginAttempts { get; set; }
		public virtual int LockOutTime { get; set; }

		public virtual int InactivitySecs { get; set; }

		public virtual string DataDirectory { get; set; }

		public virtual string InterfaceLogPageSize { get; set; }
		public virtual string EmailFrom { get; set; }
		public virtual string SmtpHost { get; set; }
		public virtual int SmtpPort { get; set; }
		public virtual string SmtpUser { get; set; }
		public virtual string SmtpPass { get; set; }
	}
}
