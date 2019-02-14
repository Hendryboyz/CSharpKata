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
        public void CanConvertNumberToRoman()
        {
            string roman = converter.Convert(1);
            Assert.AreEqual("I", roman);
        }

        [TestCase(2, ExpectedResult = "II")]
        [TestCase(5, ExpectedResult = "V")]
        [TestCase(10, ExpectedResult = "X")]
        [TestCase(6, ExpectedResult = "VI")]
        [TestCase(4, ExpectedResult = "IV")]
        [TestCase(9, ExpectedResult = "IX")]
        public string GivenNumberLessEquan10_WhenConvert_ThenReturnRomanNumber(int number)
        {
            return converter.Convert(number);
        }
    }
}
