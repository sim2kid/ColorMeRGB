using Newtonsoft.Json;
using Services.Models;

// Written by Owen Ravelo
namespace API.Models
{
    public class HistoryResponseModel
    {
        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;

        [JsonProperty("authenticated")]
        public bool Authenticated { get; set; }

        [JsonProperty("authorized")]
        public bool Authorized { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("games")]
        public List<GameModel> Games { get; set; } = new List<GameModel>();
    }
}
