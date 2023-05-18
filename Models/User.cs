using System;
using Scheduler.Model;

namespace Scheduler.Models
{
	public class User
	{
		public int Id { get; set; }

		public string Email { get; set; } = string.Empty;

		public byte[] PasswordHash { get; set; } = new byte[0];

		public byte[] PasswordSalt { get; set; } = new byte[0];

		public string? VerifiedToken { get; set; }

        public DateTime? VerifiedAt { get; set; }

        public string? PasswordResetToken { get; set; }

        public DateTime? ResetTokenExpires { get; set; }

        public List<Appointment>? Appointments { get; set; }
	}
}

