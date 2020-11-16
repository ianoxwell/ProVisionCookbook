using System.Collections.Generic;
using System.Linq;

namespace Pcb.Dto.Reference
{
    public static class Extensions
    {
        /// <summary>
        /// Applies a standard sort to a reference item enumerable.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static List<IReferenceItemFull> ToSortedList(this IEnumerable<IReferenceItemFull> items)
        {
            var sorted = items
                .OrderBy(item => item.SortOrder)
                .ThenBy(item => item.Title)
                .ToList();

            return sorted;
        }
    }
}
