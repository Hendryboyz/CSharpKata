using Kata.Converter;
using NUnit.Framework;
using System;

namespace Kata.Tests
{
    [TestFixture]
    public class Number2LCDTests
    {
        private LcdConverter lcdConverter;

        [Test]
        public void CanCreate()
        {
            lcdConverter = new LcdConverter();
            Assert.NotNull(lcdConverter);
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanConvertDigit()
        {
            ConvertAndAssert(1, "   \n  |\n  |");
        }

        [TestCase(2, " _ \n _|\n|_ ")]
        [TestCase(3, " _ \n _|\n _|")]
        [TestCase(4, "   \n|_|\n  |")]
        [TestCase(5, " _ \n|_ \n _|")]
        [TestCase(6, "   \n|_ \n|_|")]
        [TestCase(7, " _ \n  |\n  |")]
        [TestCase(8, " _ \n|_|\n|_|")]
        [TestCase(9, " _ \n|_|\n _|")]
        [TestCase(0, " _ \n| |\n|_|")]
        public void GivenSingleDigit_WhenConvert_ThenReturnLcdNumber(int digit, string expected)
        {
            ConvertAndAssert(digit, expected);
        }

        private void ConvertAndAssert(int digit, string expected)
        {
            string result = lcdConverter.Convert(digit);
            Console.WriteLine(result);
            Assert.AreEqual(expected, result);
        }

        [TestCase(-1)]
        [TestCase(10)]
        public void GivenMultipleDigit_WhenConvert_ThenThrowInvalidCaseException(int digit)
        {
            Assert.Throws<InvalidCastException>(() => lcdConverter.Convert(digit));
        }

        [TestCase(1, "      \n     |\n     |\n     |\n     |\n")]
        [TestCase(2, " ____ \n     |\n     |\n ____ \n|     \n|     \n ____ \n")]
        [TestCase(3, " ____ \n     |\n     |\n ____ \n     |\n     |\n ____ \n")]
        [TestCase(4, "      \n|    |\n|    |\n ____ \n     |\n     |\n")]
        public void GivenSingleDigitAndScale_WhenConvert_ThenReturnScaledNumber(
            int digit, string expected)
        {
            string result = lcdConverter.Convert(digit, 2, 2);
            Console.WriteLine(result);
            Assert.AreEqual(expected, result);
        }
    }
}
