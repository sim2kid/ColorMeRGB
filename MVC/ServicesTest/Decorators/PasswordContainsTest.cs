using Services.Decorators;
using Xunit;
namespace ServicesTest.Decorators
{
    public class PasswordContainsTest
    {
        private PasswordContainsAttribue pca = new PasswordContainsAttribue();
        // Owen Ravelo
        [Theory]
        [InlineData("pP1!")]
        [InlineData(".F/N$S`U#2TLu2Y!")]
        [InlineData("9F~!<X}afm.4xgPC")]
        [InlineData("<C,E$F[*XeY8X`4*")]
        [InlineData("`V\"p5;&2(DM2c(kD")]
        public void ValidPassword(string password) 
        {
            // Arrange
            // Act
            bool result = pca.IsValid(password);
            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("password")]
        [InlineData("PASSWORD")]
        [InlineData("12345678")]
        [InlineData("!@#$%^&*(")]
        [InlineData("PassWord")]
        [InlineData("OasE#%@$fs")]
        [InlineData("$%^467dg")]
        [InlineData("dFHD35")]
        [InlineData("#%FS")]
        public void InvalidPassword(string password)
        {
            // Arrange
            // Act
            bool result = pca.IsValid(password);
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void FailOnNone() 
        {
            // Arrange
            string password = string.Empty;
            // Act
            bool result = pca.IsValid(password);
            // Assert
            Assert.False(result);
        }
        [Fact]
        public void FailOnNull()
        {
            // Arrange
            string? password = null;
            // Act
            bool result = pca.IsValid(password);
            // Assert
            Assert.False(result);
        }
        [Fact]
        public void FailOnNotString()
        {
            // Arrange
            int password = 0;
            // Act
            bool result = pca.IsValid(password);
            // Assert
            Assert.False(result);
        }
    }
}
