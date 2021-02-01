using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Pcb.Database.Context.Models
{
    [Table("PermissionGroup", Schema = "ref")]
    public partial class PermissionGroup
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [AllowNull]
        public string Summary { get; set; }
        [AllowNull]
        public string Symbol { get; set; }
        [AllowNull]
        public string AltTitle { get; set; }
        public int? OnlineId { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        [Timestamp]
        public byte[] RowVer { get; set; }

        public ICollection<Permission> Permission { get; set; }
    }
}
