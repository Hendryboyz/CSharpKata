using NUnit.Framework;

namespace Kata.Tests
{
    [TestFixture]
    public class LeapYearsTests
    {
        private LeapYears leapYears;

        [SetUp]
        public void SetUp()
        {
            leapYears = new LeapYears();
            Assert.NotNull(leapYears);
        }

        [TestCase(400)]
        [TestCase(800)]
        [TestCase(1200)]
        [TestCase(1600)]
        [TestCase(2000)]
        public void GivenYearDivisibleBy400_ThenVerify_ReturnTrue(int year)
        {
            bool isLeap = leapYears.Verify(year);
            Assert.IsTrue(isLeap);
        }

        [TestCase(100)]
        [TestCase(1700)]
        [TestCase(1800)]
        [TestCase(2100)]
        [TestCase(1500)]
        public void GivenYearDivisibleBy100ButNotBy400_ThenVerify_ReturnFalse(int year)
        {
            bool isLeap = leapYears.Verify(year);
            Assert.IsFalse(isLeap);
        }

        [TestCase(1992)]
        [TestCase(4)]
        [TestCase(216)]
        [TestCase(2016)]
        [TestCase(2008)]
        [TestCase(2012)]
        public void GivenYearDivisibleBy4ButNotBy100_ThenVerify_ReturnTrue(int year)
        {
            bool isLeap = leapYears.Verify(year);
            Assert.IsTrue(isLeap);
        }

        [TestCase(5)]
        [TestCase(2019)]
        [TestCase(1995)]
        [TestCase(1949)]

        public void GivenYearNotDivisibleBy4_ThenVerify_ReturnFalse(int year)
        {
            bool isLeap = leapYears.Verify(year);
            Assert.IsFalse(isLeap);
        }
    }
}
