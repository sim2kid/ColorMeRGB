using Services;
using Services.Color_Models;
using Newtonsoft.Json;

// Written by Owen Ravelo

namespace MVC_Core.Models
{
    public class GameModel
    {
        [JsonProperty("id")]
        public Guid Id { get; private set; }
        [JsonProperty("answer")]
        public RGBModel Answer { get; set; }
        [JsonProperty("guesses")]
        public List<GuessModel> Guesses { get; set; }

        public GameModel() 
        {
            Answer = new RGBModel();
            Guesses = new List<GuessModel>();
        }

        public GameModel(Guid id, RGBModel color) 
        {
            Id = id;
            Answer = color;
            Guesses = new List<GuessModel>();
        }

        public void AddGuess(GuessModel guess) 
        {
            Guesses.Insert(0, guess);
        }

        public static GameModel? FromJson(string? json) 
        {
            if (string.IsNullOrWhiteSpace(json)) { return null; }
            return JsonConvert.DeserializeObject<GameModel>(json);
        }
        public string toJson() 
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
