using Services.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Written by Owen Ravelo

namespace Services.Color_Models
{
    public class RGBModel : IRGB
    {
        [NumberSize(0, 255)]
        public int R { get; set; } = 255;
        [NumberSize(0, 255)]
        public int G { get; set; } = 255;
        [NumberSize(0, 255)]
        public int B { get; set; } = 255;

        public RGBModel() 
        {

        }

        public RGBModel(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        public RGBModel(IRGB rgb)
        {
            R = rgb.R;
            G = rgb.G;
            B = rgb.B;
        }

        /// <summary>
        /// Returns the distance between two RGB elements.
        /// </summary>
        /// <returns></returns>
        public static float Distance(IRGB one, IRGB two) 
        {
            int x = one.R - two.R;
            int y = one.G - two.G;
            int z = one.B - two.B;
            float distance = (float)Math.Sqrt(x * x + y * y + z * z);
            return distance;
        }

        public float Distance(IRGB other) 
        {
            return RGBModel.Distance(this, other);
        }

        public bool isDark => ((R + G + B) / 3f) < (255f * 0.44);
    }
}
