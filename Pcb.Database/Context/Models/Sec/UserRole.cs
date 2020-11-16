using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pcb.Database.Context.Models
{
    [Table("UserRole", Schema = "sec")]
    public partial class UserRole
    {
        [Key]
        public int Id { get; set; }
   
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int? SchoolId { get; set; }
        public bool IsCountryWide { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        [Timestamp]
        public byte[] RowVer { get; set; }

        public School School { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
