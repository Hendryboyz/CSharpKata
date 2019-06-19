using FluentAssertions;
using Kata.CodeWar;
using NUnit.Framework;

namespace Kata.Tests
{
    [TestFixture]
    public class LargeFactorialsTests
    {
        private LargeFactorials algorithm;

        [Test]
        public void CanCreate()
        {
            algorithm = new LargeFactorials();
            algorithm.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanCalculate()
        {
            string result = algorithm.Calculate(1);
            result.Should().Be("1");
        }

        [TestCase(5, "120")]
        [TestCase(7, "5040")]
        public void GivenSmallN_WhenCalculate_ThenReturnResult(int n, string expected)
        {
            string result = algorithm.Calculate(n);
            result.Should().Be(expected);
        }

        [TestCase(9, "362880")]
        [TestCase(15, "1307674368000")]
        [Timeout(12000)]
        public void GivenLargeN_WhenCalculate_ThenReturnNoTimeout(int n, string expected)
        {
            string result = algorithm.Calculate(n);
            result.Should().Be(expected);
        }

        [TestCase(20)]
        [TestCase(50)]
        [Timeout(12000)]
        public void GivenLargeN_WhenCalculate_ThenNoTimeout(int n)
        {
            string result = algorithm.Calculate(n);
        }
    }
}
