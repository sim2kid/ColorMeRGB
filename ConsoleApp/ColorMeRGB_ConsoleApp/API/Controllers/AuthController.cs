using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("Signup")]
        public IActionResult Signup([FromBody] AuthModel auth) 
        {
            UserModel model = new UserModel();
            model.Username = auth.Username;
            model.SignupTime = DateTime.Now;
            model.Id = Guid.NewGuid();

            // Ensure username doesn't already exist
            string username = model.Username;
            // TODO: Check Database for Username. If exists, fail signup. If doesn't exist, continue with signup
            // If username exists, cancel request
            if (false) 
            {
                return BadRequest(new 
                {
                    message = "Username already exists."
                });
            }

            // Generate Salt
            string salt = Services.Utilities.HashUtil.GenerateSalt();
            model.Salt = salt;

            // Generate hashed password
            string unHashedPassword = auth.Password;
            string hash = Services.Utilities.HashUtil.HashPassword(unHashedPassword, salt, model.SignupTime);
            model.Password = hash;

            // Save model to database
            // TODO: Save model to database
            // Catch if model fails to save.

            // Generate JWE token

            // Return token.
            return Ok(new
            {
                authToken = "",
                hash = hash,
                username = username
            });
        }

        [HttpPost]
        [Route("Login")]
        public object Login([FromBody] AuthModel model)
        {
            string username = model.Username;
            string password = model.Password;

            return new
            {
                authToken = ""
            };
        }
    }
}
