using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Services.Models
{
    /// <summary>
    /// Author: Sebastian Pedersen
    /// Date: 04/22/2022
    /// </summary>
    public class UserRecordModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("salt")]
        public int Salt { get; set; }
    }
}
