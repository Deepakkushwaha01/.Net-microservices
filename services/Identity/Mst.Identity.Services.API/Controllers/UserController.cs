using Microsoft.AspNetCore.Mvc;
using Mst.Identity.Services.API.Models;

namespace Mst.Identity.Services.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly List<UserDto> Users = new();

        /// <summary>
        /// Get all users
        /// </summary>
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(Users);
        }

        /// <summary>
        /// Get a user by ID
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            return user == null ? NotFound() : Ok(user);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDto userDto)
        {
            var user = new UserDto
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email
            };

            Users.Add(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        /// <summary>
        /// Delete a user by ID
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();

            Users.Remove(user);
            return NoContent();
        }
    }
}
