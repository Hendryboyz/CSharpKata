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
            result.Should().Be("B");
        }

        [Test]
        public void GivenATOZ_WhenConvert_ThenCircularShift()
        {
            string result = playPass.Convert("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 1);
            result.Should().Be("aZyXwVuTsRqPoNmLkJiHgFeDcB");
        }

        [Test]
        public void GivenZeroToNine_WhenConvert_ThenComplementDigit()
        {
            string result = playPass.Convert("0123456789", 1);
            result.Should().Be("0123456789");
        }

        [Test]
        public void GivenPassWithSpecialCharacter_WhenConvert_ThenKeepSpecialChar()
        {
            string result = playPass.Convert("BORN IN 2015!", 1);
            result.Should().Be("!4897 Oj oSpC");
        }

        [TestCase("I LOVE YOU!!!", 1, "!!!vPz fWpM J")]
        [TestCase("MY GRANMA CAME FROM NY ON THE 23RD OF APRIL 2015", 2, "4897 NkTrC Hq fT67 GjV Pq aP OqTh gOcE CoPcTi aO")]
        public void GivenNormalCase_WhenConvert_ThenGetCorrectResult(
            string passphrases, int shifted, string expected)
        {
            string result = playPass.Convert(passphrases, shifted);
            result.Should().Be(expected);
        }
    }
}
