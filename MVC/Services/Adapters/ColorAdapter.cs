using Services.Color_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Services.Adapters
{
    //Author: Sebastian Pedersen
    // Owen Helped
    //Creation Date: May 7, 2022
    public class ColorAdapter : IHex, IRGB
    {
        //When converting from RGB to Hex
        public string Hex
        {
            //We have to make sure there is an RGB to convert
            get
            {
                if (_IRGB == null)
                {
                    throw new Exception("Not an RGB");
                }

                //get the hex from _IRGB rgb values
                return ConvertToHex(_IRGB.R, _IRGB.G, _IRGB.B);
            }
            set
            {
                if (_IRGB == null)
                {
                    throw new Exception("Not an RGB");
                }

                //adapt to RGB when setting hex
                var result = ConvertToBase10(value);
                _IRGB.R = result.r;
                _IRGB.G = result.g;
                _IRGB.B = result.b;
            }
        }

        //When converting from Hex to RGB (Red)
        public int R
        {
            //we have to make sure there is a hex value to convert first
            get
            {
                if (_IHex == null)
                {
                    throw new Exception("Not a hex");
                }
                //get the red value from the hex
                return ConvertToBase10(_IHex.Hex).r;
            }
            set
            {
                if(_IHex == null)
                {
                    throw new Exception("Not a hex");
                }

                //adapt to hex when setting RGB
                string rHex = value.ToString("X");
                _IHex.Hex = rHex + _IHex.Hex.Substring(2, 4);
            }
        }
        //When converting from Hex to RGB (Green)
        public int G
        {
            //we have to make sure there is a hex value to convert first
            get
            {
                if (_IHex == null)
                {
                    throw new Exception("Not a hex");
                }
                //get the green value from hex
                return ConvertToBase10(_IHex.Hex).g;
            }
            set
            {
                if (_IHex == null)
                {
                    throw new Exception("Not a hex");
                }
                //adapt to hex when setting RGB
                string gHex = value.ToString("X");
                _IHex.Hex = _IHex.Hex.Substring(0, 2) + gHex + _IHex.Hex.Substring(4, 2);
            }
        }
        //When converting from Hex to RGB (Blue)
        public int B
        {
            //we have to make sure there is a hex value to convert first
            get
            {
                if (_IHex == null)
                {
                    throw new Exception("Not a hex");
                }
                //get the blue value from hex
                return ConvertToBase10(_IHex.Hex).b;
            }
            set
            {
                if (_IHex == null)
                {
                    throw new Exception("Not a hex");
                }
                //adapt to hex when setting RGB
                string bHex = value.ToString("X");
                _IHex.Hex = _IHex.Hex.Substring(0, 4) + bHex;
            }
        }

        private IRGB _IRGB;
        private IHex _IHex;

        //constructor
        //_IRGB and _IHex are used for the Gets and Sets of the above properties
        public ColorAdapter(IRGB rgb)
        {
            _IRGB = rgb;
        }

        public ColorAdapter(IHex hex)
        {
            _IHex = hex;
        }

        //Convert from RGB to hex
        //Isolate the different RGB values, and append them to the string builder
        //return the string builder
        private string ConvertToHex(int r, int g, int b)
        {
            StringBuilder sbHex = new StringBuilder();

            //Convert each value to hex and then append it to sbHex
            sbHex.Append(r.ToString("X2"));
            sbHex.Append(g.ToString("X2"));
            sbHex.Append(b.ToString("X2"));

            //set Hex equal to sbHex
            return sbHex.ToString();
        }

        //using a tuple to convert from hex to RGB
        //using the tuple, we can then assign the individual values of RGB without needing multiple methods
        private (int r, int g, int b) ConvertToBase10(string hex)
        {
            //since each RGB value represents 2 characters in the hex, use substrings to set the colors specifically and return them in tuple
            string r = hex.Substring(0, 2);
            string g = hex.Substring(2, 2);
            string b = hex.Substring(4, 2);

            return (Convert.ToInt32(r, 16), Convert.ToInt32(g, 16), Convert.ToInt32(b, 16));
        }

        public float Distance(IRGB other)
        {
            if (_IHex == null)
            {
                throw new Exception("Not a Hex");
            }
            return RGBModel.Distance(this, other);
        }

        public bool isDark => ((R + G + B) / 3f) < (255f * 0.44);
    }
}
