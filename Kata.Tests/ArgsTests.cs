using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Kata.Tests
{
    [TestFixture]
    public class ArgsTests
    {
        [Test]
        public void CanCreate()
        {
            Args args = new Args();
            Assert.NotNull(args);
        }

        [Test]
        public void CanGivenSpec()
        {
            ArgSpec boolSpec = GetBoolSpec("l", false);
            Args args = new Args(new ArgSpec[] { boolSpec });
            Assert.NotNull(args);
        }

        private static ArgSpec GetBoolSpec(string flag, bool defaultVal)
        {
            return new ArgSpec()
            {
                Type = typeof(bool),
                Flag = flag,
                Default = defaultVal
            };
        }

        [Test]
        public void GivenBoolSpecAndArgs_WhenParse_ThenReturnFlagAndTrue()
        {
            ArgSpec boolSpec = GetBoolSpec("l", false);
            Args args = new Args(new ArgSpec[] { boolSpec });
            IDictionary<string, object> results = args.Parse("-l");
            AssertBool(results, boolSpec.Flag, true);
        }

        private void AssertBool(IDictionary<string, object> results, string flag, bool expected)
        {
            Assert.IsTrue(results.ContainsKey(flag));
            Assert.IsInstanceOf<bool>(results[flag]);
            Assert.IsTrue((bool)results[flag] == expected);
        }

        [Test]
        public void GivneBoolSpecWithoutArgs_WhenParse_ThenReturnFlagAndFlase()
        {
            ArgSpec boolSpec = GetBoolSpec("l", false);
            Args args = new Args(new ArgSpec[] { boolSpec });
            IDictionary<string, object> results = args.Parse("");
            AssertBool(results, boolSpec.Flag, false);
        }

        [Test]
        public void GivenStringSpecAndArgs_WhenParse_ThenReturnFlagAndStringValue()
        {
            ArgSpec stringSpec = GetStringSpec("d", "/var/log");
            Args args = new Args(new ArgSpec[] { stringSpec });
            IDictionary<string, object> results = args.Parse("-d /home/user/log");
            AssertString(results, stringSpec.Flag, "/home/user/log");
        }

        private ArgSpec GetStringSpec(string flag, string defaultVal)
        {
            return new ArgSpec()
            {
                Type = typeof(string),
                Flag = flag,
                Default = defaultVal
            };
        }

        private void AssertString(IDictionary<string, object> results, string flag, string expected)
        {
            Assert.IsTrue(results.ContainsKey(flag));
            Assert.IsInstanceOf<string>(results[flag]);
            StringAssert.Contains((string)results[flag], expected);
        }

        [Test]
        public void GivenStringSpecWithoutArgs_WhenParse_ThenReturnFlagAndDefaultValue()
        {
            ArgSpec stringSpec = GetStringSpec("d", "/var/log");
            Args args = new Args(new ArgSpec[] { stringSpec });
            IDictionary<string, object> results = args.Parse("");
            AssertString(results, stringSpec.Flag, "/var/log");
        }

        [Test]
        public void GivenStringSpecAndArgWithoutValue_WhenParse_ThenThrowArgumentException()
        {
            ArgSpec stringSpec = GetStringSpec("d", "/var/log");
            Args args = new Args(new ArgSpec[] { stringSpec });
            Assert.Throws<ArgumentException>(() => args.Parse("-d"));
        }

        [Test]
        public void GivenIntSpecAndArgs_WhenParse_ThenReturnFlagAndIntValue()
        {
            ArgSpec intSpec = GetIntSpec("p", 8080);
            Args args = new Args(new ArgSpec[] { intSpec });
            IDictionary<string, object> results = args.Parse("-p 1234");
            AssertInt(results, intSpec.Flag, 1234);
        }

        private ArgSpec GetIntSpec(string flag, int defaultVal)
        {
            return new ArgSpec()
            {
                Type = typeof(int),
                Flag = flag,
                Default = defaultVal
            };
        }

        private void AssertInt(IDictionary<string, object> results, string flag, int expected)
        {
            Assert.IsTrue(results.ContainsKey(flag));
            Assert.IsInstanceOf<int>(results[flag]);
            Assert.AreEqual((int)results[flag], expected);
        }
    }
}
