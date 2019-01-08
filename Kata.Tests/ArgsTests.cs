using NUnit.Framework;
using System;
using System.Collections.Generic;

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
        public void CanParse()
        {
            ArgSpec spec = new ArgSpec()
            {
                Flag = "l",
                Type = typeof(bool),
                Default = false,
            };
            IDictionary<string, object> result = args.Parse(new ArgSpec[] { spec }, "");
            Assert.IsTrue(result.ContainsKey("l"));
            Assert.IsInstanceOf<bool>(result["l"]);
            bool isLogging = (bool)result["l"];
            Assert.IsFalse(isLogging);
        }

        [Test]
        public void GivenStringAndBoolSpec_WhenParse_ResultContains()
        {
            ArgSpec boolSpec = new ArgSpec()
            {
                Flag = "l",
                Type = typeof(bool),
                Default = false,
            };
            ArgSpec stringSpec = new ArgSpec()
            {
                Flag = "d",
                Type = typeof(string),
                Default = "/var/log",
            };
            IDictionary<string, object> result = args.Parse(
                new ArgSpec[] { boolSpec, stringSpec }, "-l -d /home/me/log");
            Assert.IsTrue(result.ContainsKey("l"));
            Assert.IsInstanceOf<bool>(result["l"]);
            bool isLogging = (bool)result["l"];
            Assert.IsTrue(isLogging);
            Assert.IsTrue(result.ContainsKey("d"));
            Assert.IsInstanceOf<string>(result["d"]);
            Assert.AreEqual(result["d"], "/home/me/log");
        }

        //[Test]
        //public void GivenBooleanAndStringFlag_
    }
}
