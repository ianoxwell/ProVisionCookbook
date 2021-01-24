using Pcb.Common.Enums;
using System;

namespace Pcb.Dto.Reference
{
    public class ReferenceItemMeasurement: ReferenceItem, IReferenceItemMeasurement
    {

        public DateTimeOffset CreatedAt { get; set; }

        public byte[] RowVer { get; set; }

        public MeasurementType MeasurementType  { get; set; }

        public string ShortName  { get; set; }

        public string AltShortName  { get; set; }

        public int ConvertsToId  { get; set; }

        public double Quantity  { get; set; }

        public CountryCode CountryCode { get; set; }
    }
}
