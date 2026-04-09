using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MzansiBuilds.Data;
using MzansiBuilds.Models;

namespace MzansiBuilds.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            var userr = DataStore.Users
                .Find(u => u.Username == user.Username);

            if (userr == null) {
                user.UserID = DataStore.Users.Count;
                DataStore.Users.Add(user);
                return Ok(user);
            }

            return Unauthorized("User with the same username already exists!");

        }

        [HttpPost("login")]
        public IActionResult Login(User loginUser)
        {
            var user = DataStore.Users
                .Find(u => u.Username == loginUser.Username && u.Password == loginUser.Password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            return Ok(user);
        }
    }
}
