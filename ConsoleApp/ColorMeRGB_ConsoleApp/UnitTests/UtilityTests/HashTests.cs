using Xunit;
using Services.Utilities;

namespace UnitTests.UtilityTests
{
    //Author: Sebastian Pedersen
    //Creation Date: May 9, 2022
    public class HashTests
    {
        /// <summary>
        /// Make sure the GenerateSalt() method always generates a new salt
        /// </summary>
        [Fact]
        public void CheckDifferentSaltTest()
        {
            //Arrange
            string salt1;
            string salt2;

            //Act
            salt1 = HashUtil.GenerateSalt();
            salt2 = HashUtil.GenerateSalt();

            //Assert
            Assert.False(salt1.Equals(salt2));
        }

        /// <summary>
        /// Make sure the hash for a password is consistent with the same salt
        /// </summary>
        /// <param name="pass"></param>
        [Theory]
        [InlineData(".F/N$S`U#2TLu2Y!")]
        [InlineData("9F~!<X}afm.4xgPC")]
        [InlineData("<C,E$F[*XeY8X`4*")]
        [InlineData("`V\"p5;&2(DM2c(kD")]
        public void CheckHashGenerationTest(string pass)
        {
            //Arrange
            string salt = HashUtil.GenerateSalt();
            
            //Act
            var result1 = HashUtil.HashPassword(pass, salt);
            var result2 = HashUtil.HashPassword(pass, salt);

            //Assert
            Assert.Equal(result1, result2);
        }

        /// <summary>
        /// Check to make sure the hashes are different 
        /// for the same password based on salt
        /// </summary>
        /// <param name="pass"></param>
        [Theory]
        [InlineData(".F/N$S`U#2TLu2Y!")]
        [InlineData("9F~!<X}afm.4xgPC")]
        [InlineData("<C,E$F[*XeY8X`4*")]
        [InlineData("`V\"p5;&2(DM2c(kD")]
        public void CheckHashDifferentSaltTest(string pass)
        {
            //Arrange
            string salt1 = HashUtil.GenerateSalt();
            string salt2 = HashUtil.GenerateSalt();

            //Act
            var hash1 = HashUtil.HashPassword(pass, salt1);
            var hash2 = HashUtil.HashPassword(pass, salt2);

            //Assert
            Assert.False(hash1.Equals(hash2));
        }

        /// <summary>
        /// Test to make sure that the CheckPassword() method properly checks the password
        /// </summary>
        /// <param name="pass"></param>
        [Theory]
        [InlineData(".F/N$S`U#2TLu2Y!")]
        [InlineData("9F~!<X}afm.4xgPC")]
        [InlineData("<C,E$F[*XeY8X`4*")]
        [InlineData("`V\"p5;&2(DM2c(kD")]
        public void CheckPasswordTest(string pass)
        {
            //Arrange
            string salt = HashUtil.GenerateSalt();
            string hash = HashUtil.HashPassword(pass, salt);

            //Act
            var result = HashUtil.CheckPassword(hash, pass, salt);

            //Assert
            Assert.True(result);
        }
    }
}