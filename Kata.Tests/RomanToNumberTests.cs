using Kata.Converter;
using NUnit.Framework;
using System;

namespace Kata.Tests
{
    [TestFixture]
    public class RomanToNumberTests
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
        public void CanConvertFromRoman()
        {
            int result = converter.ConvertFromRoman("I");
            Assert.AreEqual(1, result);
        }

        [TestCase("II", ExpectedResult = 2)]
        [TestCase("X", ExpectedResult = 10)]
        [TestCase("V", ExpectedResult = 5)]
        [TestCase("VI", ExpectedResult = 6)]
        [TestCase("IV", ExpectedResult = 4)]
        [TestCase("IX", ExpectedResult = 9)]
        public int GivenRomanNumberalLessThanX_WhenConvertFromRoman_ThenReturnDecimal(string roman)
        {
            return converter.ConvertFromRoman(roman); 
        }

        [TestCase("L", ExpectedResult = 50)]
        [TestCase("C", ExpectedResult = 100)]
        [TestCase("D", ExpectedResult = 500)]
        [TestCase("M", ExpectedResult = 1000)]
        public int GivenBaseRomanNumberalNotation_WhenConvertFromRoman_ThenReturnDecimal(string roman)
        {
            return converter.ConvertFromRoman(roman);
        }

        [TestCase("XCIX", ExpectedResult = 99)]
        [TestCase("XLV", ExpectedResult = 45)]
        [TestCase("DCCCVIII", ExpectedResult = 808)]
        public int GivenCornerRomanNumberal_WhenConvertFromRoman_ThenReturnDecimal(string roman)
        {
            return converter.ConvertFromRoman(roman);
        }

        [TestCase("VX")]
        [TestCase("LC")]
        [TestCase("DM")]
        public void GivenInvalidDerementNotation_WhenConvertFromRoman_ThenThrowInvalidOperationException(string roman)
        {
            Assert.Throws<InvalidOperationException>(() => converter.ConvertFromRoman(roman));
        }

        [TestCase("IIII")]
        [TestCase("LIIII")]
        [TestCase("VV")]
        [TestCase("LL")]
        [TestCase("DD")]
        public void GivenInvalidDuplicatedNotation_WhenConvertFromRoman_ThenThrowInvalidOperationException(string roman)
        {
            Assert.Throws<InvalidOperationException>(() => converter.ConvertFromRoman(roman));
        }
    }
}
