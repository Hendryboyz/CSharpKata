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
        public void GivenSpare_WhenRoll_ThenReturnCorrectScores()
        {
            game.Roll(3);
            game.Roll(7);
            game.Roll(9);
            RollMany(17, 0);
            AssertScores(28);
        }

        [Test]
        public void GivenStike_WhenRoll_ThenReturnCorrectScores()
        {
            game.Roll(10);
            game.Roll(5);
            game.Roll(3);
            RollMany(16, 0);
            AssertScores(26);
        }

        [Test]
        public void Given12Strikes_WhenRoll_ThenReturn300Points()
        {
            RollMany(12, 10);
            AssertScores(300);
        }

        [Test]
        public void GivenMoreThanPins_WhenRoll_ThrowInvalidOperationExcetpion()
        {
            Assert.Throws<InvalidOperationException>(() => game.Roll(11));
        }

        [Test]
        public void GivenMoreThanPinsInFrame_WhenRoll_ThrowInvalidOperationException()
        {
            game.Roll(2);
            Assert.Throws<InvalidOperationException>(() => game.Roll(9));
        }

        [TestCase(12, 10)]
        [TestCase(21, 5)]
        [TestCase(20, 1)]
        public void GivenMoreThan10Frames_WhenRoll_ThrowInvalidOperationException(
            int rollTimes, int pins)
        {
            RollMany(rollTimes, pins);
            Assert.Throws<InvalidOperationException>(() => game.Roll(9));
        }
    }
}
