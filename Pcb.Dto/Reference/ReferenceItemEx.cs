using System;

namespace Pcb.Dto.Reference
{
    public class ReferenceItemEx : ReferenceItem, IReferenceItemEx
    {
        public string Symbol { get; set; }

        public string Summary { get; set; }

        public int? SortOrder { get; set; }
        public string AltTitle { get; set; }
        public int? OnlineId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public byte[] RowVer { get; set; }
    }
}
