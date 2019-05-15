using FluentAssertions;
using Kata.CodeWar;
using NUnit.Framework;

// https://www.codewars.com/kata/550554fd08b86f84fe000a58
namespace Kata.Tests
{
    [TestFixture]
    public class WhichAreInTests
    {
        private WhichAreIn algorithm;

        [Test]
        public void CanCreate()
        {
            algorithm = new WhichAreIn();
            algorithm.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanCheckSubset()
        {
            string[] result = algorithm.CheckSubset(new string[] { "a" }, new string[] { "a" });
            result.Should().Contain("a");
        }

        [Test]
        public void GivenSimpleCase_WhenCheckSubset_ThenReturnElementIsSubset()
        {
            string[] result = algorithm.CheckSubset(
                new string[] { "arp", "live", "strong" }, 
                new string[] { "lively", "alive", "harp", "sharp", "armstrong" }
            );
            result.Should().Equal(new string[] { "arp", "live", "strong" });
        }

        [Test]
        public void GivenAllNotValidSubset_WhenCheckSubset_ThenReturnEmptyArray()
        {
            string[] result = algorithm.CheckSubset(
                new string[] { "marp", "clive", "tstrong" },
                new string[] { "lively", "alive", "harp", "sharp", "armstrong" }
            );
            result.Should().BeEmpty();
        }

        [Test]
        public void GivenDuplicatedSubset_WhenCheckSubset_ThenReturnThatSubsetSingleTime()
        {
            string[] result = algorithm.CheckSubset(
                new string[] { "arp", "live", "strong", "arp" },
                new string[] { "lively", "alive", "harp", "sharp", "armstrong" }
            );
            result.Should().Equal(new string[] { "arp", "live", "strong" });
        }

        [Test]
        public void GivenUnorderedSubset_WhenCheckSubset_ThenReturnOrderSubset()
        {
            string[] result = algorithm.CheckSubset(
                new string[] { "strong", "live", "arp" },
                new string[] { "lively", "alive", "harp", "sharp", "armstrong" }
            );
            result.Should().Equal(new string[] { "arp", "live", "strong" });
        }
    }
}
