using System.Text.Json.Serialization;

namespace API.Models
{
    public class UserModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("salt")]
        public string Salt { get; set; }

        [JsonPropertyName("signup_time")]
        public DateTime SignupTime { get; set; }
    }
}
