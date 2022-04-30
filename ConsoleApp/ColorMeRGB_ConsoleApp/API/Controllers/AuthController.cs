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
        public object Signup([FromBody] AuthModel model) 
        {
            string username = model.Username;
            string password = model.Password;

            string hash = Services.Utilities.HashUtil.HashPassword(password, 5);

            return new
            {
                authToken = "",
                hash = hash,
                username = username
            };
        } 
    }
}
