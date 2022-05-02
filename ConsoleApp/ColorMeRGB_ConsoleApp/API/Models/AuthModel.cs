﻿using System.Text.Json.Serialization;

namespace API.Models
{
    public class AuthModel
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
