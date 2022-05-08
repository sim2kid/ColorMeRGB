using System.Text.Json.Serialization;

// Written by Owen Ravelo

namespace Services.Models
{
    public class GameResponseModel
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("authenticated")]
        public bool Authenticated { get; set; }

        [JsonPropertyName("authorized")]
        public bool Authorized { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("game_id")]
        public Guid? GameId { get; set; }
    }
}
