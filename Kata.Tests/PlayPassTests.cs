using FluentAssertions;
using Kata.CodeWar;
using NUnit.Framework;

namespace Kata.Tests
{
    [TestFixture]
    public class PlayPassTests
    {
        private PlayPass playPass;

        [Test]
        public void CanCreate()
        {
            playPass = new PlayPass();
            playPass.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanConvert()
        {
            string result = playPass.Convert("A", 1);
            result.Should().Be("b");
        }

        [Test]
        public void GivenATOZ_WhenConvert_ThenCircularShift()
        {
            string result = playPass.Convert("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 1);
            result.Should().Be("AzYxWvUtSrQpOnMlKjIhGfEdCb");
        }
    }
}
