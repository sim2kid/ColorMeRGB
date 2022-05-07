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

        public AnswerModel() { }

        public AnswerModel(GuessRecordModel record) 
        {
            this.Timestamp = record.Timestamp;
            this.GuessColor = record.Guess != null ? record.Guess : string.Empty;
            this.Distance = record.Distance;
            this.IsCorrect = record.IsCorrect;

        }
    }
}
