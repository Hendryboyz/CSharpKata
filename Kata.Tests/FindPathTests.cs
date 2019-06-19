using FluentAssertions;
using Kata.CodeWar;
using NUnit.Framework;

namespace Kata.Tests
{
    [TestFixture]
    public class FindPathTests
    {
        private FindPath findPath;

        [Test]
        public void CanCreate()
        {
            findPath = new FindPath();
            findPath.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void TestIsExitExisting()
        {
            string maze = "..\n" +
                          ".W";
            bool isExitExisting = findPath.IsExitExisting(maze);
            isExitExisting.Should().BeFalse();
        }

        [Test]
        public void Given4By4MazeWithExit_WhenIsExitExisting_ThenReturnTrue()
        {
            string maze = ".W\n" +
                          "..";
            bool isExitExisting = findPath.IsExitExisting(maze);
            isExitExisting.Should().BeTrue();
        }
    }
}
