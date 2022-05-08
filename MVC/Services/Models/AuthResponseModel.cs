using System.Text.Json.Serialization;

// Written by Owen Ravelo

namespace Services.Models
{
    public class AuthResponseModel
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("auth_token")]
        public string AuthToken { get; set; }
        [JsonPropertyName("success")]
        public bool Success { get; set; }
        [JsonPropertyName("authorized")]
        public bool Authorized { get; set; }
    }
}
