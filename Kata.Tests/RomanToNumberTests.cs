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
        [TestCase("V", ExpectedResult = 5)]
        [TestCase("X", ExpectedResult = 10)]
        [TestCase("VI", ExpectedResult = 6)]
        [TestCase("VIII", ExpectedResult = 8)]
        [TestCase("IV", ExpectedResult = 4)]
        [TestCase("IX", ExpectedResult = 9)]
        public int GivenLessThan10RomanNumberal_WhenConvertFromRoman_ThenReturnDecimal(string romanNumber)
        {
            return converter.ConvertFromRoman(romanNumber);
        }

        [TestCase("L", ExpectedResult = 50)]
        [TestCase("C", ExpectedResult = 100)]
        [TestCase("D", ExpectedResult = 500)]
        [TestCase("M", ExpectedResult = 1000)]
        public int GivenBaseRomanNumberal_WhenConvertFromRoman_ThenReturnDecimal(string romanNumber)
        {
            return converter.ConvertFromRoman(romanNumber);
        }

        [TestCase("XCIX", ExpectedResult = 99)]
        [TestCase("XLV", ExpectedResult = 45)]
        public int GivenCornerCaseRomanNumberal_WhenConvertFromRoman_ThenReturnDecimal(string romanNumber)
        {
            return converter.ConvertFromRoman(romanNumber);
        }

        //[TestCase("VIIII")]
        //public void GivenInvalidRomanNumberal_WhenConvertRoman_ThenThrowArgumentException(string romanNumber)
        //{
        //    Assert.Throws<ArgumentException>(() => converter.ConvertFromRoman(romanNumber));
        //}
    }
}
