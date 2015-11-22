using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly Mock<IWritter> mock = new Mock<IWritter>();
        
        private readonly Fizzbuzz sut ;

        private readonly IWritter _mockWritter;

        public FizzbuzzTest()
        {
            _mockWritter = mock.Object;
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

        [Fact]
        public void WhenRunFizzbuzzShouldOutputResult()
        {
            sut.Run(Enumerable.Range(1,15).ToArray());
            mock.Verify(writter => writter.WriteLine("Fizz"), Times.Exactly(4));
            mock.Verify(writter => writter.WriteLine("Buzz"), Times.Exactly(2));
            mock.Verify(writter => writter.WriteLine("FizzBuzz"), Times.Exactly(1));
            mock.Verify(writter => writter.WriteLine(It.IsAny<string>()), Times.Exactly(15));
        }
    }
}
