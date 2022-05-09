using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Services.Adapters;
using Services.Color_Models;

namespace ServicesTest.Adapters
{
    //Author: Sebastian Pedersen
    //Creation Date: May 9, 2022
    public class ColorAdapterTests
    {
        /// <summary>
        /// Make sure the RGB is properly adapted to hex
        /// </summary>
        [Fact]
        public void ConvertToHexTest()
        {
            //Arrange
            int r = 100;
            int g = 255;
            int b = 60;

            RGBModel model = new RGBModel(r, g, b);

            string expected = "64FF3C";

            //Act
            var result = new ColorAdapter(model).Hex;

            //Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Make sure the r value of hex is properly adapted
        /// </summary>
        [Fact]
        public void ConvertToBase10RTest()
        {
            //Arrange
            string hex = "64FF3C";
            int expected = 100;

            HexModel model = new HexModel(hex);

            //Act
            var result = new ColorAdapter(model).R;

            //Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Make sure the g value of hex is properly adapted
        /// </summary>
        [Fact]
        public void ConvertToBase10GTest()
        {
            //Arrange
            string hex = "64FF3C";
            int expected = 255;

            HexModel model = new HexModel(hex);

            //Act
            var result = new ColorAdapter(model).G;

            //Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Make sure the b value of the hex is properly adapted
        /// </summary>
        [Fact]
        public void ConvertToBase10BTest()
        {
            //Arrange
            string hex = "64FF3C";
            int expected = 60;

            HexModel model = new HexModel(hex);

            //Act
            var result = new ColorAdapter(model).B;

            //Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        /// Make sure the distance between colors is properly calculated
        /// </summary>
        [Fact]
        public void DistanceCalculationTest()
        {
            //Arrange
            HexModel color1 = new HexModel("FF3264");
            RGBModel color2 = new RGBModel(255, 55, 100);
            ColorAdapter adapter = new ColorAdapter(color1);
            int expected = 5;

            //Act
            var result = adapter.Distance(color2);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
