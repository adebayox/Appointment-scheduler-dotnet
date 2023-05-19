using System;
using Scheduler.Dtos.User;

namespace Scheduler.Data
{
	public interface IAuthRepository
	{
		Task<ServiceResponse<int>> Register(UserRegisterDto user);

		Task<ServiceResponse<string>> Login(UserLoginDto user);

        Task<ServiceResponse<string>> ForgotPassword(string email);

        Task<ServiceResponse<string>> ResetPassword(ResetPasswordDto user);

        Task<bool> UserExists(string username);


    }
}

