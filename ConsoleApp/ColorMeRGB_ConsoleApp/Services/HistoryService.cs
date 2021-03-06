using Services.Data_Access_Layers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class HistoryService
    {
        GamesDataAccessLayer gDal = new GamesDataAccessLayer();
        GuessesDataAccessLayer uDal = new GuessesDataAccessLayer();
        public List<GameModel> GetUsersGames(Guid userGuid) 
        {
            var gameRecords = gDal.GamesGetByUserId(userGuid);
            List<GameModel> result = new List<GameModel>();
            foreach (var record in gameRecords) 
            {
                var model = new GameModel(record);
                var answerRecords = uDal.GuessessGetByGameId(model.Id);

                if(answerRecords == null || answerRecords.Count <= 0)
                {
                    continue;
                }

                foreach (var answer in answerRecords) {
                    model.Answers.Add(new AnswerModel(answer));
                }
                model.Answers.Sort((x, y) => -x.Timestamp.CompareTo(y.Timestamp));
                result.Add(model);
            }
            result.Sort((x, y) => -x.Timestamp.CompareTo(y.Timestamp));
            return result;
        }
    }
}
