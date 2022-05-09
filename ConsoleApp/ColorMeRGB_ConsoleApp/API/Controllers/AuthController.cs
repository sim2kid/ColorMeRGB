using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Data_Access_Layers;
using Services.Models;

// Written by Owen Ravelo

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
        public IActionResult Signup([FromBody] AuthRequestModel auth) 
        {
            if (!apiKey.IsKeyValid(auth.ApiKey))
            {
                Logger.Logger.Instance.Warning($"Unauthorized access detected from {Request.HttpContext.Connection.RemoteIpAddress}");
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
                Username = model.Username,
                Password = model.Password,
                Salt = model.Salt,
                SignupTime = model.SignupTime,
            };
            model.Id = authService.AddUser(record);

            // Generate JWE token
            var token = tokenService.GenerateToken(model.Id);
            // Return token.
            return Ok(new AuthResponseModel()
            {
                Message = "Signup Successful.",
                Authorized = true,
                Success = true,
                AuthToken = token
            });
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] AuthRequestModel auth)
        {
            if (!apiKey.IsKeyValid(auth.ApiKey))
            {
                Logger.Logger.Instance.Warning($"Unauthorized access detected from {Request.HttpContext.Connection.RemoteIpAddress}");
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
