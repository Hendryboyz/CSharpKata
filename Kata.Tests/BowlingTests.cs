using NUnit.Framework;
using System;

namespace Kata.Tests
{
    [TestFixture]
    public class BowlingTests
    {
        private Bowling game;

        [SetUp]
        public void CanSetUp()
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

        private void AssertScores(int expected)
        {
            int scores = game.Scores();
            Assert.AreEqual(expected, scores);
        }

        [Test]
        public void CanGetScores()
        {
            RollMany(20, 3);
            AssertScores(60);
        }

        private void RollMany(int rollTimes, int pins)
        {
            for (int i = 0; i < rollTimes; i++)
            {
                game.Roll(pins);
            }
        }

        [Test]
        public void Roll_GivenSpare_ThenGetCorrectScores()
        {
            game.Roll(3);
            game.Roll(7);
            game.Roll(9);
            RollMany(17, 0);
            AssertScores(28);
        }

        [Test]
        public void Roll_GivenStrike_ThenGetCorrectScores()
        {
            game.Roll(10);
            game.Roll(3);
            game.Roll(6);
            RollMany(16, 0);
            AssertScores(28);
        }

        [Test]
        public void Roll_GivenPerfectGame_ThenGet300Points()
        {
            RollMany(12, 10);
            AssertScores(300);
        }

        [Test]
        public void Roll_GivenMoreThan10Pins_ThenThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => game.Roll(11));
        }

        [Test]
        public void Roll_GivenRollMoreThan10PinsInFrame_ThenThrowInvalidOperationException()
        {
            game.Roll(6);
            Assert.Throws<InvalidOperationException>(() => game.Roll(5));
        }

        [TestCase(12, 10)]
        public void Roll_GivenMoreThen10Frames_ThenThrowInvalidOperationException(int rollTimes, int pins)
        {
            RollMany(rollTimes, pins);
            Assert.Throws<InvalidOperationException>(() => game.Roll(5));
        }
    }
}
