using Services.Adapters;
using Services.Color_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Game
{
    //Author: Sebastian Pedersen
    //Creation Date: May 7, 2022
    public class GenerateHexService
    {
        //used for generating the random number
        private Random rand = new Random();

        public string GenerateRandomHex()
        {
            //Generate the 3 random RGB values
            int r = rand.Next(0, 256);
            int g = rand.Next(0, 256);
            int b = rand.Next(0, 256);

            //Use the adapter to turn it into a hex value
            IHex hex = new ColorAdapter(new RGBModel(r, g, b));

            //return the hex
            return hex.Hex;
        }
    }
}
