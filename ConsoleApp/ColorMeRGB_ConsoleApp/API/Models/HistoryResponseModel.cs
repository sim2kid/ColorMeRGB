using System.Text.Json.Serialization;
using Services.Models;

// Written by Owen Ravelo
namespace API.Models
{
    public class HistoryResponseModel
    {
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;

        [JsonPropertyName("authenticated")]
        public bool Authenticated { get; set; }

        [JsonPropertyName("authorized")]
        public bool Authorized { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("games")]
        public List<GameModel> Games { get; set; } = new List<GameModel>();
    }
}
