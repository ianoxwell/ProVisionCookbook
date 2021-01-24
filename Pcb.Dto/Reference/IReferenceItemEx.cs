
using System;

namespace Pcb.Dto.Reference
{
    /// <summary>
    /// Extended reference item with additional fields.
    /// e.g. Extended summary text, Symbol field.
    /// </summary>
    public interface IReferenceItemEx : IReferenceItem
    {
        /// <summary>
        /// Extended description
        /// </summary>
        string Summary { get; }

        /// <summary>
        /// Symbol link or class used to display this item in UI
        /// </summary>
        string Symbol { get; }
        /// <summary>
        /// Any ordering required
        /// </summary>
        int? SortOrder { get; }
        /// <summary>
        /// Creation date
        /// </summary>
        DateTimeOffset CreatedAt { get; }
        /// <summary>
        /// Db-globally-incrementing counter identifying this item's most recent modification with respect to other rows/table data.
        /// From bytes: BitConverter.ToUInt64(byteArray.Reverse().ToArray(), 0);
        /// </summary>
        byte[] RowVer { get; }
    }
}
