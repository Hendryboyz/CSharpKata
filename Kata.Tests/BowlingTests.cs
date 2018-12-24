using NUnit.Framework;
using System;

namespace Kata.Tests
{
    [TestFixture]
    class BowlingTests
    {
        private Bowling game;

        [SetUp]
        public void SetUp()
        {
            game = new Bowling();
            Assert.NotNull(game);
        }

        [Test]
        public void CanRoll()
        {
            game.Roll(1);
            AssertScores(1);
        }

        [Test]
        public void CanGetScores()
        {
            game.Roll(1);
            game.Roll(2);
            AssertScores(3);
        }

        [Test]
        public void Roll_GivenSpare_GetCorrectScores()
        {
            game.Roll(1);
            game.Roll(9);
            game.Roll(5);
            RollMany(17, 0);
            AssertScores(20);
        }

        private void RollMany(int rollTimes, int pins)
        {
            for (int i = 0; i < rollTimes; i++)
            {
                game.Roll(pins);
            }
        }

        private void AssertScores(int expected)
        {
            int scores = game.GetScores();
            Assert.AreEqual(expected, scores);
        }

        [Test]
        public void Roll_GivenStrike_GetCorrectScores()
        {
            game.Roll(10);
            game.Roll(3);
            game.Roll(4);
            RollMany(16, 0);
            AssertScores(24);
        }

        [Test]
        public void Roll_PerfectGame_Get300Points()
        {
            RollMany(12, 10);
            AssertScores(300);
        }

        [Test]
        public void Roll_RollMoreThan10Pins_ThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => game.Roll(11));
        }

        [Test]
        public void Roll_GivenPerfectSpare_Get150Points()
        {
            RollMany(21, 5);
            AssertScores(150);
        }

        [Test]
        public void Roll_MoreThan10InAFrame_ThrowInvalidOperationException()
        {
            game.Roll(2);
            Assert.Throws<InvalidOperationException>(() => game.Roll(9));
        }

        //[TestCase(21, 5)]
        [TestCase(20, 1)]
        [TestCase(12, 10)]
        public void Roll_MoreThan10Frames_ThrowInvalideOperationException(int rollTimes, int pins)
        {
            RollMany(rollTimes, pins);
            Assert.Throws<InvalidOperationException>(() => game.Roll(0));
        }
    }
}
