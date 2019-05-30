using FluentAssertions;
using Kata.CodeWar;
using NUnit.Framework;
using System;
using System.Collections.Generic;

// https://www.codewars.com/kata/catching-car-mileage-numbers/
namespace Kata.Tests
{
    [TestFixture]
    public class IntrestingNumberTests
    {
        private IntrestingNumber intrestingNumber;

        [Test]
        public void CanCreate()
        {
            intrestingNumber = new IntrestingNumber();
            intrestingNumber.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanCheck()
        {
            int isIntresting = intrestingNumber.Check(99, new List<int>() { 1337, 256 });
            isIntresting.Should().Be(0);
        }

        [Test]
        public void GivenLessThan100Number_WhenCheck_ThenReturn0()
        {
            for (int number = 0; number < 100; number++)
            {
                int isIntresting = intrestingNumber.Check(99, new List<int>() { 99, 256 });
                isIntresting.Should().Be(0);
            }
        }

        [TestCase(0)]
        [TestCase(1000000000)]
        public void GivenOutOfRangeNumber_WhenCheck_ThenThrowArgumentException(int number)
        {
            Exception ex = Assert.Throws<ArgumentException>(() => intrestingNumber.Check(number, new List<int>()));

            ex.Should().NotBeNull();
            ex.Should().BeOfType<ArgumentException>();
        }

        [Test]
        public void GivenNumberInAwesomePhrases_WhenCheck_ThenReturn2()
        {
            int isIntresting = intrestingNumber.Check(1337, new List<int>() { 1337, 256 });
            isIntresting.Should().Be(2);
            isIntresting = intrestingNumber.Check(256, new List<int>() { 1337, 256 });
            isIntresting.Should().Be(2);
        }

        [TestCase(100)]
        [TestCase(2000)]
        [TestCase(4000000)]
        public void GivenNumberOnlyFirstDigitNotZero_WhenCheck_ThenReturn2(int number)
        {
            int isIntresting = intrestingNumber.Check(number, new List<int>());
            isIntresting.Should().Be(2);
        }

        [TestCase(111)]
        [TestCase(2222)]
        [TestCase(33333)]
        [TestCase(555555555)]
        public void GivenNumberOnlyHaveTheSameDigit_WhenCheck_ThenReturn2(int number)
        {
            int isIntresting = intrestingNumber.Check(number, new List<int>());
            isIntresting.Should().Be(2);
        }

        [TestCase(1221)]
        [TestCase(73837)]
        public void GivenPalindromeNumber_WhenCheck_ThenReturn2(int number)
        {
            int isIntresting = intrestingNumber.Check(number, new List<int>());
            isIntresting.Should().Be(2);
        }
    }
}
