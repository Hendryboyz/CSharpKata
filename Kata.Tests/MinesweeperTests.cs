using FluentAssertions;
using Kata.Game;
using NUnit.Framework;

namespace Kata.Tests
{
    [TestFixture]
    public class MinesweeperTests
    {
        private Minesweeper game;

        [Test]
        public void CanCreate()
        {
            game = new Minesweeper();
            game.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanBuryMine()
        {
            string boardStatus = game.BuryMine(2, 2, "*");
            boardStatus.Should().Be("Field #1:\n*1\n11\n");
        }
    }
}
