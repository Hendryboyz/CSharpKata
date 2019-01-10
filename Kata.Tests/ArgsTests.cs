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
            ArgSpec spec = new ArgSpec()
            {
                Flag = "l",
                Type = typeof(bool),
                Default = false
            };
            Args args = new Args(new ArgSpec[] { spec });
            Assert.NotNull(args);
        }

        [Test]
        public void GivenBoolSpecAndArg_WhenParse_ThenReturnFlagAndTrue()
        {
            ArgSpec boolSpec = GetBoolSpec("l", false);
            Args args = new Args(new ArgSpec[] { boolSpec });
            IDictionary<string, object> results = args.Parse("-l");
            AssertBoolArg(results, boolSpec.Flag, true);
        }

        private void AssertBoolArg(
            IDictionary<string, object> results, string flag, bool expected)
        {
            Assert.IsTrue(results.ContainsKey(flag));
            Assert.IsInstanceOf<bool>(results[flag]);
            Assert.IsTrue((bool)results[flag] == expected);
        }

        private ArgSpec GetBoolSpec(string flag, bool defaultValue)
        {
            return new ArgSpec()
            {
                Flag = flag,
                Type = typeof(bool),
                Default = defaultValue
            };
        }

        [Test]
        public void GivenBoolSpecWithoutArg_WhenParse_ThenReturnFlagAndFalse()
        {
            ArgSpec boolSpec = GetBoolSpec("l", false);
            Args args = new Args(new ArgSpec[] { boolSpec });
            IDictionary<string, object> results = args.Parse("");
            AssertBoolArg(results, boolSpec.Flag, false);
        }

        [Test]
        public void GivenIntSpecAndArg_WhenParse_ThenReturnFlagAndInt()
        {
            ArgSpec intSpec = GetIntSpec("p", 8080);
            Args args = new Args(new ArgSpec[] { intSpec });
            IDictionary<string, object> results = args.Parse("-p 1231");
            AssertIntArg(results, intSpec.Flag, 1231);
        }

        private void AssertIntArg(IDictionary<string, object> results, string flag, int expected)
        {
            Assert.IsTrue(results.ContainsKey(flag));
            Assert.IsInstanceOf<int>(results[flag]);
            Assert.IsTrue((int)results[flag] == expected);
        }

        private ArgSpec GetIntSpec(string flag, int defaultValue)
        {
            return new ArgSpec()
            {
                Flag = flag,
                Type = typeof(int),
                Default = defaultValue
            };
        }

        [Test]
        public void GivenStringSpecAndArg_WhenParse_ThenReturnFlagAndString()
        {
            ArgSpec stringSpec = GetStringSpec("d", "/var/log");
            Args args = new Args(new ArgSpec[] { stringSpec });
            IDictionary<string, object> results = args.Parse("-d /home/user/log");
            AssertStringArg(results, stringSpec.Flag, "/home/user/log");
        }

        private void AssertStringArg(IDictionary<string, object> results, string flag, string expected)
        {
            Assert.IsTrue(results.ContainsKey(flag));
            Assert.IsInstanceOf<string>(results[flag]);
            Assert.IsTrue((string)results[flag] == expected);
        }

        private ArgSpec GetStringSpec(string flag, string defaultValue)
        {
            return new ArgSpec()
            {
                Flag = flag,
                Type = typeof(string),
                Default = defaultValue
            };
        }

        [Test]
        public void GivenMultiSpecAndArg_WhenParse_ThenReturnFlagAndString()
        {
            ArgSpec stringSpec = GetStringSpec("d", "/var/log");
            ArgSpec intSpec = GetIntSpec("p", 8080);
            ArgSpec boolSpec = GetBoolSpec("l", false);
            Args args = new Args(new ArgSpec[] { boolSpec, intSpec, stringSpec });
            IDictionary<string, object> results = args.Parse("-p 12314 -l -d /home/user/log");
            AssertStringArg(results, stringSpec.Flag, "/home/user/log");
            AssertIntArg(results, intSpec.Flag, 12314);
            AssertBoolArg(results, boolSpec.Flag, true);
        }

        [Test]
        public void GivenNotExistingArg_WhenParse_ThenThrowInvalidOperationException()
        {
            ArgSpec stringSpec = GetStringSpec("d", "/var/log");
            ArgSpec intSpec = GetIntSpec("p", 8080);
            ArgSpec boolSpec = GetBoolSpec("l", false);
            Args args = new Args(new ArgSpec[] { boolSpec, intSpec, stringSpec });
            Assert.Throws<InvalidOperationException>(() =>args.Parse("-s hello"));
        }
    }
}
