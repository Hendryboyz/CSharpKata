using FluentAssertions;
using Kata.CodeWar;
using NUnit.Framework;

namespace Kata.Tests
{
    [TestFixture]
    public class MoveZeroTests
    {
        private MoveZero algorithm;

        [Test]
        public void CanCreate()
        {
            algorithm = new MoveZero();
            algorithm.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanMoveToLast()
        {
            int[] result = algorithm.MoveToLast(new int[] { 0 });
            result.Should().Equal(new int[] { 0 });
        }

        [Test]
        public void GivenStartWithZero_WhenMoveToLast_ThenReturnZeroAtLast()
        {
            int[] result = algorithm.MoveToLast(new int[] { 0, 1 });
            result.Should().Equal(new int[] { 1, 0 });
        }

        [Test]
        public void GivenNormalCase_WhenMoveToLast_ThenReturnAllZeroAtLast()
        {
            int[] result = algorithm.MoveToLast(new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 });
            result.Should().Equal(new int[] { 1, 2, 1, 1, 3, 1, 0, 0, 0, 0 });
        }

        [Test]
        public void GivenContinuousZero_WhenMoveToLast_ThenReturnAllZeroAtLast()
        {
            int[] result = algorithm.MoveToLast(new int[] { 0, 0, 3 });
            result.Should().Equal(new int[] { 3, 0, 0 });
        }
    }
}
