using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pcb.Database.Context.Models
{
    [Table("Permission", Schema = "sec")]
    public partial class Permission
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int? PermissionGroupId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        [Timestamp]
        public byte[] RowVer { get; set; }

        public PermissionGroup PermissionGroup { get; set; }
        public ICollection<RolePermission> RolePermission { get; set; }
    }
}
