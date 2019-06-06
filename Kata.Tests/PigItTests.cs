using FluentAssertions;
using Kata.CodeWar;
using NUnit.Framework;

namespace Kata.Tests
{
    [TestFixture]
    public class PigItTests
    {
        private PigIt algorithm;

        [Test]
        public void CanCreate()
        {
            algorithm = new PigIt();
            algorithm.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanMoveAndAppend()
        {
            string result = algorithm.MoveAndAppend("it");
            result.Should().Be("tiay");
        }

        [TestCase("Pig", "igPay")]
        [TestCase("happy", "appyhay")]
        public void GivenSingleWord_WhenMoveAndAppend_ThenMoveFirstToLastNAppenday(string word, string expected)
        {
            string result = algorithm.MoveAndAppend(word);
            result.Should().Be(expected);
        }

        [TestCase("Pig latin is cool", "igPay atinlay siay oolcay")]
        [TestCase("This is my string", "hisTay siay ymay tringsay")]
        public void GivenSentence_WhenMoveAndAppend_ThenAllWordMoveFirstToLast(string sentence, string expected)
        {
            string result = algorithm.MoveAndAppend(sentence);
            result.Should().Be(expected);
        }

        [TestCase("Hello world !", "elloHay orldway !")]
        public void GivenSentenceContainpunctuation_WhenMoveAndAppend_ThenAllWordMoveFirstToLast(
            string sentence, string expected)
        {
            string result = algorithm.MoveAndAppend(sentence);
            result.Should().Be(expected);
        }
    }
}
