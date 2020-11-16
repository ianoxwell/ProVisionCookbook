using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pcb.Common;

namespace Pcb.Dto.Reference
{
	/// <summary>
	/// A reference item collection that indexes items by Id and Date for performance lookups.
	/// Indexing is lazy and immutable.
	/// That is, the first time GetById() is called, it will index all Items by Id.
	/// If one of the items passed to the constructor has its Id updated, this will NOT be reflected in the index.
	/// It's expected that reference item changes will result in a new ReferenceItemCollection being created.
	/// </summary>

	public sealed class ReferenceItemCollection: IEnumerable<ReferenceItemFull>
	{
		private HashSet<ReferenceItemFull> Items { get; set; }


		/// <summary>
		/// Creates a collection from an existing bunch of items.
		/// We're expecting it to be all items of a given reference type,
		/// that we'll then index for quick Id or Date-based lookups.
		/// </summary>
		/// <param name="items"></param>
		public ReferenceItemCollection(IEnumerable<ReferenceItemFull> items = null) =>
			Items = items as HashSet<ReferenceItemFull> ?? new HashSet<ReferenceItemFull>(items ?? new ReferenceItemFull[] { });

		#region IEnumerable<ReferenceItemFull>

		public IEnumerator<ReferenceItemFull> GetEnumerator() => Items.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();

		#endregion

		#region Lazy Indexes- Indexes generated on first access that become invalid if the source ReferenceItemFull objects are changed.

		/// <summary>
		/// Order:1 lookup of a reference item by Id.
		/// </summary>
		private Dictionary<int, ReferenceItemFull> IdMap => _idMap != null
			? _idMap
			: (_idMap = Items.ToDictionary(i => i.Id));

		private Dictionary<int, ReferenceItemFull> _idMap = null;

		/// <summary>
		/// Order:Log(n) lookup of reference item by start date.
		/// </summary>
		private SortedList<DateTime, HashSet<ReferenceItemFull>> StartDateMap
		{
			get
			{
				// Return map if already computed
				if (_startDateMap != null)
				{
					return _startDateMap;
				}

				// Compute map and return it
				var tempMap = new SortedList<DateTime, HashSet<ReferenceItemFull>>();
				foreach (var item in Items)
				{
					if (tempMap.TryGetValue(item.StartDate, out HashSet<ReferenceItemFull> matchingStartItems))
					{
						matchingStartItems.Add(item);
						continue;
					}

					tempMap.Add(item.StartDate, new HashSet<ReferenceItemFull>(new ReferenceItemFull[] { item }));
				}

				_startDateMap = tempMap;
				return _startDateMap;
			}
		}

		private SortedList<DateTime, HashSet<ReferenceItemFull>> _startDateMap = null;

		/// <summary>
		/// Order:Log(n) lookup of reference item by end date.
		/// </summary>
		private SortedList<DateTime, HashSet<ReferenceItemFull>> EndDateMap
		{
			get
			{
				// Return map if already computed
				if (_endDateMap != null)
				{
					return _endDateMap;
				}

				// Compute map and return it
				var tempMap = new SortedList<DateTime, HashSet<ReferenceItemFull>>();
				foreach (var item in Items)
				{
					if (!item.EndDate.HasValue)
					{
						continue;
					}

					if (tempMap.TryGetValue(item.EndDate.Value, out HashSet<ReferenceItemFull> matchingEndItems))
					{
						matchingEndItems.Add(item);
						continue;
					}

					tempMap.Add(item.EndDate.Value, new HashSet<ReferenceItemFull>(new ReferenceItemFull[] { item }));
				}

				_endDateMap = tempMap;
				return _endDateMap;
			}
		}

		private SortedList<DateTime, HashSet<ReferenceItemFull>> _endDateMap = null;

		/// <summary>
		/// Set of all unended items, used for finding active items.
		/// </summary>
		private HashSet<ReferenceItemFull> Unended => _unended != null
			? _unended
			: (_unended = new HashSet<ReferenceItemFull>(Items.Where(i => !i.EndDate.HasValue)));

		private HashSet<ReferenceItemFull> _unended = null;

		#endregion

		/// <summary>
		/// Gets a reference item by Id with Order:1 speed.
		/// </summary>
		/// <param name="id"></param>
		public ReferenceItemFull GetById(int id)
		{
			if (!IdMap.TryGetValue(id, out ReferenceItemFull item))
			{
				return null;
			}

			return item;
		}

		/// <summary>
		/// Gets reference items by primary key ids.
		/// The returned reference items will match the ordering of the supplied ids.
		/// </summary>
		/// <param name="ids">The identifiers.</param>
		public IEnumerable<ReferenceItemFull> GetById(IEnumerable<int> ids)
		{
			if (ids == null)
			{
				return new ReferenceItemFull[] { };
			}

			var items = ids.Select(id => GetById(id)).Where(item => item != null);
			return items;
		}

		/// <summary>
		/// Gets active reference items utilising Start/End date indexes for speed.
		/// </summary>
		/// <param name="activeDate"></param>
		/// <param name="includeId"></param>
		/// <returns></returns>
		public IEnumerable<ReferenceItemFull> GetActive(DateTime? activeDate = null,
			int? includeId = null)
		{
			var active = GetActive(activeDate, includeId.HasValue ? new[] { includeId.Value } : null);
			return active;
		}

		/// <summary>
		/// Gets active reference items utilising Start/End date indexes for speed.
		/// </summary>
		/// <param name="activeDate"></param>
		/// <param name="includeIds"></param>
		/// <returns></returns>
		public IEnumerable<ReferenceItemFull> GetActive(DateTime? activeDate = null,
			IEnumerable<int> includeIds = null)
		{
			var searchDate = activeDate ?? DateTime.Now;

			// Get index of items starting on/before active date.
			var startKeys = StartDateMap.Keys;
			var startIndex = startKeys.BinarySearch(searchDate);
			if (startIndex < 0)
			{
				startIndex = ~startIndex - 1;   // Note bitwise NOT to get next largest index, as per BinarySearch() spec.
			}

			var startValidIndexes = startIndex >= 0
				? startKeys.GetRange(0, startIndex)
				: new List<DateTime>();
			var startValidItems = startValidIndexes.SelectMany(sk => StartDateMap[sk]);

			// Get index of items ending on/after active date.
			var endKeys = EndDateMap.Keys;
			var endIndex = endKeys.BinarySearch(searchDate);
			if (endIndex < 0)
			{
				endIndex = ~endIndex;   // Note bitwise NOT to get next largest index, as per BinarySearch() spec.
			}

			var endValidIndexes = endIndex < endKeys.Count
				? endKeys.GetRange(endIndex, endKeys.Count - endIndex)
				: new List<DateTime>();
			var endValidItems = endValidIndexes.SelectMany(ek => EndDateMap[ek]);

			// We can now find the list of active items by grabbing the intersection of valid starts and (valid ends + undneded).
			var active = startValidItems.Intersect(endValidItems.Union(Unended));
			var included = includeIds != null ? GetById(includeIds) : null;
			var activeAndIncluded = included != null
				? active.Union(included)
				: active;
			return activeAndIncluded;
		}
	}
}
