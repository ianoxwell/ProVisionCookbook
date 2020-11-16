
using Pcb.Common.Enums;
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
    public interface IReferenceItemMeasurement : IReferenceItem
    {

        MeasurementType MeasurementType { get; }
        string ShortName { get; }
        string AltShortName { get; }
        int ConvertsToId { get; }
        double Quantity { get; }
        CountryCode CountryCode { get; }
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
