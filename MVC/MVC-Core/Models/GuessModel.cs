using Services;
using Services.Color_Models;
using Newtonsoft.Json;

// Written by Owen Ravelo

namespace MVC_Core.Models
{
    public class GuessModel
    {
        [JsonProperty("color")]
        public RGBModel Color { get; set; } = new RGBModel();
        [JsonProperty("distance")]
        public float Distance;
    }
}
