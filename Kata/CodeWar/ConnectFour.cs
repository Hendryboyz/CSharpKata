using System;
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
            int[,] scores = new int[6, 7];
            foreach (string eachPlay in boardState)
            {
                string[] playInfo = eachPlay.Split("_");
                int column = playInfo[0][0] - 'A';
                int color = playInfo[1].Equals(RED) ? 1 : 2;
                int row = columnIndex[column];
                board[row, column] = color;

                int maxConnect = GetPreviousMaxConnection(board, scores, row, column, color);
                scores[row, column] = maxConnect + 1;
                if (4 == scores[row, column])
                {
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            Console.Write(board[i, j] + ",");
                        }
                        Console.WriteLine();
                    }
                    return board[row, column] == 1 ? RED : YELLOW;
                }

                columnIndex[column]++;
            }
            return DRAW;
        }

        private int GetPreviousMaxConnection(int[,] board, int[,] scores, int i, int j, int color)
        {
            int maxConnect = 0;
            for (int iFactor = -1; iFactor <= 1; iFactor++)
            {
                for (int jFactor = -1; jFactor <= 1; jFactor++)
                {
                    if ((iFactor == 0 && jFactor == 0) || 
                        (iFactor == 1 && jFactor == 0))
                    {
                        continue;
                    }
                    int previousConnect = GetPreviousConnection(
                        board, scores, i + iFactor, j + jFactor, color);
                    if (previousConnect > maxConnect)
                    {
                        maxConnect = previousConnect;
                    }
                }
            }
            return maxConnect;
        }

        private int GetPreviousConnection(
            int[,] board, int[,] scores, int row, int col, int color)
        {
            int previousConnect = GetConnectCount(row, col, board, scores);
            if (previousConnect > 0 && color == board[row, col])
            {
                return previousConnect;
            }
            return 0;
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
