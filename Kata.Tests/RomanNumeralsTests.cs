﻿using Kata.Converter;
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
        public void CanConvertFromDecimal()
        {
            string romanNumber = converter.ConvertFromDecimal(1);
            Assert.AreEqual("I", romanNumber);
        }

        [TestCase(2, ExpectedResult = "II")]
        [TestCase(5, ExpectedResult = "V")]
        [TestCase(10, ExpectedResult = "X")]
        [TestCase(6, ExpectedResult = "VI")]
        [TestCase(4, ExpectedResult = "IV")]
        [TestCase(9, ExpectedResult = "IX")]
        public string GivenNumberLessEqual10_WhenConvertFromDecimal_ThenReturnRomanNumberal(int number)
        {
            return converter.ConvertFromDecimal(number);
        }

        [TestCase(50, ExpectedResult = "L")]
        [TestCase(100, ExpectedResult = "C")]
        [TestCase(500, ExpectedResult = "D")]
        [TestCase(1000, ExpectedResult = "M")]
        public string GivenAllBaseNumber_WhenConvertFromDecimal_ThenReturnRomanNumberal(int number)
        {
            return converter.ConvertFromDecimal(number);
        }

        [TestCase(99, ExpectedResult = "XCIX")]
        [TestCase(45, ExpectedResult = "XLV")]
        public string GivenSpecialNumber_WhenConvertFromDecimal_ThenReturnRomanNumberal(int number)
        {
            return converter.ConvertFromDecimal(number);
        }
    }
}
