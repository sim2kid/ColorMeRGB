using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Services.Decorators;

namespace ServicesTest.Decorators
{
    //Author: Sebastian Pedersen
    //Creation date: May 9, 2022
    public class NumberSizeDecoratorTests
    {
        private NumberSizeAttribute nsa = new NumberSizeAttribute(0, 255);

        /// <summary>
        /// Make sure the number is not valid
        /// if the number is too small
        /// </summary>
        [Fact]
        public void FailOnTooSmall()
        {
            //Arrange
            int test = -1;

            //Act
            var result = nsa.IsValid(test);
            
            //Assert
            Assert.False(result);
        }

        /// <summary>
        /// Make sure the number is not valid if
        /// the number is too big
        /// </summary>
        [Fact]
        public void FailOnTooBig()
        {
            //Arrange
            int test = 256;

            //Act
            var result = nsa.IsValid(test);

            //Assert
            Assert.False(result);
        }

        /// <summary>
        /// Make sure the number is marked as valid
        /// if it falls within the bounds of the decorator
        /// </summary>
        [Fact]
        public void NumberIsValid()
        {
            //Arrange
            int test = 100;

            //Act
            var result = nsa.IsValid(test);

            //Assert
            Assert.True(result);
        }
    }
}
