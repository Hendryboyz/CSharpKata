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

        [Test(ExpectedResult = ("   \n  |\n  |"))]
        public string CanGivenDigitAndConvert()
        {
            return ConvertAndPrintResult(1);
        }

        private string ConvertAndPrintResult(int digit)
        {
            string result = lcdConverter.Convert(digit);
            Console.WriteLine(result);
            return result;
        }

        [TestCase(2, ExpectedResult = " _ \n _|\n|_ ")]
        [TestCase(3, ExpectedResult = " _ \n _|\n _|")]
        [TestCase(4, ExpectedResult = "   \n|_|\n  |")]
        [TestCase(5, ExpectedResult = " _ \n|_ \n _|")]
        [TestCase(6, ExpectedResult = "   \n|_ \n|_|")]
        [TestCase(7, ExpectedResult = " _ \n  |\n  |")]
        [TestCase(8, ExpectedResult = " _ \n|_|\n|_|")]
        [TestCase(9, ExpectedResult = " _ \n|_|\n _|")]
        [TestCase(0, ExpectedResult = " _ \n| |\n|_|")]
        public string GivenSingleDigit_WhenConvert_ThenReturnLcdNumber(int digit)
        {
            return ConvertAndPrintResult(digit);
        }

        [TestCase(-1)]
        [TestCase(10)]
        public void GivenMultipleDigit_WhenConvert_ThenThrowArgumentOutOfRangeExceptionException(int digit)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => lcdConverter.Convert(digit));
        }


        [TestCase(1, ExpectedResult = "      \n     |\n     |\n     |\n     |\n")]
        [TestCase(2, ExpectedResult = " ____ \n     |\n     |\n ____ \n|     \n|     \n ____ \n")]
        [TestCase(3, ExpectedResult = " ____ \n     |\n     |\n ____ \n     |\n     |\n ____ \n")]
        [TestCase(4, ExpectedResult = "      \n|    |\n|    |\n ____ \n     |\n     |\n")]
        public string GivenSingleDigitAndScale_WhenConvert_ThenRetunScaledLcdNumber(int digit)
        {
            string result = lcdConverter.Convert(digit, 2, 2);
            Console.WriteLine(result);
            return result;
        }
    }
}
