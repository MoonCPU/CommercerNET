using Ecommerce.Models;
using Ecommerce.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(string email, string password) {
            var result = await _userRepository.LoginUser(email, password);

            if (result.Succeeded)
            {
                return Ok(new { message = "Login Successful" });
            }

            return Unauthorized(new { message = "Login Failed" });
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterUserDto userDto, string password) {
            var result = await _userRepository.RegisterUser(userDto, password);

            if (result.Succeeded) {
                return Ok(new { message = "User Registered!" });
            }

            return BadRequest(result.Errors);
        }
    }
}
