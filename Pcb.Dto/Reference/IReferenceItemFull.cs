
using System;
using System.Collections.Generic;

namespace Pcb.Dto.Reference
{
    /// <summary>
    /// Reference item with full field coverage.
    /// This can be freely passed around the server (it's cached),
    /// but should rarely be returned to the client.
    /// The client is normally only interested in fields within IReferenceItem.
    /// </summary>
    public interface IReferenceItemFull : IReferenceItemEx
    {
        ///// <summary>
        ///// The type of reference item, e.g. Facility, Ward, etc.
        ///// </summary>
        //ReferenceType Type { get; }

        /// <summary>
        /// Used to sort reference items
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
        long RowVer { get; }
    }
}
