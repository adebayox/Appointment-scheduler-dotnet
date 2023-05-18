using System;
using System.ComponentModel.DataAnnotations;

namespace Scheduler.Dtos.User
{
	public class ResetPasswordDto
	{
        [Required]
        public string Token { get; set; }

        [Required, MinLength(6, ErrorMessage = "Please enter at least 6 characters")]
        public string Password { get; set; } = string.Empty;

        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}

