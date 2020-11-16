using System.Collections.Generic;

namespace Pcb.Common
{
	/// <summary>
	/// A simple interface for returning a list of paged items.
	/// </summary>
	/// <typeparam name="T">Paged result</typeparam>
	public interface IPagedResult<T>
	{
		/// <summary>
		/// Gets the items.
		/// </summary>
		/// <value>
		/// The items.
		/// </value>
		IList<T> Items { get; }

		/// <summary>
		/// Gets the total count.
		/// </summary>
		/// <value>
		/// The total count.
		/// </value>
		int TotalCount { get; }
	}
}
