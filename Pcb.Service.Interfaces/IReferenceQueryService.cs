using System;
using System.Collections.Generic;
using Pcb.Dto.Reference;

namespace Pcb.Service.Interfaces
{
	/// <summary>
	/// The Reference Query Service Interface
	/// </summary>
	public interface IReferenceQueryService
	{
		/// <summary>
		/// Gets all reference items of the given type active as at the passed activeDate.
		/// No activeDate will return items active now.
		/// Cached.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="activeDate">The active date.</param>
		/// <param name="includeId">The include identifier.</param>
		/// <returns></returns>
		IEnumerable<IReferenceItemFull> GetActive(
			ReferenceType type,
			DateTime? activeDate = null,
			int? includeId = null);

		/// <summary>
		/// Gets all reference items, including ended, for a type.
		/// Cached.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		IEnumerable<IReferenceItemFull> GetAll(ReferenceType type);

		/// <summary>
		/// Gets metadata about a reference type for editing purposes.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns></returns>
		IEnumerable<ReferenceMeta> GetMeta(ReferenceType type);

		/// <summary>
		/// Gets a reference context with metadata and a reference item to enable generic view/edit.
		/// Data fetch is cached.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		ReferenceContext GetContext(ReferenceType type, int? id = null);

		/// <summary>
		/// Gets a reference context reference data to enable generic view/edit.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		IDictionary<string, IEnumerable<IReferenceItem>> GetContextRefData(ReferenceType type, int? id = null);

		/// <summary>
		/// Returns a page of search results for the passed filters.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="searchText">The search text.</param>
		/// <param name="sortField">The sort field.</param>
		/// <param name="sortDirection">The sort direction.</param>
		/// <param name="pageIndexBaseZero">The page index base zero.</param>
		/// <returns></returns>
		Common.IPagedResult<IReferenceItemFull> Search(
			ReferenceType type,
			string searchText = null,
			string sortField = null,
			string sortDirection = null,
			int? pageIndexBaseZero = null);

		/// <summary>
		/// Clears the cache for the specified reference type.
		/// </summary>
		/// <param name="type">The type.</param>
		void InvalidateCache(ReferenceType type);
	}
}
