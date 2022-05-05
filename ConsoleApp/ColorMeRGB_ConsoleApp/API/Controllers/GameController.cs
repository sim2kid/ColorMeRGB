using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Models;

// Written by Owen Ravelo

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        ApiKeyService apiKey = new ApiKeyService();
        TokenService auth = new TokenService();
        GameService game = new GameService();

        [HttpPost]
        [Route("New")]
        public IActionResult NewGame([FromBody] GameRequestModel model) 
        {
            // api authorized
            if (!apiKey.IsKeyValid(model.ApiKey))
            {
                return Unauthorized(new GameResponseModel()
                {
                    Message = "Invalid API Key.",
                    Authorized = false,
                    Authenticated = false,
                    Success = false,
                    GameId = null
                });
            }

            // authenticate
            if (!auth.TokenIsValid(model.AuthToken)) 
            {
                return Unauthorized(new GameResponseModel()
                {
                    Message = "Invalid Auth Token.",
                    Authorized = true,
                    Authenticated = false,
                    Success = false,
                    GameId = null
                });
            }

            // get user's uuid
            Guid? user = auth.GetUserId(model.AuthToken);
            if (user == null) 
            {
                return BadRequest(new GameResponseModel()
                {
                    Message = "User does not exist.",
                    Authorized = true,
                    Authenticated = true,
                    Success = false,
                    GameId = null
                });
            }

            // generate new guid
            Guid gameId = game.NewGame(user.Value);

            // return guid
            return Ok(new GameResponseModel()
            {
                Message = "New game created.",
                Authorized = true,
                Authenticated = true,
                Success = true,
                GameId = gameId
            });
        }

        [HttpPost]
        [Route("Start")]
        public IActionResult StartGame([FromBody] GameRequestModel model) 
        {
            // api authorized
            if (!apiKey.IsKeyValid(model.ApiKey))
            {
                return Unauthorized(new GameResponseModel()
                {
                    Message = "Invalid API Key.",
                    Authorized = false,
                    Authenticated = false,
                    Success = false,
                    GameId = null
                });
            }

            // authenticate
            if (!auth.TokenIsValid(model.AuthToken))
            {
                return Unauthorized(new GameResponseModel()
                {
                    Message = "Invalid Auth Token.",
                    Authorized = true,
                    Authenticated = false,
                    Success = false,
                    GameId = null
                });
            }

            // grab game by id
            var gameInstance = game.GetGameById(model.GameID);
            if (gameInstance == null) 
            {
                return NotFound(new GameResponseModel()
                {
                    Message = "Game Not Found.",
                    Authorized = true,
                    Authenticated = true,
                    Success = false,
                    GameId = null
                });
            }

            // update color
            gameInstance.Answer = model.Color;

            // save game
            game.UpdateRecord(gameInstance);

            // return success
            return Ok(new GameResponseModel()
            {
                Message = "Game updated successfully.",
                Authorized = true,
                Authenticated = true,
                Success = true,
                GameId = null
            });
        }

        [HttpPost]
        [Route("Guess")]
        public IActionResult Guess([FromBody] GameRequestModel model) 
        {
            // api authorized
            if (!apiKey.IsKeyValid(model.ApiKey))
            {
                return Unauthorized(new GameResponseModel()
                {
                    Message = "Invalid API Key.",
                    Authorized = false,
                    Authenticated = false,
                    Success = false
                });
            }

            // authenticate
            if (!auth.TokenIsValid(model.AuthToken))
            {
                return Unauthorized(new GameResponseModel()
                {
                    Message = "Invalid Auth Token.",
                    Authorized = true,
                    Authenticated = false,
                    Success = false
                });
            }

            // Add guess
            GuessRecordModel guess = new GuessRecordModel() 
            {
                Id = Guid.NewGuid(),
                GameId = model.GameID,
                Guess = model.Color,
                Timestamp = DateTime.Now,
                Distance = model.Distance.Value,
                IsCorrect = model.isCorrect.Value,
            };
            game.AddNewGuess(guess);

            // if end
            if (model.isEnd.Value)
            {
                // grab game
                var gameInstance = game.GetGameById(model.GameID);
                if (gameInstance == null) 
                {
                    return NotFound(new GameResponseModel()
                    {
                        Message = "Game Not Found.",
                        Authorized = true,
                        Authenticated = true,
                        Success = false,
                        GameId = null
                    });
                }

                // close game
                gameInstance.Completed = true;

                // set game
                game.UpdateRecord(gameInstance);
            }

            return Ok(new GameResponseModel()
            {
                Message = "Guess added successfully.",
                Authorized = true,
                Authenticated = true,
                Success = true,
            });
        }
    }
}
