using Services.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Color_Models
{
    //Author: Sebastian Pedersen
    //Creation Date: May 7, 2022
    public interface IRGB
    {
        [NumberSize(0, 255)]
        public int R { get; set; }

        [NumberSize(0, 255)]
        public int G { get; set; }

        [NumberSize(0, 255)]
        public int B { get; set; }

        public float Distance(IRGB other);
    }
}
