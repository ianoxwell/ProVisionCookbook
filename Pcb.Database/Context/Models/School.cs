using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Pcb.Database.Context.Models
{
    [Table("School", Schema = "dbo")]
    public partial class School
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string ShortName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? SortOrder { get; set; }
        [AllowNull]
        public string BusinessContactName { get; set; }
        public string EmailAddress { get; set; }
        public string StreetNumber { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }


        public DateTimeOffset CreatedAt { get; set; }

        [Timestamp]
        public byte[] RowVer { get; set; }
      
        public ICollection<UserRole> UserRole { get; set; }
    }
}
