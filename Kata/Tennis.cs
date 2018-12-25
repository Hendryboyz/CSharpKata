using System;

namespace Kata
{
    // http://codingdojo.org/kata/Tennis/
    public class Tennis
    {
        private readonly string[] POINTS_DESCRIPTION =
            new string[] { "Love", "Fifteen", "Thirty", "Forty" };
        private int[] pointsBoard = new int[2];

        public int Winner { get; private set; }

        public string Scores()
        {
            if (Winner != 0)
            {
                return string.Format("Winner : Player{0}", Winner);
            }
            bool isDeuceGame = pointsBoard[0] >= 3 && pointsBoard[1] >= 3;
            if (isDeuceGame)
            {
                return DeuceScoring();
            }
            else
            {
                return NormalScoring();
            }
        }

        private string DeuceScoring()
        {
            if (pointsBoard[0] > pointsBoard[1])
            {
                return "Player1 Adv";
            }
            else if (pointsBoard[0] < pointsBoard[1])
            {
                return "Player2 Adv";
            }
            return "Deuce";
        }

        private string NormalScoring()
        {
            int advantage = pointsBoard[0] > pointsBoard[1] ? 0 : 1;
            int another = advantage ^ 1;
            int advantagePoints = pointsBoard[advantage];
            int anotherPoints = pointsBoard[another];
            if (advantagePoints == anotherPoints)
            {
                return string.Format("{0} All", POINTS_DESCRIPTION[pointsBoard[0]]);
            }
            else
            {
                return string.Format("{0} {1}",
                    POINTS_DESCRIPTION[advantagePoints],
                    POINTS_DESCRIPTION[anotherPoints]);
            }
        }

        public void GetPoints(int player)
        {
            int playerIndex = player - 1;
            pointsBoard[playerIndex]++;
            CheckWinner(player);
        }

        private void CheckWinner(int player)
        {
            int playerIndex = player - 1;
            int anotherPlayer = playerIndex ^ 1;
            if (pointsBoard[playerIndex] >= 4 &&
                Math.Abs(pointsBoard[playerIndex] - pointsBoard[anotherPlayer]) >= 2)
            {
                Winner = player;
            }
        }
    }
}
