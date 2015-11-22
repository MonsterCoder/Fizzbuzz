using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzbuzzLibrary;
using Moq;
using Xunit;

namespace FizzbuzzTest
{
    public class FizzbuzzTest
    {
        private Mock mock = new Mock<IWritter>();
        
        private Fizzbuzz sut ;
        private IWritter _mockWritter;

        public FizzbuzzTest()
        {
            _mockWritter = (IWritter)mock.Object;
            sut = new Fizzbuzz(_mockWritter);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        public void WhenMultipleOf3ReturnFizz(int n)
        {
            Assert.Equal(sut.Parse(n), "Fizz");
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void WhenMultipleOf5ReturnBuzz(int n)
        {
            Assert.Equal(sut.Parse(n), "Buzz");
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        public void WhenMulitpleOfBothReturnFizzBuzz(int n)
        {
            Assert.Equal(sut.Parse(n), "FizzBuzz");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(7)]
        public void WhenNotReturnTheNumber(int n)
        {
            Assert.Equal(sut.Parse(n), n.ToString());
        }


    }
}
