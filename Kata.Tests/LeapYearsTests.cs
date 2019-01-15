using NUnit.Framework;

namespace Kata.Tests
{
    [TestFixture]
    public class LeapYearsTests
    {
        private LeapYear leapYear;

        [Test]
        public void CanSetUp()
        {
            leapYear = new LeapYear();
            Assert.NotNull(leapYear);
        }

        [SetUp]
        public void SetUp()
        {
            CanSetUp();
        }

        [TestCase(400)]
        [TestCase(800)]
        [TestCase(1200)]
        [TestCase(2000)]
        public void GivenYearDivisibleBy400_WhenVerify_ThenReturnIsLeapYear(int year)
        {
            AssertLeapYear(year);
        }

        private void AssertLeapYear(int year)
        {
            bool isLeap = leapYear.Verify(year);
            Assert.IsTrue(isLeap);
        }

        [TestCase(100)]
        [TestCase(1900)]
        [TestCase(2100)]
        [TestCase(1500)]
        public void GivenYearDivisibleBy100ButNotBy400_WhenVerify_ThenReturnNotLeapYear(int year)
        {
            AssertNotLeapYear(year);
        }

        private void AssertNotLeapYear(int year)
        {
            bool isLeap = leapYear.Verify(year);
            Assert.IsFalse(isLeap);
        }

        [TestCase(1992)]
        [TestCase(2016)]
        [TestCase(2020)]
        [TestCase(1936)]
        public void GivenYearDivisibleBy4_WhenVerify_ThenReturnLeapYear(int year)
        {
            AssertLeapYear(year);
        }

        [TestCase(1949)]
        [TestCase(1919)]
        [TestCase(1995)]
        [TestCase(2019)]
        public void GienYearNotDivisibleBy4_WhenVerify_ThenReturnNotLeapYear(int year)
        {
            AssertNotLeapYear(year);
        }
    }
}
