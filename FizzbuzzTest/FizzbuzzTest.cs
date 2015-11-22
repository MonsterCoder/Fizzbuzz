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
        private Mock mock = new Mock<IWriter>();
        
        private Fizzbuzz sut ;
        private IWriter _mockWriter;

        public FizzbuzzTest()
        {
            _mockWriter = (IWriter)mock.Object;
            sut = new Fizzbuzz(_mockWriter);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        public void WhenMultipleOf3ReturnFizz(int n)
        {
            Assert.Equal(sut.Trans(n), "Fizz");
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void WhenMultipleOf5ReturnBuzz(int n)
        {
            Assert.Equal(sut.Trans(n), "Buzz");
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        public void WhenMulitpleOfBothReturnFizzBuzz(int n)
        {
            Assert.Equal(sut.Trans(n), "FizzBuzz");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(7)]
        public void WhenNotReturnTheNumber(int n)
        {
            Assert.Equal(sut.Trans(n), n.ToString());
        }


    }
}
