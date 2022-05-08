using System.Text.Json.Serialization;

// Written by Owen Ravelo

namespace Services.Models
{
    public class GameRequestModel
    {
        [JsonPropertyName("auth_token")]
        public string AuthToken { get; set; }

        [JsonPropertyName("api_key")]
        public string ApiKey { get; set; }

        [JsonPropertyName("game_id")]
        public Guid GameID { get; set; }

        [JsonPropertyName("color")]
        public string? Color { get; set; }

        [JsonPropertyName("distance")]
        public float? Distance { get; set; }

        [JsonPropertyName("is_correct")]
        public bool? isCorrect { get; set; }

        [JsonPropertyName("is_end")]
        public bool? isEnd { get; set; }
    }
}
