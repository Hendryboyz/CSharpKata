using System;
using System.Text;

namespace Kata.Game
{
    public class Minesweeper
    {
        private readonly char LANDMINE_MARK = '*';

        private int _field;
        private int _settingRow;
        private int _rowConut;
        private int _columnCount;
        private char[,] _board;

        public Minesweeper()
        {
            _field = 0;
        }

        public int InitialBoard(int rowCount, int columnCount)
        {
            _field++;
            _settingRow = 0;
            _rowConut = rowCount;
            _columnCount = columnCount;
            _board = new char[rowCount, columnCount];
            return rowCount * columnCount;
        }

        public void BuryLandmine(string rowOfBoard)
        {
            int columnIdx = 0;
            foreach (char eachColumn in rowOfBoard)
            {
                CheckBoardStatus(columnIdx);
                _board[_settingRow, columnIdx] = eachColumn;
                columnIdx++;
            }
            _settingRow++;
        }

        private void CheckBoardStatus(int columnIdx)
        {
            if (!IsValidRow(_settingRow) || !IsValidColumn(columnIdx))
            {
                throw new InvalidOperationException();
            }
        }

        public string CheckStatus()
        {
            int[,] status = new int[_rowConut, _columnCount];
            IterateBoard((rowIdx, columnIdx) =>
            {
                if (IsLandmine(rowIdx, columnIdx))
                {
                    status[rowIdx, columnIdx] = -1;

                    IncreaseAdjacentLandmineCount(status, rowIdx + 1, columnIdx);
                    IncreaseAdjacentLandmineCount(status, rowIdx - 1, columnIdx);
                    IncreaseAdjacentLandmineCount(status, rowIdx, columnIdx + 1);
                    IncreaseAdjacentLandmineCount(status, rowIdx, columnIdx - 1);

                    IncreaseAdjacentLandmineCount(status, rowIdx + 1, columnIdx + 1);
                    IncreaseAdjacentLandmineCount(status, rowIdx - 1, columnIdx - 1);
                    IncreaseAdjacentLandmineCount(status, rowIdx + 1, columnIdx - 1);
                    IncreaseAdjacentLandmineCount(status, rowIdx - 1, columnIdx + 1);
                }
            });

            return ToStringStatus(status);
        }

        

        public void IterateBoard(Action<int, int> action)
        {
            for (int rowIdx = 0; rowIdx < _rowConut; rowIdx++)
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

        private void IncreaseAdjacentLandmineCount(int[,] status, int rowIdx, int columnIdx)
        {
            if (IsValidRow(rowIdx) && IsValidColumn(columnIdx) && !IsLandmine(rowIdx, columnIdx))
            {
                status[rowIdx, columnIdx]++;
            }
        }

        private bool IsValidRow(int rowIdx)
        {
            return 0 <= rowIdx && rowIdx < _rowConut;
        }

        private bool IsValidColumn(int columnIdx)
        {
            return 0 <= columnIdx && columnIdx < _columnCount;
        }

        private string ToStringStatus(int[,] status)
        {
            StringBuilder sb = new StringBuilder(string.Format("Field #{0}:\n", _field));
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
                bool isLastColumn = columnIdx == (_columnCount - 1);
                if (isLastColumn)
                {
                    sb.Append("\n");
                }
            });
            return sb.ToString();
        }
    }
}