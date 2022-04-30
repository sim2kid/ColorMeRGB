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

        [JsonPropertyName("answer")]
        public int Answer { get; set; }

        [JsonPropertyName("guess")]
        public int Guess { get; set; }

        [JsonPropertyName("distance")]
        public float Distance { get; set; }
    }
}
