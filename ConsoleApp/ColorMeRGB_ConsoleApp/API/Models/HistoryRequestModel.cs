using System.Text.Json.Serialization;

namespace API.Models
{
    public class HistoryRequestModel
    {
        [JsonPropertyName("auth_token")]
        public string AuthToken { get; set; }

        [JsonPropertyName("api_key")]
        public string ApiKey { get; set; }
    }
}
