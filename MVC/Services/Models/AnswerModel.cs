using Services.Color_Models;
using System.Text.Json.Serialization;

// Written by Owen Ravelo
namespace Services.Models
{
    public class AnswerModel
    {
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("guess_color")]
        public string GuessColor { get; set; } = string.Empty;

        [JsonPropertyName("distance")]
        public float Distance { get; set; }

        [JsonPropertyName("is_correct")]
        public bool IsCorrect { get; set; }

        public IRGB rgb => new Adapters.ColorAdapter(new HexModel(GuessColor));

        public AnswerModel() { }
    }
}
