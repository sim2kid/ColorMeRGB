using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Services;

namespace UnitTests
{
    //Author: Sebastian Pedersen
    //Creation Date: May 9, 2022
    public class AuthenticationServicesTests
    {
        AuthenticationService service = new AuthenticationService();

        /// <summary>
        /// Test the generate password method to make sure there is a different hash
        /// even with the same input
        /// </summary>
        [Theory]
        [InlineData(".F/N$S`U#2TLu2Y!")]
        [InlineData("9F~!<X}afm.4xgPC")]
        [InlineData("<C,E$F[*XeY8X`4*")]
        [InlineData("`V\"p5;&2(DM2c(kD")]
        public void GeneratePasswordDifferentHashTest(string testInput1)
        {
            //Arrange
            string testInput2 = testInput1;

            //Act
            var result1 = service.GeneratePassword(testInput1).hash;
            var result2 = service.GeneratePassword(testInput2).hash;

            //Assert
            Assert.False(result1.Equals(result2));
        }
    }
}
