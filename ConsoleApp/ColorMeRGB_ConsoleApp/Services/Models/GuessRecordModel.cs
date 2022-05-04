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
    public class GuessRecordModel
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("game_id")]
        public Guid GameId { get; set; }

        [JsonPropertyName("guess_color")]
        public string Guess { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("distance")]
        public float Distance { get; set; }

        [JsonPropertyName("is_correct")]
        public bool IsCorrect { get; set; }
    }
}
