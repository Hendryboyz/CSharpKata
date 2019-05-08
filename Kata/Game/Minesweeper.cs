using System;
using System.Text;

namespace Kata.Game
{
    public class Minesweeper
    {
        private readonly int LANDMINE_MARK = -1;

        private int _field;
        private int _rowIdx;
        private int _rowCount;
        private int _columnCount;
        private char[,] _board;

        public Minesweeper()
        {
            _field = 0;
        }

        public int SetBoard(int rowCount, int columnCount)
        {
            _field++;
            _rowCount = rowCount;
            _columnCount = columnCount;
            _rowIdx = 0;
            _board = new char[rowCount, columnCount];
            return rowCount * columnCount;
        }

        public void BuryLandmine(string rolOfLandmine)
        {
            int columnIdx = 0;
            foreach (char eachPoint in rolOfLandmine)
            {
                _board[_rowIdx, columnIdx] = eachPoint;
                columnIdx++;
            }
            _rowIdx++;
        }

        public string CheckStatus()
        {
            int[,] status = new int[_rowCount, _columnCount];

            IterateBoard((rowIndex, colIdx) => 
            {
                bool isLandmine = _board[rowIndex, colIdx].Equals('*');
                if (isLandmine)
                {
                    status[rowIndex, colIdx] = LANDMINE_MARK;
                    CountAdjacentLandmine(status, rowIndex, colIdx);
                }
            });

            StringBuilder sb = new StringBuilder(
                string.Format("Field #{0}:\n", _field));
            for (int rowIndex = 0; rowIndex < _rowCount; rowIndex++)
            {
                for (int colIdx = 0; colIdx < _columnCount; colIdx++)
                {
                    if (IsLandMine(status, rowIndex, colIdx))
                    {
                        sb.Append("*");
                    }
                    else
                    {
                        sb.Append(status[rowIndex, colIdx]);
                    }
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        public void IterateBoard(Action<int, int> action)
        {
            for (int rowIndex = 0; rowIndex < _rowCount; rowIndex++)
            {
                for (int colIdx = 0; colIdx < _columnCount; colIdx++)
                {
                    action(rowIndex, colIdx);
                }
            }
        }

        private void CountAdjacentLandmine(int[,] status, int rowIndex, int colIdx)
        {
            IncreaseLandMine(status, rowIndex + 1, colIdx);
            IncreaseLandMine(status, rowIndex - 1, colIdx);
            IncreaseLandMine(status, rowIndex, colIdx + 1);
            IncreaseLandMine(status, rowIndex, colIdx - 1);

            IncreaseLandMine(status, rowIndex + 1, colIdx + 1);
            IncreaseLandMine(status, rowIndex - 1, colIdx + 1);
            IncreaseLandMine(status, rowIndex + 1, colIdx - 1);
            IncreaseLandMine(status, rowIndex - 1, colIdx - 1);
        }

        private void IncreaseLandMine(int[,] status, int rowIndex, int colIdx)
        {
            if (IsValidRowIndex(rowIndex) && IsValidColumnIndex(colIdx) && 
                !IsLandMine(status, rowIndex, colIdx))
            {
                status[rowIndex, colIdx]++;
            }
        }

        private bool IsValidColumnIndex(int columnIndex)
        {
            return 0 <= columnIndex && columnIndex < _columnCount;
        }

        private bool IsValidRowIndex(int rowIndex)
        {
            return 0 <= rowIndex && rowIndex < _rowCount;
        }

        private bool IsLandMine(int[,] status, int rowIndex, int colIdx)
        {
            return status[rowIndex, colIdx].Equals(LANDMINE_MARK);
        }
    }
}