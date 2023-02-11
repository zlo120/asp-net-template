using Core.DataValidators;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ASP_NET_template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([Required][FromQuery] string email)
        {
            var user = await _userService.GetUserByEmail(email);

            if (user is null)
            {
                return NotFound("No user exists with that email");
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserValidator userInfo)
        {
            var userInDb = await _userService.GetUserByEmail(userInfo.Email);
            if (userInDb is not null)
            {
                return BadRequest("A user with that email already exists");
            }

            if (await _userService.Create(userInfo))
            {
                return Ok("User has been created");
            }

            return BadRequest("Something went wrong creating your account");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserValidator updatedUserInfo)
        {
            // Authenticate first

            var userInDb = await _userService.GetUserByEmail(updatedUserInfo.Email);
            if (userInDb is null)
            {
                return BadRequest("Something went wrong");
            }

            userInDb.FirstName = updatedUserInfo.FirstName;
            userInDb.LastName = updatedUserInfo.LastName;

            if (await _userService.UpdateUser(userInDb))
            {
                return Ok("User has been updated");
            }

            return BadRequest("Something went wrong");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int userId)
        {
            var userInDb = await _userService.GetUserById(userId);
            if (userInDb is null)
            {
                return BadRequest("Something went wrong");
            }

            if (await _userService.DeleteUser(userId))
            {
                return Ok("User has been deleted");
            }

            return BadRequest("Something went wrong");
        }
    }
}