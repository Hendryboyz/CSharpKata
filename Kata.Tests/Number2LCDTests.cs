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
        public void CanSetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanGivenDigitAndConvert()
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
        public void GivenSingleDigit_WhenConvert_ThenReturnLcdDigit(int digit, string expected)
        {
            string result = converter.Convert(digit);
            Console.WriteLine(result);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenNumberNotDigit_WhenConvert_ThenThrowInvalidCastException()
        {
            Assert.Throws<InvalidCastException>(() => converter.Convert(10));
        }

        [TestCase(2, " ____ \n     |\n     |\n ____ \n|     \n|     \n ____ \n")]
        public void GivenNumberAndScale_WhenConvert_ThenReturnScaleLcdDigit(int digit, string expected)
        {
            string result = converter.Convert(digit, 2, 2);
            Console.WriteLine(result);
            Assert.AreEqual(expected, result);
        }

    }
}
