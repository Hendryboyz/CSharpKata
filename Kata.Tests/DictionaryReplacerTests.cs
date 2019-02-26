using Kata.Replacer;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Kata.Tests
{
    [TestFixture]
    public class DictionaryReplacerTests
    {
        private DictionaryReplacer replacer;

        [Test]
        public void CanCreate()
        {
            replacer = new DictionaryReplacer();
            Assert.NotNull(replacer);
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanHandle()
        {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            string input = string.Empty;
            string result = replacer.Handle(input, dictionary);
            Assert.AreEqual("", result);
        }

        [TestCase("$greeting$ world", new string[] { "greeting,hello" }, ExpectedResult = "hello world")]
        [TestCase("$greeting$ $target$", new string[] {
            "greeting,hello", "target,world"
        }, ExpectedResult = "hello world")]
        public string GivenInputStringAndDictionary_WhenHandle_ReturnStringAfterReplacing(
            string input, string[] cvsDictionary)
        {
            IDictionary<string, string> dictionary = ConvertToDictionary(cvsDictionary);
            return replacer.Handle(input, dictionary);
        }

        [TestCase("$greeting$ greeting world", new string[] {
            "greeting,hello"
        }, ExpectedResult = "hello greeting world")]
        public string GivenInputContainKeyShouldNotReplcae_WhenHandle_ReturnStringAfterReplcaing(
            string input, string[] cvsDictionary)
        {
            IDictionary<string, string> dictionary = ConvertToDictionary(cvsDictionary);
            return replacer.Handle(input, dictionary);
        }

    private IDictionary<string, string> ConvertToDictionary(string[] cvsDictionary)
        {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (string eachCvs in cvsDictionary)
            {
                string[] splittedCvs = eachCvs.Split(",");
                dictionary.Add(splittedCvs[0], splittedCvs[1]);
            }
            return dictionary;
        }
    }
}
