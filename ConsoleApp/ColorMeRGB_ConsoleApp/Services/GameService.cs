using Services.Data_Access_Layers;
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
        GamesDataAccessLayer gDal = new GamesDataAccessLayer();
        GuessesDataAccessLayer uDal = new GuessesDataAccessLayer();

        public Guid NewGame(Guid playerGuid) 
        {
            var game = new GameRecordModel()
            {
                UserId = playerGuid,
                Timestamp = DateTime.Now,
                Answer = "ffffff",
                Completed = false,
            };
            Guid gameId = gDal.GamesInsertRecords(game);
            return gameId;
        }

        public GameRecordModel? GetGameById(Guid gameGuid) 
        {
            var games = gDal.GamesGetById(gameGuid);
            if (games.Count == 0) 
            {
                return null;
            }
            return games.FirstOrDefault();
        }

        public void UpdateRecord(GameRecordModel game) 
        {
            gDal.GamesUpdateRecordById(game.Id, game);
        }

        public void AddNewGuess(GuessRecordModel guess) 
        {
            uDal.GuessesInsertRecords(guess);
        }
    }
}
