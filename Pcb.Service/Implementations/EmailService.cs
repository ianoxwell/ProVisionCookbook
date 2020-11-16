using Microsoft.Extensions.Logging;
using Pcb.Common;
using Pcb.Configuration;
using Pcb.Database;
using Pcb.Database.Context;
using Pcb.Service.Interfaces;
using System.Net;
using System.Net.Mail;


namespace Pcb.Service.Implementations
{
	public class EmailService : ServiceBase<PcbDbContext>, IEmailService
	{
		public EmailService(
			IPcbConfiguration configurationService,
			ILogger<EmailService> logger)
			: base(configurationService, logger)
		{

		}

		public void Send(string to, string subject, string html, string from = null)
		{
			MailAddress maFrom = new MailAddress(from ?? Configuration.PcbAppSettings.DataSettings.EmailFrom);
			MailAddress maTo = new MailAddress(to);

			MailMessage email = new MailMessage(maFrom, maTo)
			{
				Subject = subject,
				IsBodyHtml = true,
				Body = EmailTemplate.EmailTop + html + EmailTemplate.EmailBottom
			};


			SmtpClient client = new SmtpClient("smtp.mailtrap.io", 2525)
			{
				Credentials = new NetworkCredential("8f724484a60875", "61d656e0cbf7f7"),
				EnableSsl = true
			};
			client.Send(email);

		}

	}
}
