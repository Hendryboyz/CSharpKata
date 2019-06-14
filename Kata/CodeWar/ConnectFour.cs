using System.Collections.Generic;

namespace Kata.CodeWar
{
    public class ConnectFour
    {
        private readonly string DRAW = "Draw";
        private readonly string RED = "Red";
        private readonly string YELLOW = "Yellow";

        public string WhoIsWinner(List<string> boardState)
        {
            int[,] board = new int[6, 7];
            int[] columnIndex = new int[7];
            foreach (string eachPlay in boardState)
            {
                string[] playInfo = eachPlay.Split("_");
                int column = playInfo[0][0] - 'A';
                string color = playInfo[1];
                board[columnIndex[column]++, column] = color.Equals(RED) ? 1 : 2;
            }

            int[,] scores = new int[6, 7];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    int color = board[i, j];
                    if (0 == color) continue;
                    int maxConnect = GetPreviousMaxConnection(board, scores, i, j, color);
                    scores[i, j] = maxConnect + 1;
                    if (4 == scores[i, j])
                    {
                        return board[i, j] == 1 ? RED : YELLOW;
                    }
                }
            }
            return DRAW;
        }

        private int GetPreviousMaxConnection(int[,] board, int[,] scores, int i, int j, int color)
        {
            int maxConnect = 0;
            int previousConnect = GetConnectCount(i - 1, j - 1, board, scores);
            if (previousConnect > 0 &&
                previousConnect > maxConnect &&
                color == board[i - 1, j - 1])
            {
                maxConnect = scores[i - 1, j - 1];
            }

            previousConnect = GetConnectCount(i - 1, j, board, scores);
            if (previousConnect > 0 &&
                previousConnect > maxConnect &&
                color == board[i - 1, j])
            {
                maxConnect = scores[i - 1, j];
            }

            previousConnect = GetConnectCount(i, j - 1, board, scores);
            if (previousConnect > 0 &&
                previousConnect > maxConnect &&
                color == board[i, j - 1])
            {
                maxConnect = scores[i, j - 1];
            }

            previousConnect = GetConnectCount(i - 1, j + 1, board, scores);
            if (previousConnect > 0 &&
                previousConnect > maxConnect &&
                color == board[i - 1, j + 1])
            {
                maxConnect = scores[i - 1, j + 1];
            }

            return maxConnect;
        }

        private int GetConnectCount(int row, int col, int[,] board, int[,] scores)
        {
            if (row < 0 || 6 <= row ||
                col < 0 || 7 <= col )
            {
                return 0;
            }
            return scores[row, col];
        }
    }
}
