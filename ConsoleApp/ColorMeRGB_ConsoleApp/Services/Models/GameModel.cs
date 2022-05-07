using System.Text.Json.Serialization;

// Written by Owen Ravelo
namespace Services.Models
{
    public class GameModel
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("correct_answer")]
        public string CorrectAnswer { get; set; } = string.Empty;

        [JsonPropertyName("completed")]
        public bool Completed { get; set; }

        [JsonPropertyName("answers")]
        public List<AnswerModel> Answers { get; set; } = new List<AnswerModel>();

        public GameModel() { }

        public GameModel(GameRecordModel record) 
        {
            this.Id = record.Id;
            this.Timestamp = record.Timestamp;
            this.CorrectAnswer = record.Answer;
            this.Completed = record.Completed;
            this.Answers = new List<AnswerModel>();
        }
    }
}
