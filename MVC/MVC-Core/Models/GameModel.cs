using Services.Decorators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

// Written by Owen Ravelo

namespace MVC_Core.Models
{
    public class GameModel
    {
        [JsonPropertyName("R")]
        [Required]
        [NumberSize(0, 255)]
        public int R { get; set; }
        [JsonPropertyName("G")]
        [Required]
        [NumberSize(0, 255)]
        public int G { get; set; }
        [JsonPropertyName("B")]
        [Required]
        [NumberSize(0,255)]
        public int B { get; set; }
    }
}