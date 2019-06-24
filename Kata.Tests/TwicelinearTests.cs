using FluentAssertions;
using Kata.CodeWar;
using NUnit.Framework;
using System;

namespace Kata.Tests
{
    [TestFixture]
    public class TwiceLinearTests
    {
        private TwiceLinear algorithm;

        [Test]
        public void CanCreate()
        {
            algorithm = new TwiceLinear();
            algorithm.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanGetAt()
        {
            int result = algorithm.GetAt(0);
            result.Should().Be(1);
        }

        [TestCase(2, 4)]
        [TestCase(10, 22)]
        public void GivenSimpleCase_WhenGetAt_ThenReturnIntAtPositionN(int n, int numberAtN)
        {
            int result = algorithm.GetAt(n);
            result.Should().Be(numberAtN);
        }

        [TestCase(20, 57)]
        [TestCase(30, 91)]
        [TestCase(50, 175)]
        public void GivenMediumSizeCaseWhenGetAt_ThenReturnIntAtPositionN(int n, int numberAtN)
        {
            int result = algorithm.GetAt(n);
            result.Should().Be(numberAtN);
        }

        [Test]
        [Timeout(12000)]
        public void GivenLargeSizeCaseWhenGetAt_ThenReturnIntNotTimeout()
        {
            int result = algorithm.GetAt(60000);
            Console.WriteLine(result);
        }
    }
}
