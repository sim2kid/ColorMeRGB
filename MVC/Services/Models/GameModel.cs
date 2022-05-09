using System.Text.Json.Serialization;
using System.Linq;
using Services.Color_Models;

// Written by Owen Ravelo
namespace Services.Models
{
    public class GameModel
    {
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("correct_answer")]
        public string CorrectAnswer { get; set; } = string.Empty;

        [JsonPropertyName("completed")]
        public bool Completed { get; set; }

        [JsonPropertyName("answers")]
        public List<AnswerModel> Answers { get; set; } = new List<AnswerModel>();

        public bool hasCorrectAnswer => Answers.Any(x => x.IsCorrect);
        public IRGB rgb => new Adapters.ColorAdapter(new HexModel(CorrectAnswer));

        public GameModel() { }
    }
}
