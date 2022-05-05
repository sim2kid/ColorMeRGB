using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Data_Access_Layers;
using Services.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        TokenService tokenService;
        ApiKeyService apiKey;
        AuthenticationService authService;

        public AuthController() 
        {
            tokenService = new TokenService();
            apiKey = new ApiKeyService();
            authService = new AuthenticationService();
        }
    

        [HttpPost]
        [Route("Signup")]
        public IActionResult Signup([FromBody] AuthModel auth) 
        {
            if (!apiKey.IsKeyValid(auth.ApiKey))
            {
                return Unauthorized(new AuthResponseModel()
                {
                    Message = "Invalid API Key.",
                    Authorized = false,
                    Success = false,
                    AuthToken = null
                });
            }

            UserModel model = new UserModel();
            model.Username = auth.Username;
            model.SignupTime = DateTime.Now;
            model.Id = Guid.NewGuid();

            // Ensure username doesn't already exist
            string username = model.Username;
            
            // If username exists, cancel request
            if (authService.DoesUserExist(username)) 
            {
                return BadRequest(new AuthResponseModel() 
                {
                    Message = "Username already exists.",
                    Authorized = true,
                    Success = false,
                    AuthToken = null
                });
            }

            // Generate Salt
            // Generate hashed password
            var passHash = authService.GeneratePassword(auth.Password);

            model.Salt = passHash.salt;
            model.Password = passHash.hash;

            // Save model to database
            UserRecordModel record = new UserRecordModel()
            {
                Id = model.Id,
                Username = model.Username,
                Password = model.Password,
                Salt = model.Salt,
                SignupTime = model.SignupTime,
            };
            authService.AddUser(record);

            // Generate JWE token
            var token = tokenService.GenerateToken(model.Id);
            // Return token.
            return Ok(new AuthResponseModel()
            {
                Message = "Login Successful.",
                Authorized = true,
                Success = true,
                AuthToken = token
            });
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] AuthModel auth)
        {
            if (!apiKey.IsKeyValid(auth.ApiKey))
            {
                return Unauthorized(new AuthResponseModel()
                {
                    Message = "Invalid API Key.",
                    Authorized = false,
                    Success = false,
                    AuthToken = null
                });
            }

            if (authService.isValidLogin(auth.Username, auth.Password, out Guid id))
            {
                // Generate JWE token
                var token = tokenService.GenerateToken(id);

                return Ok(new AuthResponseModel()
                {
                    Message = "Login Successful.",
                    Authorized = true,
                    Success = true,
                    AuthToken = token
                });
            }
            else 
            {
                return Unauthorized(new AuthResponseModel()
                {
                    Message = "Invalid Credentials.",
                    Authorized = true,
                    Success = false,
                    AuthToken = null
                });
            }

        }
    }
}
