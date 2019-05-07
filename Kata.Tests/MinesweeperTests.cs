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
        public void CanBuryMineAndGetStatus()
        {
            game.SetBoard(2, 2);
            game.BuryMine("*.");
            game.BuryMine("..");
            string tips = game.GetStatus();
            tips.Should().Be("Field #1:\n*1\n11\n");
        }

        [Test]
        public void GivenBoardSizeAndMine_WhenSetBoard_ThenReturnTips()
        {
            game.SetBoard(4, 4);
            game.BuryMine("*...");
            game.BuryMine("....");
            game.BuryMine(".*..");
            game.BuryMine("....");
            string tips = game.GetStatus();
            tips.Should().Be("Field #1:\n*100\n2210\n1*10\n1110\n");
        }

        [Test]
        public void GivenTwoBoard_WhenSetBoard_ThenReturnTwoTips()
        {
            game.SetBoard(4, 4);
            game.BuryMine("*...");
            game.BuryMine("....");
            game.BuryMine(".*..");
            game.BuryMine("....");
            string tips = game.GetStatus();
            tips.Should().Be("Field #1:\n*100\n2210\n1*10\n1110\n");

            game.SetBoard(3, 5);
            game.BuryMine("**...");
            game.BuryMine(".....");
            game.BuryMine(".*...");
            tips = game.GetStatus();
            tips.Should().Be("Field #2:\n**100\n33200\n1*100\n");
        }
    }
}
