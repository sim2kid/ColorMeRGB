using System.Text.Json.Serialization;

namespace API.Models
{
    public class AuthModel
    {
        public Guid Id { get; set; }
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        public int Salt { get; set; }
    }
}
