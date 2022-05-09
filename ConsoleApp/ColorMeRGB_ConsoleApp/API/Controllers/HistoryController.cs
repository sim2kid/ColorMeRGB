using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        ApiKeyService apiKey = new ApiKeyService();
        TokenService auth = new TokenService();
        HistoryService history = new HistoryService();

        [HttpGet]
        [Route("all")]
        public IActionResult AllHistroyByUser([FromBody] HistoryRequestModel model) 
        {
            // api authorized
            if (!apiKey.IsKeyValid(model.ApiKey))
            {
                Logger.Logger.Instance.Warning($"Unauthorized access detected from {Request.HttpContext.Connection.RemoteIpAddress}");
                return Unauthorized(new HistoryResponseModel()
                {
                    Message = "Invalid API Key.",
                    Authorized = false,
                    Authenticated = false,
                    Success = false,
                    Games = new List<GameModel>()
                });
            }

            // authenticate
            if (!auth.TokenIsValid(model.AuthToken))
            {
                return Unauthorized(new HistoryResponseModel()
                {
                    Message = "Invalid Auth Token.",
                    Authorized = true,
                    Authenticated = false,
                    Success = false,
                    Games = new List<GameModel>()
                });
            }

            // get user's uuid
            Guid? user = auth.GetUserId(model.AuthToken);
            if (user == null)
            {
                return BadRequest(new HistoryResponseModel()
                {
                    Message = "User does not exist.",
                    Authorized = true,
                    Authenticated = true,
                    Success = false,
                    Games = new List<GameModel>()
                });
            }

            List<GameModel> games = history.GetUsersGames(user.Value);
            return Ok(new HistoryResponseModel()
            {
                Message = "Games grabbed successfully.",
                Authorized = true,
                Authenticated = true,
                Success = true,
                Games = games
            });

        }
    }
}
