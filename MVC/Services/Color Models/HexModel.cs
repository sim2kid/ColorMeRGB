using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Color_Models
{
    public class HexModel : IHex
    {
        public string Hex { get; set; }

        public HexModel() 
        {
            Hex = "FF00FF";
        }

        public HexModel(string hex) 
        {
            if (hex.Length != 6)
            {
                Hex = "FF00FF";
            }
            else
            {
                Hex = hex;
            }
        }
    }
}
