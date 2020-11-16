using Pcb.Common;
using System;

namespace Pcb.Dto.School
{
    public class SchoolDto : PcbModel
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string ShortName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string BusinessContactName { get; set; }
        public string EmailAddress { get; set; }
        public string StreetNumber { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }


        public DateTimeOffset CreatedAt { get; set; }
        public byte[] RowVer { get; set; }
    }
}
