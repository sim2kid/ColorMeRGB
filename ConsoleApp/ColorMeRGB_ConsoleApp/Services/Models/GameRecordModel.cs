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
    public class GameRecordModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("user_id")]
        public Guid UserId { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("answer_color")]
        public string? Answer { get; set; }

        [JsonPropertyName("completed")]
        public bool Completed { get; set; }
    }
}
