using Kata.Calculator;
using NUnit.Framework;

namespace Kata.Tests
{
    [TestFixture]
    public class RomanCalculatorTests
    {
        private RomanCalculator calculator;

        [Test]
        public void CanCreate()
        {
            calculator = new RomanCalculator();
            Assert.NotNull(calculator);
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanAdd()
        {
            string result = calculator.Add("I", "I");
            Assert.AreEqual("II", result);
        }

        [TestCase("II", "I", ExpectedResult = "III")]
        [TestCase("II", "II", ExpectedResult = "IV")]
        [TestCase("IV", "I", ExpectedResult = "V")]
        //[TestCase("VII", "II", ExpectedResult = "IX")]
        [TestCase("IX", "I", ExpectedResult = "X")]
        //[TestCase("V", "IV", ExpectedResult = "IX")]
        public string GivenRomanNumberalLessEqualX_WhenAdd_ThenReturnResult(string augend, string addend)
        {
            return calculator.Add(augend, addend);
        }
    }
}
