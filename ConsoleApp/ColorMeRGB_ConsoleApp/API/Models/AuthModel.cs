using System.Text.Json.Serialization;

// Written by Owen Ravelo

namespace API.Models
{
    public class AuthModel
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("api_key")]
        public string ApiKey { get; set; }
    }
}
