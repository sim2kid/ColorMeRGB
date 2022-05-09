using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Services;
using Services.Color_Models;

namespace ServicesTest
{
    //Author: Sebastian Pedersen
    //Creation Date: May 9, 2022
    public class GameServicesTest
    {
        GameService service = new GameService();

        /// <summary>
        /// Make sure HasWin() returns true when its supposed to
        /// </summary>
        [Fact]
        public void HasWinTrueTest()
        {
            //Arrange
            RGBModel answerColorTest = new RGBModel(100, 255, 65);
            RGBModel guessColorTest = new RGBModel(100, 255, 60);

            //Act
            var result = service.hasWin(answerColorTest, guessColorTest);

            //Assert
            Assert.True(result);
        }

        /// <summary>
        /// Make sure HasWin() returns false when its supposed to
        /// </summary>
        [Fact]
        public void HasWinFalseTest()
        {
            //Arrange
            RGBModel answerColorTest = new RGBModel(100, 255, 65);
            RGBModel guessColorTest = new RGBModel(100, 255, 40);

            //Act
            var result = service.hasWin(answerColorTest, guessColorTest);

            //Assert
            Assert.False(result);
        }

        /// <summary>
        /// Make sure HasEnd() returns true when it's supposed to
        /// </summary>
        [Fact]
        public void HasEndTrueTest()
        {
            //Arrange
            int guessCountTest = 5;

            //Act
            var result = service.hasEnd(guessCountTest);

            //Assert
            Assert.True(result);
        }

        /// <summary>
        /// Make sure HasEnd() returns true when it's supposed to
        /// </summary>
        [Fact]
        public void HasEndFalseTest()
        {
            //Arrange
            int guessCountTest = 4;

            //Act
            var result = service.hasEnd(guessCountTest);

            //Assert
            Assert.False(result);
        }
    }
}
