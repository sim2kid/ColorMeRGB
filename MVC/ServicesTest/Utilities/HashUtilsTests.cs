using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Services.Utilities;

namespace ServicesTest.Utilities
{
    //Author: Sebastian Pedersen
    //Creation date: May 9, 2022
    public class HashUtilsTests
    {
        /// <summary>
        /// Make sure the hashing on the MVC side is consistent
        /// </summary>
        /// <param name="testPass"></param>
        [Theory]
        [InlineData("QWERTY23456#")]
        [InlineData("sdfghRTYU67&&&")]
        [InlineData("1234567890")]
        [InlineData("!@#$%^&*()")]
        [InlineData("qwertyuio")]
        [InlineData("ASDFGHJKL")]
        public void CheckHashConsistencyTest(string testPass)
        {
            //Arrange
            string pass2 = testPass;

            //Act
            var result1 = HashUtil.HashPassword(testPass);
            var result2 = HashUtil.HashPassword(pass2);

            //Assert
            Assert.Equal(result1, result2);
        }
    }
}
