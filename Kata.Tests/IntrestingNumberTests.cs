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
        private IntrestingNumber interestingNumber;

        [Test]
        public void CanCreate()
        {
            interestingNumber = new IntrestingNumber();
            interestingNumber.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanCheck()
        {
            int isinteresting = interestingNumber.Check(45, new List<int>() { 1337, 256 });
            isinteresting.Should().Be(0);
        }

        [Test]
        public void GivenLessThan100Number_WhenCheck_ThenReturn0()
        {
            for (int number = 1; number < 10; number++)
            {
                int isinteresting = interestingNumber.Check(number, new List<int>() { 99, 256 });
                isinteresting.Should().Be(0);
            }
        }

        [TestCase(0)]
        [TestCase(1000000000)]
        public void GivenOutOfRangeNumber_WhenCheck_ThenThrowArgumentException(int number)
        {
            Exception ex = Assert.Throws<ArgumentException>(() => interestingNumber.Check(number, new List<int>()));

            ex.Should().NotBeNull();
            ex.Should().BeOfType<ArgumentException>();
        }

        [Test]
        public void GivenNumberInAwesomePhrases_WhenCheck_ThenReturn2()
        {
            int isinteresting = interestingNumber.Check(1337, new List<int>() { 1337, 256 });
            isinteresting.Should().Be(2);
            isinteresting = interestingNumber.Check(256, new List<int>() { 1337, 256 });
            isinteresting.Should().Be(2);
        }

        [TestCase(100)]
        [TestCase(2000)]
        [TestCase(4000000)]
        public void GivenNumberOnlyFirstDigitNotZero_WhenCheck_ThenReturn2(int number)
        {
            int isinteresting = interestingNumber.Check(number, new List<int>());
            isinteresting.Should().Be(2);
        }

        [TestCase(111)]
        [TestCase(2222)]
        [TestCase(33333)]
        [TestCase(555555555)]
        public void GivenNumberOnlyHaveTheSameDigit_WhenCheck_ThenReturn2(int number)
        {
            int isinteresting = interestingNumber.Check(number, new List<int>());
            isinteresting.Should().Be(2);
        }

        [TestCase(1221)]
        [TestCase(73837)]
        public void GivenPalindromeNumber_WhenCheck_ThenReturn2(int number)
        {
            int isinteresting = interestingNumber.Check(number, new List<int>());
            isinteresting.Should().Be(2);
        }

        [TestCase(321)]
        [TestCase(9876)]
        [TestCase(210)]
        public void GivenDescrementingNumberSequence_WhenCheck_ThenReturn2(int number)
        {
            int isInteresting = interestingNumber.Check(number, new List<int>());
            isInteresting.Should().Be(2);
        }

        [TestCase(7890)]
        [TestCase(12345)]
        public void GivenIncrementingNumberSequence_WhenCheck_ThenReturn2(int number)
        {
            int isInteresting = interestingNumber.Check(number, new List<int>());
            isInteresting.Should().Be(2);
        }

        [Test]
        public void GivenNearInterestingNumber_WhenCheck_ThenReturn1()
        {
            int isinteresting = interestingNumber.Check(1335, new List<int>() { 1337, 256 });
            isinteresting.Should().Be(1);
            isinteresting = interestingNumber.Check(1336, new List<int>() { 1337, 256 });
            isinteresting.Should().Be(1);
        }

        [Test]
        public void GivenBorderNumber_WhenCheck_ThenReturn1()
        {
            int isinteresting = interestingNumber.Check(98, new List<int>() { 1337, 256 });
            isinteresting.Should().Be(1);
            isinteresting = interestingNumber.Check(99, new List<int>() { 1337, 256 });
            isinteresting.Should().Be(1);
        }

        [Test]
        public void GivenBorderNumber2_WhenCheck_ThenReturn1()
        {
            int isinteresting = interestingNumber.Check(120, new List<int>());
            isinteresting.Should().Be(1);
        }
    }
}
