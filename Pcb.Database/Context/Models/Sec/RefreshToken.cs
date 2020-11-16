using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pcb.Database.Context.Models
{
	[Table("RefreshToken", Schema = "sec")]
	[Owned]
	public partial class RefreshToken
	{
		public int Id { get; set; }

		public User User { get; set; }

		public string Token { get; set; }
		public DateTime Expires { get; set; }
		public bool IsExpired => DateTime.UtcNow >= Expires;

		public DateTimeOffset CreatedAt { get; set; }

		public DateTimeOffset ModifiedAt { get; set; }
		public string CreatedByIp { get; set; }
		public DateTime? Revoked { get; set; }
		public string RevokedByIp { get; set; }
		public string ReplacedByToken { get; set; }
		public bool IsActive => Revoked == null && !IsExpired;

		[Timestamp]
		public byte[] RowVer { get; set; }
	}
}
