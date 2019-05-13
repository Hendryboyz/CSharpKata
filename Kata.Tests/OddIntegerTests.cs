using FluentAssertions;
using Kata.CodeWar;
using NUnit.Framework;

// https://www.codewars.com/kata/find-the-odd-int/train/csharp

namespace Kata.Tests
{
    [TestFixture]
    public class OddIntegerTests
    {
        private OddInteger algorithm;

        [Test]
        public void CanCreate()
        {
            algorithm = new OddInteger();
            algorithm.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void TestCanFind()
        {
            int integer = algorithm.Find(new int[] { 1 });
            integer.Should().Be(1);
        }

        [Test]
        public void GivenSequenceOfIntegers_WhenFind_ThenReturnOddInteger()
        {
            int integer = algorithm.Find(new int[] { 20, 1, -1, 2, -2, 3, 3, 5, 5, 1, 2, 4, 20, 4, -1, -2, 5 });
            integer.Should().Be(5);
        }
    }
}
