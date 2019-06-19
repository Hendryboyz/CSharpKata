using System;

namespace Kata.CodeWar
{
    public class FindPath
    {
        private readonly char WALL = 'W';
        private readonly char ROAD = '.';

        public bool IsExitExisting(string maze)
        {
            char[,] mazeArray = ConvertToMazeArray(maze);
            return IsPathExisting(mazeArray, 0, 0);
        }

        private bool IsPathExisting(char[,] mazeArray, int row, int column)
        {
            int sideLength = mazeArray.GetLength(0);
            if ((row < 0 || sideLength <= row) ||
                (column < 0 || sideLength <= column))
            {
                return false;
            }
            else if (mazeArray[row, column] == WALL)
            {
                return false;
            }
            else if (row == sideLength - 1 && column == sideLength - 1)
            {
                return true;
            }
            else
            {
                if (IsPathExisting(mazeArray, row - 1, column))
                {
                    return true;
                }
                else if(IsPathExisting(mazeArray, row + 1, column))
                {
                    return true;
                }
                else if (IsPathExisting(mazeArray, row, column - 1))
                {
                    return true;
                }
                else if (IsPathExisting(mazeArray, row, column + 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private char[,] ConvertToMazeArray(string maze)
        {
            string[] rowInfo = maze.Split("\n");
            int rowCount = rowInfo.Length;
            int colCount = rowInfo[0].Length;
            char[,] mazeInfo = new char[rowCount, colCount];
            for (int rowIdx = 0; rowIdx < rowCount; rowIdx++)
            {
                for (int colIdx = 0; colIdx < colCount; colIdx++)
                {
                    mazeInfo[rowIdx, colIdx] = rowInfo[rowIdx][colIdx];
                }
            }
            return mazeInfo;
        }
    }
}
