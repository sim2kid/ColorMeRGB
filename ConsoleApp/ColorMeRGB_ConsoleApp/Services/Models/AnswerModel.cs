using Newtonsoft.Json;

// Written by Owen Ravelo
namespace Services.Models
{
    public class AnswerModel
    {
        [JsonProperty("timestampe")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("guess_color")]
        public string GuessColor { get; set; } = string.Empty;

        [JsonProperty("distance")]
        public float Distance { get; set; }

        [JsonProperty("is_correct")]
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
