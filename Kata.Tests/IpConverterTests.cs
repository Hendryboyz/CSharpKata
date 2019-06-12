using FluentAssertions;
using Kata.CodeWar;
using NUnit.Framework;

namespace Kata.Tests
{
    [TestFixture]
    public class IpConverterTests
    {
        private IpConverter converter;

        [Test]
        public void CanCreate()
        {
            converter = new IpConverter();
            converter.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanConvert()
        {
            string ip = converter.Convert(0U);
            ip.Should().Be("0.0.0.0");
        }

        [TestCase(32U, "0.0.0.32")]
        [TestCase(2154959208U, "128.114.17.104")]
        [TestCase(2149583361U, "128.32.10.1")]
        public void GivenSimpleCase_WhenConvert_ThenReturnIp(uint intIp, string expected)
        {
            string ip = converter.Convert(intIp);
            ip.Should().Be(expected);
        }
    }
}
