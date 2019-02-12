using Kata.Calculator;
using NUnit.Framework;

namespace Kata.Tests
{
    [TestFixture]
    public class RomanCalculatorTests
    {
        private RomainCalculator calculator;

        [Test]
        public void CanCreate()
        {
            calculator = new RomainCalculator();
            Assert.NotNull(calculator);
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }
        
        [Test]
        public void CanAddTwoRomanString()
        {
            string result = calculator.Add("I", "I");
            Assert.AreEqual("II", result);
        }

        [TestCase("I", "III", ExpectedResult = "IV")]
        [TestCase("IV", "I", ExpectedResult = "V")]
        [TestCase("IV", "III", ExpectedResult = "VII")]
        [TestCase("IV", "IV", ExpectedResult = "VIII")]
        public string GivenTwoRomanNumber_WhenAdd_ThenReturnSummary(string augend, string addend)
        {
            return calculator.Add(augend, addend);
        }
    }
}
