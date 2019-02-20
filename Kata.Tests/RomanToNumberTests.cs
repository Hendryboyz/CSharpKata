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
        public void CanConvertFromRomanNumberal()
        {
            int result = converter.ConvertFromRomanNumberal("I");
            Assert.AreEqual(1, result);
        }

        [TestCase("II", ExpectedResult = 2)]
        [TestCase("X", ExpectedResult = 10)]
        [TestCase("V", ExpectedResult = 5)]
        [TestCase("VI", ExpectedResult = 6)]
        [TestCase("IV", ExpectedResult = 4)]
        [TestCase("IX", ExpectedResult = 9)]
        public int GivenRomanNumberalLessThanX_WhenConvertFromRomanNumberal_ThenReturnDecimal(string romanNumberal)
        {
            return converter.ConvertFromRomanNumberal(romanNumberal);
        }

        [TestCase("L", ExpectedResult = 50)]
        [TestCase("C", ExpectedResult = 100)]
        [TestCase("D", ExpectedResult = 500)]
        [TestCase("M", ExpectedResult = 1000)]
        public int GivenBaseRomanNumberal_WhenConvertFromRomanNumberal_ThenReturnDecimal(string romanNumberal)
        {
            return converter.ConvertFromRomanNumberal(romanNumberal);
        }

        [TestCase("XCIX", ExpectedResult = 99)]
        [TestCase("XLV", ExpectedResult = 45)]
        public int GivenCornerCaseRomanNumberal_WhenConvertFromRomanNumberal_ThenReturnDecimal(string romanNumberal)
        {
            return converter.ConvertFromRomanNumberal(romanNumberal);
        }

        [TestCase("VX")]
        [TestCase("LC")]
        [TestCase("DM")]
        public void GivenInvalidDecrementNumber_WhenConvertFromRomanNumberal_ThenThrowInvalidOperationExpcetion(string romanNumberal)
        {
            Assert.Throws<InvalidOperationException>(() => converter.ConvertFromRomanNumberal(romanNumberal));
        }

        [TestCase("IIII")]
        [TestCase("LIIII")]
        public void GivenMoreThan3DuplicateNotation_WhenConvertFromRomanNumberal_ThenThrowInvalidOperationException(string romanNumberal)
        {
            Assert.Throws<InvalidOperationException>(() => converter.ConvertFromRomanNumberal(romanNumberal));
        }

        //[TestCase("VV")]

    }
}
