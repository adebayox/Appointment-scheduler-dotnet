using System;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Data;
using Scheduler.Dtos.User;

namespace Scheduler.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authRepo.Register(
                request
                );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserLoginDto request)
        {
            var response = await _authRepo.Login(request);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("ForgotPassword")]
        public async Task<ActionResult<ServiceResponse<string>>> ForgotPassword(string email)
        {
            var response = await _authRepo.ForgotPassword(email);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("ResetPassword")]
        public async Task<ActionResult<ServiceResponse<string>>> ResetPassword(ResetPasswordDto request)
        {
            var response = await _authRepo.ResetPassword(request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
}

