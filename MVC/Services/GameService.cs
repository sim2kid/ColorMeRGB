using Services.Color_Models;
using Services.Game;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Written by Owen Ravelo

namespace Services
{
    public class GameService
    {
        WebRequest.APICall api = new WebRequest.APICall();
        //hardcoded properties
        readonly int maxGuesses = 6;
        readonly float closenessCutoff = 15;

        public async Task<GameResponseModel> NewGame(string token) 
        {
            var response = await api.NewGame(token);
            return response ?? new GameResponseModel() { Authorized = false, Authenticated = false, Success = false };
        }

        public IRGB GetGameColor() 
        {
            GenerateHexService genHex = new GenerateHexService();
            return new Adapters.ColorAdapter(new HexModel() { Hex = genHex.GenerateRandomHex() });
        }

        public async Task<GameResponseModel> Start(string token, Guid gameId, IRGB color)
        {
            var response = await api.StartGame(token, gameId, new Adapters.ColorAdapter(color).Hex);
            return response ?? new GameResponseModel() { Authorized = false, Authenticated = false, Success = false };
        }

        public async Task<GameResponseModel> MakeGuess(string token, Guid gameId, IRGB answer, IRGB guess, int guessCount)
        {
            bool win = hasWin(answer, guess);
            var response = await api.Guess(token, gameId, new Adapters.ColorAdapter(guess).Hex, 
                answer.Distance(guess), win, hasEnd(guessCount) || win);
            return response ?? new GameResponseModel() { Authorized = false, Authenticated = false, Success = false };
        }

        public bool hasWin(IRGB answer, IRGB guess) 
        {
            return answer.Distance(guess) < closenessCutoff;
        }

        public bool hasEnd(int count)
        {
            return count + 1 >= maxGuesses;
        }
    }
}
