namespace Pcb.Configuration.Models
{
	public class ConnectionStrings
	{
		/// <summary>
		/// Query Connection string. Used for read only queries.
		/// </summary>
		public virtual string Migration { get; set; }

		/// <summary>
		/// Query Connection string. Used for read only queries.
		/// </summary>
		public virtual string Query { get; set; }

		/// <summary>
		/// Command connection string. Used for write only queries.
		/// </summary>
		public virtual string Command { get; set; }
	}
}
