using Newtonsoft.Json;

namespace Pcb.Configuration.Models
{
	/// <summary>
	/// AppSettings must mimic appsettings.json
	/// Please note, properties are virtualised for mocking in unit tests.
	/// Normally, we'd interface this class out to enable testing,
	/// however, using interfaces breaks the ability for dotnet core to
	/// bind values from appsettings.json to this class.
	/// [JsonIgnore] settings that should not be sent to the client app.
	/// </summary>\
	public class AppSettings
	{
		[JsonIgnore]
		public virtual ConnectionStrings ConnectionStrings { get; set; }
		[JsonIgnore]
		public virtual SecuritySettings SecuritySettings { get; set; }

		public virtual DataSettings DataSettings { get; set; }		

		public virtual string Environment { get; set; }

	}
}
