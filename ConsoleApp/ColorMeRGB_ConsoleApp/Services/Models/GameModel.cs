using Newtonsoft.Json;

// Written by Owen Ravelo
namespace Services.Models
{
    public class GameModel
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("correct_answer")]
        public string CorrectAnswer { get; set; } = string.Empty;

        [JsonProperty("completed")]
        public bool Completed { get; set; }

        [JsonProperty("answers")]
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
