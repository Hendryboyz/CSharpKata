using Kata.Converter;
using NUnit.Framework;
using System;

namespace Kata.Tests
{
    [TestFixture]
    public class Number2LCDTests
    {
        private LcdConverter converter;

        [Test]
        public void CanCreate()
        {
            converter = new LcdConverter();
            Assert.NotNull(converter);
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanConvertDigit()
        {
            string result = converter.Convert(1);
            Console.WriteLine(result);

            Assert.AreEqual("   \n  |\n  |", result);
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
        public void GivenDigit_WhenConvert_ThenReturnLcdFormat(int digit, string expected)
        {
            string result = converter.Convert(digit);
            Console.WriteLine(result);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenDigitAndScale_WhenConvert_ThenReturnLcdFormat()
        {
            string result = converter.Convert(2, 2, 2);
            Console.WriteLine(result);
            Assert.AreEqual(" ____ \n     |\n     |\n ____ \n|     \n|     \n ____ \n", result);
        }
    }
}
