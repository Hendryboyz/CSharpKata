using FluentAssertions;
using Kata.CodeWar;
using NUnit.Framework;

// https://www.codewars.com/kata/rot13-1/csharp
namespace Kata.Tests
{
    [TestFixture]
    public class RotateCipherTests
    {
        private RotateCipher cipher;

        [Test]
        public void TestCanCreate()
        {
            cipher = new RotateCipher();
            cipher.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            TestCanCreate();
        }

        [Test]
        public void CanRotate()
        {
            string result = cipher.Rotate("0");
            result.Should().Be("0");
        }

        [TestCase("0123456789", "0123456789")]
        [TestCase("!@#$%^&*()_+", "!@#$%^&*()_+")]
        public void GivenNotLetters_ThenRotate_ReturnOriginal(string original, string expected)
        {
            string result = cipher.Rotate(original);
            result.Should().Be(expected);
        }
        
        [Test]
        public void GivenOnlyLowerLetters_ThenRotate_ReturnResult()
        {
            string result = cipher.Rotate("test");
            result.Should().Be("grfg");
        }

        [Test]
        public void GivenOnlyUpperLetters_ThenRotate_ReturnResult()
        {
            string result = cipher.Rotate("TEST");
            result.Should().Be("GRFG");
        }

        [Test]
        public void GivenMixedLetters_ThenRotate_ReturnResult()
        {
            string result = cipher.Rotate("Test");
            result.Should().Be("Grfg");
        }
    }
}
