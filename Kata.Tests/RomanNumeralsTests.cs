using Kata.Converter;
using NUnit.Framework;

namespace Kata.Tests
{
    [TestFixture]
    public class RomanNumeralsTests
    {
        private RomanNumberalConverter converter;

        [Test]
        public void CanCreate()
        {
            converter = new RomanNumberalConverter();
            Assert.NotNull(converter);
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanConvertToRoman()
        {
            string result = converter.ConvertFromDigit(1);
            Assert.AreEqual("I", result);
        }

        [TestCase(2, ExpectedResult = "II")]
        [TestCase(5, ExpectedResult = "V")]
        [TestCase(10, ExpectedResult = "X")]
        [TestCase(6, ExpectedResult = "VI")]
        [TestCase(4, ExpectedResult = "IV")]
        [TestCase(9, ExpectedResult = "IX")]
        public string GivenDigitLessEqual10_WhenConvertFromDigit_ThenReturnRomanNumber(int number)
        {
            return converter.ConvertFromDigit(number);
        }

        [TestCase(50, ExpectedResult = "L")]
        [TestCase(45, ExpectedResult = "XLV")]
        public string GivenDigitLessEquan50_WhenConvertFromDigit_ThenReturnRomanNumber(int number)
        {
            return converter.ConvertFromDigit(number);
        }

        [TestCase(99, ExpectedResult = "XCIX")]
        public string GivenDigitLessEquan100_WhenConvertFromDigit_ThenReturnRomanNumber(int number)
        {
            return converter.ConvertFromDigit(number);
        }
    }
}
