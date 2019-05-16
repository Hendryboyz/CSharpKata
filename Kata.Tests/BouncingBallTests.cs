using FluentAssertions;
using Kata.Game;
using NUnit.Framework;

// https://www.codewars.com/kata/bouncing-balls
namespace Kata.Tests
{
    [TestFixture]
    public class BouncingBallTests
    {
        private BouncingBall game;

        [Test]
        public void CanCreate()
        {
            game = new BouncingBall();
            game.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanExpectBouncingTimes()
        {
            int times = game.ExpectBouncingTimes(3, 0.66, 1.5);
            times.Should().Be(3);
        }

        [Test]
        public void GivenBallHeight30_WhenExpectBouncingTimes_ThenReturn15()
        {
            int times = game.ExpectBouncingTimes(30, 0.66, 1.5);
            times.Should().Be(15);
        }

        [Test]
        public void GivenBallHeight3AndBounceFactorHalf_WhenExpectedBouncingTimes_ThenReturn2()
        {
            int times = game.ExpectBouncingTimes(3, 0.5, 1.5);
            times.Should().Be(2);
        }

        [TestCase(-1, 0.66, 1.5)]
        [TestCase(3, 1, 1.5)]
        [TestCase(3, 0, 1.5)]
        [TestCase(3, 0.66, 3)]
        public void GivenLackOfParameters_WhenExpectedBouncingTimes_ThenReturnMinusOne(
            double ballHeight, double bounceFactor, double windowHeight)
        {
            int times = game.ExpectBouncingTimes(ballHeight, bounceFactor, windowHeight);
            times.Should().Be(-1);
        }
    }
}
