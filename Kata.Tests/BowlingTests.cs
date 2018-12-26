using NUnit.Framework;
using System;

namespace Kata.Tests
{
    [TestFixture]
    public class BowlingTests
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

        private void AssertScores(int expected)
        {
            int scores = game.GetScores();
            Assert.AreEqual(expected, scores);
        }

        [Test]
        public void CanGetScores()
        {
            RollMany(20, 1);
            AssertScores(20);
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
            game.Roll(2);
            game.Roll(8);
            game.Roll(3);
            RollMany(17, 0);
            AssertScores(16);
        }

        [Test]
        public void Roll_GivenStrike_ThenGetCorrectScores()
        {
            game.Roll(10);
            game.Roll(1);
            game.Roll(8);
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
        public void Roll_GivenMoreThan10Pins_ThenThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => game.Roll(11));
        }

        [TestCase(1, 10)]
        [TestCase(9, 2)]
        public void Roll_GivenMoreThan10PinsInFrame_ThrowsInvalidOperationException(
            int roll1, int roll2)
        {
            game.Roll(roll1);
            Assert.Throws<InvalidOperationException>(() => game.Roll(roll2));
        }

        [TestCase(12, 10)]
        [TestCase(21, 5)]
        [TestCase(20, 1)]
        public void Roll_GivenMoreThan10Frames_ThrowsInvalidOperationException(
            int rollTimes, int pins)
        {
            RollMany(rollTimes, pins);
            Assert.Throws<InvalidOperationException>(() => game.Roll(1));
        }
    }
}
