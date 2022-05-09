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
    public class TokenServiceTests
    {
        TokenService service = new TokenService();

        /// <summary>
        /// Make sure the token is marked as not valid if the token is null or empty
        /// </summary>
        [Fact]
        public void TokenIsNotValidWhenNullTest()
        {
            //Arrange
            string testToken = "";

            //Act
            var result = service.TokenIsValid(testToken);

            //Assert
            Assert.False(result);
        }

        /// <summary>
        /// Make sure the token is marked as not valid if the token is malformed or modified
        /// </summary>
        /// <param name="testToken"></param>
        [Theory]
        [InlineData("asldkfj;alsdnv;asdnv;advn'WJFS;DKVNA;KVN;SKJVNAS;KJDVNSDK;JVBAS;LFNAD;KFHwl;kbs;dlkfnas;kjvhaelnfakfvbawelfn")]
        [InlineData("asdf.sdfghjk.asdfghjkl")]
        [InlineData("1234567890qwertyuiopasdfghjklzxcvbnm")]
        public void TokenIsNotValidWhenMalformedTest(string testToken)
        {
            //Act
            var result = service.TokenIsValid(testToken);

            //Assert
            Assert.False(result);
        }

        /// <summary>
        /// Make sure that the GenerateToken() method
        /// generates a valid token
        /// </summary>
        [Fact]
        public void GenerateTokenCreatesValidToken()
        {
            //Arrange
            string token = service.GenerateToken(Guid.NewGuid());

            //Act
            var result = service.TokenIsValid(token);

            //Assert
            Assert.True(result);
        }

        /// <summary>
        /// Make sure that the GetUserId method returns a Guid
        /// </summary>
        [Fact]
        public void GetUserIdReturnsGuidTest()
        {
            //Arrange
            Guid testId = Guid.NewGuid();
            string token = service.GenerateToken(testId);

            //Act
            var result = service.GetUserId(token);

            //Assert
            Assert.Equal(testId, result);
        }
    }
}
