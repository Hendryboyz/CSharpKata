using FluentAssertions;
using Kata.CodeWar;
using NUnit.Framework;
using System;
using System.Collections.Generic;

// https://www.codewars.com/kata/is-my-friend-cheating
namespace Kata.Tests
{
    [TestFixture]
    public class RemoveNumberTests
    {
        private RemoveNumber removeNumber;

        [Test]
        public void CanCreate()
        {
            removeNumber = new RemoveNumber();
            removeNumber.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanRemove()
        {
            List<long[]> possibleRemoval = removeNumber.Remove(1);
            possibleRemoval.Should().BeEquivalentTo(new List<long[]>() {
            });
        }

        [Test]
        public void GivenLessThanOneNumber_WhenRemove_ThenThrowArgumentException()
        {
            Exception ex = Assert.Catch<ArgumentException>(() => removeNumber.Remove(0));

            ex.Should().NotBeNull();
            ex.Should().BeOfType<ArgumentException>();
        }

        [Test]
        public void GivenSimpleCase_WhenRemove_ThenReturnPossibleRemoval()
        {
            List<long[]> possibleRemoval = removeNumber.Remove(26);
            possibleRemoval.Should().BeEquivalentTo(new List<long[]>()
            {
                new long[] { 15, 21 },
                new long[] { 21, 15 }
            });
        }

        [Test]
        public void GivenHundred_WhenRemove_ThenReturnEmptyList()
        {
            List<long[]> possibleRemoval = removeNumber.Remove(100);
            possibleRemoval.Should().BeEquivalentTo(new List<long[]>()
            {
            });
        }

        [Test, MaxTime(12000)]
        public void GivenLargeNumber_WhenRemove_ThenReturnNotEmptyListInPeriodTime()
        {
            List<long[]> possibleRemoval = removeNumber.Remove(int.MaxValue);
            possibleRemoval.Should().NotBeEmpty();
        }
    }
}
