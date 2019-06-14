using FluentAssertions;
using Kata.CodeWar;
using NUnit.Framework;
using System.Collections.Generic;

// https://www.codewars.com/kata/connect-four-1/train/csharp
namespace Kata.Tests
{
    [TestFixture]
    public class ConnectFourTests
    {
        private ConnectFour connectFour;

        [Test]
        public void CanCreate()
        {
            connectFour = new ConnectFour();
            connectFour.Should().NotBeNull();
        }

        [SetUp]
        public void SetUp()
        {
            CanCreate();
        }

        [Test]
        public void CanWhoIsWinner()
        {
            string winner = connectFour.WhoIsWinner(new List<string>());
            winner.Should().Be("Draw");
        }
        [Test]
        public void GivenRedWin_WhenWhoIsWinner_ThenReturnRed()
        {
            List<string> boardStatus = new List<string>()
            {
                "A_Red",
                "B_Yellow",
                "A_Red",
                "B_Yellow",
                "A_Red",
                "B_Yellow",
                "A_Red"
            };
            string winner = connectFour.WhoIsWinner(boardStatus);
            winner.Should().Be("Red");
        }

        [Test]
        public void GivenYellowWin_WhenWhoIsWinner_ThenReturnYellow()
        {
            List<string> boardStatus = new List<string>()
            {
                "A_Red",
                "B_Yellow",
                "A_Red",
                "B_Yellow",
                "A_Red",
                "B_Yellow",
                "G_Red",
                "B_Yellow"
            };
            string winner = connectFour.WhoIsWinner(boardStatus);
            winner.Should().Be("Yellow");
        }

        [Test]
        public void GivenYellowWin2_WhenWhoIsWinner_ThenReturnYellow()
        {
            List<string> boardStatus = new List<string>()
            {
                "C_Yellow",
                "E_Red",
                "G_Yellow",
                "B_Red",
                "D_Yellow",
                "B_Red",
                "B_Yellow",
                "G_Red",
                "C_Yellow",
                "C_Red",
                "D_Yellow",
                "F_Red",
                "E_Yellow",
                "A_Red",
                "A_Yellow",
                "G_Red",
                "A_Yellow",
                "F_Red",
                "F_Yellow",
                "D_Red",
                "B_Yellow",
                "E_Red",
                "D_Yellow",
                "A_Red",
                "G_Yellow",
                "D_Red",
                "D_Yellow",
                "C_Red"
            };
            string winner = connectFour.WhoIsWinner(boardStatus);
            winner.Should().Be("Yellow");
        }

        [Test]
        public void GivenRedwWin2_WhenWhoIsWinner_ThenReturnRed()
        {
            List<string> boardStatus = new List<string>()
            {
               "A_Yellow",
                "B_Red",
                "B_Yellow",
                "C_Red",
                "G_Yellow",
                "C_Red",
                "C_Yellow",
                "D_Red",
                "G_Yellow",
                "D_Red",
                "G_Yellow",
                "D_Red",
                "F_Yellow",
                "E_Red",
                "D_Yellow"
            };
            string winner = connectFour.WhoIsWinner(boardStatus);
            winner.Should().Be("Red");
        }
    }
}
