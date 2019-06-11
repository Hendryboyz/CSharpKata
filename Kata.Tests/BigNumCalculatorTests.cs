using FluentAssertions;
using Kata.CodeWar;
using NUnit.Framework;

namespace Kata.Tests
{
    [TestFixture]
    public class BigNumCalculatorTests
    {
        private BigNumCalculator calculator;

        [Test]
        public void CanCreate()
        {
            calculator = new BigNumCalculator();
            calculator.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanAdd()
        {
            string sum = calculator.Add("1", "1");
            sum.Should().Be("2");
        }

        [TestCase("3", "4", "7")]
        [TestCase("21", "25", "46")]
        [TestCase("123", "456", "579")]
        public void GivenNotNeedCarryCase_ThenAdd_ReturnSummary(
            string augend, string addend, string sum)
        {
            string result = calculator.Add(augend, addend);
            result.Should().Be(sum);
        }

        [TestCase("5", "5", "10")]
        [TestCase("15", "15", "30")]
        [TestCase("85", "15", "100")]
        public void GivenHavingCarryCase_ThenAdd_ReturnSummary(
            string augend, string addend, string sum)
        {
            string result = calculator.Add(augend, addend);
            result.Should().Be(sum);
        }

        [TestCase("15", "5", "20")]
        [TestCase("95", "5", "100")]
        [TestCase("5", "95", "100")]
        [TestCase("999998", "2", "1000000")]
        public void GivenImbalanceNum_ThenAdd_ReturnSummary(
            string augend, string addend, string sum)
        {
            string result = calculator.Add(augend, addend);
            result.Should().Be(sum);
        }
    }
}
