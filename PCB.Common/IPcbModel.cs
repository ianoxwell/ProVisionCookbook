namespace Pcb.Common
{
	/// <summary>
	/// Base interface for models in IHT
	/// </summary>
	public interface IPcbModel
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		int Id { get; set; }

		/// <summary>
		/// Gets or sets the row version.
		/// </summary>
		/// <value>
		/// The row version.
		/// </value>
		string RowVer { get; set; }
	}
}
