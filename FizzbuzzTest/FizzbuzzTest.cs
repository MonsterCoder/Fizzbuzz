using System;
using System.Collections.Generic;
using System.Linq;
using FizzbuzzLibrary;
using Moq;
using Xunit;

namespace FizzbuzzTest
{
    public class FizzbuzzTest
    {
        private readonly Mock<IWritter> _mock = new Mock<IWritter>();
        
        private readonly Fizzbuzz _sut ;

        public FizzbuzzTest()
        {
            _sut = new Fizzbuzz(_mock.Object, new KeyValuePair<int, string>(3, "Fizz"), new KeyValuePair<int, string>(5, "Buzz"));
        }

        [Fact]
        public void WhenLowerboundLargerThanUpperBoundThrowException()
        {
            Assert.Throws<ArgumentException>(() => _sut.Run(999, 1));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        public void WhenMultipleOf3ReturnFizz(int n)
        {
            Assert.Equal(_sut.Parse(n), "Fizz");
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void WhenMultipleOf5ReturnBuzz(int n)
        {
            Assert.Equal(_sut.Parse(n), "Buzz");
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        public void WhenMulitpleOfBothReturnFizzBuzz(int n)
        {
            Assert.Equal(_sut.Parse(n), "FizzBuzz");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(7)]
        public void WhenNotReturnTheNumber(int n)
        {
            Assert.Equal(_sut.Parse(n), n.ToString());
        }

        [Fact]
        public void ShouldOutputTheResult()
        {
            _sut.Run(-15,15);
            _mock.Verify(writter => writter.WriteLine("Fizz"), Times.Exactly(8));
            _mock.Verify(writter => writter.WriteLine("Buzz"), Times.Exactly(4));
            _mock.Verify(writter => writter.WriteLine("FizzBuzz"), Times.Exactly(2));
            _mock.Verify(writter => writter.WriteLine(It.IsAny<string>()), Times.Exactly(31));
        }

    }

    public class FizzbuzzRuleTest
    {
        Fizzbuzz.Rule _sut = new Fizzbuzz.Rule(4, "Foo");

        [Theory]
        [InlineData(4)]
        [InlineData(8)]
        public void WhenModWithKeyReturnsValue(int n)
        {
            Assert.Equal(_sut.Apply(n), "Foo");
        }

        [Theory]
        [InlineData(5)]
        [InlineData(3)]
        [InlineData(1)]
        public void WhenNotModOfKeyReturnsEmpty(int n)
        {
            Assert.Equal(_sut.Apply(n), string.Empty);
        }

        [Fact]
        public void WhenKeyIsZeroThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Fizzbuzz.Rule(0, "Hello"));
        }

        [Fact]
        public void WhenInputZeroItReturnsEmpty()
        {
            Assert.Equal(_sut.Apply(0), string.Empty);
        }
    }
}
