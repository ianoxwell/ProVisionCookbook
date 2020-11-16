using System.Collections.Generic;

namespace Pcb.Common
{
		/// <inheritdoc />
	public class PagedResult<T> : IPagedResult<T>
	{
		/// <inheritdoc />
		public IList<T> Items { get; set; } = new List<T>();

		/// <inheritdoc />
		public int TotalCount { get; set; } = 0;
	}
}
