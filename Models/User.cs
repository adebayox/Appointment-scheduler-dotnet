using System;
using Scheduler.Model;

namespace Scheduler.Models
{
	public class User
	{
		public int Id { get; set; }

		public string Username { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public byte[] PasswordHash { get; set; } = new byte[0];

		public byte[] PasswordSalt { get; set; } = new byte[0];

		public List<Appointment>? Appointments { get; set; }
	}
}

