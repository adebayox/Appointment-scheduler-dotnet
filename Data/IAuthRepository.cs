using System;
using Scheduler.Dtos.User;

namespace Scheduler.Data
{
	public interface IAuthRepository
	{
		Task<ServiceResponse<int>> Register(UserRegisterDto user);

		Task<ServiceResponse<string>> Login(UserLoginDto user);

		Task<bool> UserExists(string username);
	}
}

