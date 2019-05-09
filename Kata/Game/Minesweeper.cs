using System;
using System.Text;

namespace Kata.Game
{
    public class Minesweeper
    {
        private readonly char LANDMINE_MARK = '*';

        private int _field;
        private int _rowIdx;
        private int _rowCount;
        private int _columnCount;

        private char[,] _board;

        public Minesweeper()
        {
            _field = 0;
        }

        public int InitialBoard(int rowCount, int columnCount)
        {
            _rowCount = rowCount;
            _columnCount = columnCount;
            _field++;
            _rowIdx = 0;
            _board = new char[rowCount, columnCount];
            return rowCount * columnCount;
        }

        public void BuryLandmine(string rowOfBoard)
        {
            int columnIdx = 0;
            foreach (char eachColumn in rowOfBoard)
            {
                _board[_rowIdx, columnIdx] = eachColumn;
                columnIdx++;
            }
            _rowIdx++;
        }

        public string CheckStatus()
        {
            int[,] status = new int[_rowCount, _columnCount];
            IterateBoard((rowIdx, columnIdx) =>
            {
                if (IsLandmine(rowIdx, columnIdx))
                {
                    status[rowIdx, columnIdx] = -1;

                    IncreaseAdjacentLandmineCount(status, rowIdx + 1, columnIdx);
                    IncreaseAdjacentLandmineCount(status, rowIdx - 1, columnIdx);
                    IncreaseAdjacentLandmineCount(status, rowIdx, columnIdx + 1);
                    IncreaseAdjacentLandmineCount(status, rowIdx, columnIdx - 1);

                    IncreaseAdjacentLandmineCount(status, rowIdx - 1, columnIdx - 1);
                    IncreaseAdjacentLandmineCount(status, rowIdx + 1, columnIdx + 1);
                    IncreaseAdjacentLandmineCount(status, rowIdx - 1, columnIdx + 1);
                    IncreaseAdjacentLandmineCount(status, rowIdx + 1, columnIdx - 1);
                }
            });
            return ConvertToString(status);
        }

        public void IterateBoard(Action<int, int> action)
        {
            for (int rowIdx = 0; rowIdx < _rowCount; rowIdx++)
            {
                for (int columnIdx = 0; columnIdx < _columnCount; columnIdx++)
                {
                    action(rowIdx, columnIdx);
                }
            }
        }

        private bool IsLandmine(int rowIdx, int columnIdx)
        {
            return _board[rowIdx, columnIdx].Equals(LANDMINE_MARK);
        }

        private void IncreaseAdjacentLandmineCount(int[,] status, int rowIndex, int columnIdx)
        {
            if (IsValidRowIndex(rowIndex) &&
                IsValidColumnIndex(columnIdx) &&
                !IsLandmine(rowIndex, columnIdx))
            {
                status[rowIndex, columnIdx] += 1;
            }
        }

        private bool IsValidRowIndex(int rowIndex)
        {
            return 0 <= rowIndex && rowIndex < _rowCount;
        }

        private bool IsValidColumnIndex(int columnIndex)
        {
            return 0 <= columnIndex && columnIndex < _columnCount;
        }

        private string ConvertToString(int[,] status)
        {
            StringBuilder sb = new StringBuilder(
                            string.Format("Field #{0}:\n", _field));
            IterateBoard((rowIdx, columnIdx) =>
            {
                if (IsLandmine(rowIdx, columnIdx))
                {
                    sb.Append(LANDMINE_MARK);
                }
                else
                {
                    sb.Append(status[rowIdx, columnIdx]);
                }
                bool isLastColumn = columnIdx == _columnCount - 1;
                if (isLastColumn)
                {
                    sb.Append("\n");
                }
            });
            return sb.ToString();
        }
    }
}