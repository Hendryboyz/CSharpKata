using NUnit.Framework;
using System;

namespace Kata.Tests
{
    [TestFixture]
    public class ArgsTests
    {
        private Args args;

        [SetUp]
        public void SetUp()
        {
            args = new Args();
            Assert.NotNull(args);
        }

        [Test]
        public void GivenBoolFlag_WhenParse_ThenReturnTrue()
        {
            string[] result = args.Parse(new string[] { "-l" });
            Assert.AreEqual(new string[] { Convert.ToString(true) }, result);
        }

        [Test]
        public void GivenFlagIntArgument_WhenParse_ThenReturnInteger()
        {
            string[] result = args.Parse(new string[] { "-p", "12314" });
            Assert.AreEqual(new string[] { "12314" }, result);
        }

        [Test]
        public void GivenFlagButNotGiveArgument_WhenParse_ThenReturnDefault()
        {
            string[] result = args.Parse(new string[] { "-p" });
            Assert.AreEqual(new string[] { "8080" }, result);
        }

        [Test]
        public void GivenTwoFlagWithArgument_WhenParse_ThenReturnValues()
        {
            string[] result = args.Parse(new string[] { "-p", "8080", "-l" });
            Assert.AreEqual(new string[] { "8080", Convert.ToString(true) }, result);
        }

        [Test]
        public void GivenThreeFlagWithArgument_WhenParse_ThenReturnValues()
        {
            string[] result = args.Parse(new string[] { "-p", "8080", "-l", "-d", "/var/usr/logs" });
            Assert.AreEqual(new string[] { "8080", Convert.ToString(true), "/var/usr/logs" }, result);
        }

    }
}
