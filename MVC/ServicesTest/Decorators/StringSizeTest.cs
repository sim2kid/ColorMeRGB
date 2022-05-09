using Services.Decorators;
using Xunit;
namespace ServicesTest.Decorators
{
    public class StringSizeTest
    {
        private StringSizeAttribute ssa = new StringSizeAttribute(5, 10);
        // Owen Ravelo
        [Theory]
        [InlineData("5jBX?")]
        [InlineData("Gp%3D3")]
        [InlineData("/8NeSTH")]
        [InlineData("SNhg#W2?")]
        [InlineData("z/Y2;XH[U")]
        [InlineData("%zG;HQNS5*")]
        public void ValidPassword(string password)
        {
            // Arrange
            // Act
            bool result = ssa.IsValid(password);
            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("0")]
        [InlineData("%zG;")]
        [InlineData("6%a)4RQAN\\Y")]
        [InlineData("")]
        public void InvalidPassword(string password)
        {
            // Arrange
            // Act
            bool result = ssa.IsValid(password);
            // Assert
            Assert.False(result);
        }

        [Fact]
        public void FailOnNull()
        {
            // Arrange
            string? password = null;
            // Act
            bool result = ssa.IsValid(password);
            // Assert
            Assert.False(result);
        }
        [Fact]
        public void FailOnNotString()
        {
            // Arrange
            int password = 0;
            // Act
            bool result = ssa.IsValid(password);
            // Assert
            Assert.False(result);
        }
    }
}
