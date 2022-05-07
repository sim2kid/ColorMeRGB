using Newtonsoft.Json;

namespace API.Models
{
    public class HistoryRequestModel
    {
        [JsonProperty("auth_token")]
        public string AuthToken { get; set; }

        [JsonProperty("api_key")]
        public string ApiKey { get; set; }
    }
}
