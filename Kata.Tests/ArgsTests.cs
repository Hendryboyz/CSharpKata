using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Kata.Tests
{
    [TestFixture]
    public class ArgsTests
    {

        [Test]
        public void CanNewArgs()
        {
            Args args = new Args();
            Assert.NotNull(args);
        }

        [Test]
        public void CanGivenArgsSpecs()
        {
            ArgSpec spec = GetBoolSpec("l", false);

            Args args = new Args(new ArgSpec[] { spec });
            Assert.NotNull(args);
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
        public void GivenBooleanSpecAndArg_WhenParse_ReturnTrue()
        {
            ArgSpec boolSpec = GetBoolSpec("l", false);
            Args args = new Args(new ArgSpec[] { boolSpec });

            IDictionary<string, object> results = args.Parse("-l");

            AssertBoolArgs(results, "l", true);
        }

        private void AssertBoolArgs(IDictionary<string, object> results, string flag, bool expected)
        {
            Assert.IsTrue(results.ContainsKey(flag));
            Assert.IsInstanceOf<bool>(results[flag]);
            Assert.IsTrue(expected == (bool)results["l"]);
        }

        [Test]
        public void GivenBooleanSpecWithoutArg_WhenParse_ReturnFalse()
        {
            ArgSpec boolSpec = GetBoolSpec("l", false);
            Args args = new Args(new ArgSpec[] { boolSpec });

            IDictionary<string, object> results = args.Parse("");

            AssertBoolArgs(results, "l", false);
        }

        [Test]
        public void GivenStringSpecAndArg_WhenParse_ReturnValue()
        {
            ArgSpec stringSpec = GetStringSpec("d", "/var/log");
            Args args = new Args(new ArgSpec[] { stringSpec });

            IDictionary<string, object> results = args.Parse("-d /home/user/log");
            AssertStringArgs(results, "d", "/home/user/log");
        }

        private void AssertStringArgs(IDictionary<string, object> results, string flag, string defaultValue)
        {
            Assert.IsTrue(results.ContainsKey(flag));
            Assert.IsInstanceOf<string>(results[flag]);
            Assert.AreEqual(defaultValue, (string)results[flag]);
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
        public void GivenMultiSpecsButNothingArg_WhenParse_ReturnDefaultValue()
        {
            ArgSpec boolSpec = GetBoolSpec("l", false);
            ArgSpec stringSpec = GetStringSpec("d", "/var/log");
            Args args = new Args(new ArgSpec[] { boolSpec, stringSpec });

            IDictionary<string, object> results = args.Parse("");
            AssertStringArgs(results, "d", "/var/log");
            AssertBoolArgs(results, "l", false);
        }

        [Test]
        public void GivenIntegerSpecAndArg_WhenParse_ReturnDefaultValue()
        {
            ArgSpec intSpec = GetIntegerSpec("p", 80);
            Args args = new Args(new ArgSpec[] { intSpec });

            IDictionary<string, object> results = args.Parse("-p 8080");

            AssertIntArgs(results, "p", 8080);
        }

        private ArgSpec GetIntegerSpec(string flag, int defaultValue)
        {
            return new ArgSpec()
            {
                Flag = flag,
                Type = typeof(int),
                Default = defaultValue
            };
        }

        private void AssertIntArgs(IDictionary<string, object> results, string flag, int defaultValue)
        {
            Assert.IsTrue(results.ContainsKey(flag));
            Assert.IsInstanceOf<int>(results[flag]);
            Assert.AreEqual(defaultValue, (int)results[flag]);
        }

        [Test]
        public void GivenAnotherIntSpecAndArg_WhenParse_ReturnDefaultValue()
        {
            ArgSpec intSpec = GetIntegerSpec("a", 18);
            Args args = new Args(new ArgSpec[] { intSpec });

            IDictionary<string, object> results = args.Parse("-a 26");

            AssertIntArgs(results, "a", 26);
        }
    }
}
