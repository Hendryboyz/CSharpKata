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
        public void CanAddTwoRomanString()
        {
            string result = calculator.Add("I", "I");
            Assert.AreEqual("II", result);
        }
    }
}
