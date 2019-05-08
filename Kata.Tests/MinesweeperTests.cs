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
        public void CanSetBoard()
        {
            int boardSize = game.SetBoard(2, 2);
            boardSize.Should().Be(4);
        }

        [Test]
        public void CanBuryLandmineAndCheckStatus()
        {
            game.SetBoard(2, 2);
            game.BuryLandmine("*.");
            game.BuryLandmine("..");
            string status = game.CheckStatus();
            status.Should().Be("Field #1:\n*1\n11\n");
        }

        [Test]
        public void Given4By4Mineboard_WhenCheckStatus_ThenReturnStatus()
        {
            game.SetBoard(4, 4);
            game.BuryLandmine("*...");
            game.BuryLandmine("....");
            game.BuryLandmine(".*..");
            game.BuryLandmine("....");
            string status = game.CheckStatus();
            status.Should().Be("Field #1:\n*100\n2210\n1*10\n1110\n");
        }

        [Test]
        public void Given2MineBoard_WhenCheckStatus_ThenReturnStatus()
        {
            game.SetBoard(4, 4);
            game.BuryLandmine("*...");
            game.BuryLandmine("....");
            game.BuryLandmine(".*..");
            game.BuryLandmine("....");
            string tips = game.CheckStatus();
            tips.Should().Be("Field #1:\n*100\n2210\n1*10\n1110\n");

            game.SetBoard(3, 5);
            game.BuryLandmine("**...");
            game.BuryLandmine(".....");
            game.BuryLandmine(".*...");
            tips = game.CheckStatus();
            tips.Should().Be("Field #2:\n**100\n33200\n1*100\n");
        }
    }
}
