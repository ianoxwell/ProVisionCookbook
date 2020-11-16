using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Pcb.Database.Context.Models
{
	[Table("User", Schema = "sec")]
	public partial class User
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		public string FamilyName { get; set; }
		[Required]
		public string GivenNames { get; set; }
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string EmailAddress { get; set; }
		[AllowNull]
		public string PasswordHash { get; set; }
		public int FailedLoginAttempt { get; set; }
		public DateTime LastFailedLoginAttempt { get; set; }
		[AllowNull]
		public string VerificationToken { get; set; }
		[AllowNull]
		public string ResetToken { get; set; }
		public DateTime? Verified { get; set; }
		public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
		[AllowNull]
		public string PhoneNumber { get; set; }
		public bool IsActive { get; set; }
		public int TimesLoggedIn { get; set; }
		[AllowNull]
		public DateTime FirstLogin { get; set; }
		[AllowNull]
		public DateTime LastLogin { get; set; }
		public bool? IsStudent { get; set; }
		[AllowNull]
		public string LoginProvider { get; set; }
		[AllowNull]
		public string LoginProviderId { get; set; }
		[AllowNull]
		public string PhotoUrl { get; set; }
		[Display(Name = "Full Name")]
		public string FullName
		{
			get
			{
				return FamilyName.ToUpper() + ", " + GivenNames;
			}
		}
		public bool OwnsToken(string token)
		{
			return this.RefreshTokens?.Find(x => x.Token == token) != null;
		}

		public DateTime? ResetTokenExpires { get; set; }
		public DateTime? PasswordReset { get; set; }
		public DateTime? Updated { get; set; }
		public DateTimeOffset CreatedAt { get; set; }

		[Timestamp]
		public byte[] RowVer { get; set; }

		public ICollection<UserRole> UserRole { get; set; }
		public List<RefreshToken> RefreshTokens { get; set; }

	}
}
