using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pcb.Database.Context.Models
{
    [Table("EventLog", Schema = "logs")]
    public partial class EventLog
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? EventId { get; set; }
        public int LogLevelId { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
        public string Machine { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public LogLevel LogLevel { get; set; }
        public User User { get; set; }
    }
}
