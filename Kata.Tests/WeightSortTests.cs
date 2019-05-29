using FluentAssertions;
using Kata.CodeWar;
using NUnit.Framework;

// https://www.codewars.com/kata/weight-for-weight/csharp
namespace Kata.Tests
{
    [TestFixture]
    public class WeightSortTests
    {
        private WeightSort algorithm;

        [Test]
        public void CanCreate()
        {
            algorithm = new WeightSort();
            algorithm.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void TestCanSort()
        {
            string result = algorithm.Sort("1 2 3");
            result.Should().Be("1 2 3");
        }

        [Test]
        public void WhenGivenTwoDifferentWeightNumber_WhenSort_ThenReturnResult()
        {
            string result = algorithm.Sort("99 100");
            result.Should().Be("100 99");
        }

        [Test]
        public void WhenGivenTwoSameWeightButDifferentNumber_WhenSort_ThenReturnResult()
        {
            string result = algorithm.Sort("65 56");
            result.Should().Be("56 65");
        }

        [TestCase("56 65 74 100 99 68 86 180 90", "100 180 90 56 65 74 68 86 99")]
        [TestCase("103 123 4444 99 2000", "2000 103 123 4444 99")]
        [TestCase("2000 10003 1234000 44444444 9999 11 11 22 123", "11 11 2000 10003 22 123 1234000 44444444 9999")]
        public void WhenGivenNormalList_WhenSort_ThenReturnResult(string numbers, string expected)
        {
            string result = algorithm.Sort(numbers);
            result.Should().Be(expected);
        }
    }
}
