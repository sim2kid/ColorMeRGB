using System.Text.Json.Serialization;

// Written by Owen Ravelo

namespace Services.Models
{
    public class AuthRequestModel
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("api_key")]
        public string ApiKey { get; set; }
    }
}
