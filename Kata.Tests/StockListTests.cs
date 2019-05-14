using FluentAssertions;
using Kata.CodeWar;
using NUnit.Framework;

namespace Kata.Tests
{
    [TestFixture]
    public class StockListTests
    {
        private StockList list;

        [Test]
        public void CanCreate()
        {
            list = new StockList();
            list.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanSummary()
        {
            string summary = list.Summary(new string[] { "ABRS 1" }, new string[] { "A" });
            summary.Should().Be("(A : 1)");
        }

        [Test]
        public void GivenStockMatchCategory_WhenSummary_ThenReturnSummary()
        {
            string summary = list.Summary(
                new string[] {
                    "ABAR 200",
                    "CDXE 500",
                    "BKWR 250",
                    "BTSQ 890",
                    "DRTY 600"
                }, 
                new string[] { "A", "B", "C", "D" });
            summary.Should().Be("(A : 200) - (B : 1140) - (C : 500) - (D : 600)");
        }

        [Test]
        public void GivenStockNotMatchCategory_WhenSummary_ThenOnlySummaryKnownCategory()
        {
            string summary = list.Summary(
                new string[] {
                    "ABAR 200",
                    "CDXE 500",
                    "BKWR 250",
                    "BTSQ 890",
                    "DRTY 600"
                },
                new string[] { "A", "B"});
            summary.Should().Be("(A : 200) - (B : 1140)");
        }

        [TestCase(new string[] { "ABRS 1" }, new string[] { })]
        [TestCase(new string[] { }, new string[] { "A" })]
        public void GivenEmptyStockOrCategory_WhenSummary_ThenReturnEmptyString(
            string[] stockQuantiy,
            string[] categories)
        {
            string summary = list.Summary(stockQuantiy, categories);
            summary.Should().BeEmpty();
        }
    }
}
