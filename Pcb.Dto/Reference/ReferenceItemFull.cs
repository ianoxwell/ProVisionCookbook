using System;
using System.Collections.Generic;
using System.Linq;
using Pcb.Common;
using Newtonsoft.Json;

namespace Pcb.Dto.Reference
{
    public class ReferenceItemFull : ReferenceItemEx, IReferenceItemFull
    {
        public ReferenceType Type { get; set; }

        [JsonIgnore]
        public Dictionary<string, bool> FlagsRW { get; set; } = new Dictionary<string, bool>();

        public IReadOnlyDictionary<string, bool> Flags => FlagsRW;

        [JsonIgnore]
        public Dictionary<string, ReferenceItem> RefsRW { get; set; } = new Dictionary<string, ReferenceItem>();

        public IReadOnlyDictionary<string, ReferenceItem> Refs => RefsRW;

        [JsonIgnore]
        public Dictionary<string, string> OtherRW { get; set; } = new Dictionary<string, string>();

        public IReadOnlyDictionary<string, string> Other => OtherRW;

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }

    public static class ReferenceItemFullExtensions
    {
        public static IOrderedQueryable<ReferenceItemFull> OrderByMeta(
            this IQueryable<ReferenceItemFull> source, ReferenceMeta meta)
        {
            // Sanity
            if (meta == null) { throw new ArgumentNullException(nameof(meta)); }
            if (string.IsNullOrWhiteSpace(meta.Name)) { throw new ArgumentException("meta Name required.", nameof(meta)); }
            var memberName = meta.Name;

            // Map out a path to the search object
            switch (meta.Category)
            {
                case ReferenceMetaCategory.Standard: return source.OrderByMember(memberName);
                case ReferenceMetaCategory.Flag: return source.OrderBy(item => item.Flags[memberName]);
                case ReferenceMetaCategory.Reference: return source.OrderBy(item => item.Refs[memberName].Title);
                case ReferenceMetaCategory.Other: return source.OrderBy(item => item.Other[memberName]);
                default: throw new NotImplementedException($"Unable to sort reference item member for category '{meta.Category}'.");
            }
        }

        public static IOrderedQueryable<ReferenceItemFull> OrderByMetaDescending(
            this IQueryable<ReferenceItemFull> source, ReferenceMeta meta)
        {
            // Sanity
            if (meta == null) { throw new ArgumentNullException(nameof(meta)); }
            if (string.IsNullOrWhiteSpace(meta.Name)) { throw new ArgumentException("meta Name required.", nameof(meta)); }
            var memberName = meta.Name;

            // Map out a path to the search object
            switch (meta.Category)
            {
                case ReferenceMetaCategory.Standard: return source.OrderByMemberDescending(memberName);
                case ReferenceMetaCategory.Flag: return source.OrderByDescending(item => item.Flags[memberName]);
                case ReferenceMetaCategory.Reference: return source.OrderByDescending(item => item.Refs[memberName].Title);
                case ReferenceMetaCategory.Other: return source.OrderByDescending(item => item.Other[memberName]);
                default: throw new NotImplementedException($"Unable to sort reference item member for category '{meta.Category}'.");
            }
        }
    }
}
