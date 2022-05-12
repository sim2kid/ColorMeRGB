using Services.Color_Models;
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
    public class GameFormModel
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
        [NumberSize(0, 255)]
        public int B { get; set; }

        public IRGB Response => new RGBModel(R, G, B);

        public GameFormModel() 
        {
            var r = new Random();
            R = 0;
            G = 0;
            B = 0;
        }
    }
}