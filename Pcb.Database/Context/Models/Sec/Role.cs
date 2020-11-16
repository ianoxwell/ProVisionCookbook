using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pcb.Database.Context.Models
{
    [Table("Role", Schema = "sec")]
    public partial class Role
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int Rank { get; set; }
        public bool IsAdmin { get; set; }    
        public bool IsUser { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        [Timestamp]
        public byte[] RowVer { get; set; }

        public ICollection<RolePermission> RolePermission { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}
