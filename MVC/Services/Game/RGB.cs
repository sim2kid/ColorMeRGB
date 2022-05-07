using Services.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Written by Owen Ravelo

namespace Services.Game
{
    public class RGB
    {
        [NumberSize(0,255)]
        public int R { get; set; }
        [NumberSize(0, 255)]
        public int G { get; set; }
        [NumberSize(0, 255)]
        public int B { get; set; }

        public RGB() 
        {
            R = 255;
            G = 255;
            B = 255;
        }

        public RGB(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        /// <summary>
        /// Returns the distance between two RGB elements.
        /// </summary>
        /// <returns></returns>
        public static float Distance(RGB one, RGB two) 
        {
            int x = one.R - two.R;
            int y = one.G - two.G;
            int z = one.B - two.B;
            float distance = (float)Math.Sqrt(x * x + y * y + z * z);
            return distance;
        }

        public float Distance(RGB other) 
        {
            return RGB.Distance(this, other);
        }
    }
}
