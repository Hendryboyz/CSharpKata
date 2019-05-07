using System;
using System.Text;

namespace Kata.Game
{
    public class Minesweeper
    {
        private char[,] _board;
        private int _boardRowCount;
        private int _boardColumnCount;
        private int _row;
        private int _field;

        public Minesweeper()
        {
            _field = 0;
        }

        public int SetBoard(int boardRows, int boardColumn)
        {
            _field++;
            _boardRowCount = boardRows;
            _boardColumnCount = boardColumn;
            _board = new char[boardRows, boardColumn];
            _row = 0;
            return _board.Length;
        }

        public void BuryMine(string rowOfBoard)
        {
            int _col = 0;
            foreach (char point in rowOfBoard)
            {
                _board[_row, _col] = point;
                _col++;
            }
            _row++;
        }

        public string GetStatus()
        {
            StringBuilder sb = new StringBuilder(
                string.Format("Field #{0}:\n", _field));
            int[,] tips = InitialTipsBoard();
            for (int rowIdx = 0; rowIdx < _boardRowCount; rowIdx++)
            {
                for (int colIdx = 0; colIdx < _boardColumnCount; colIdx++)
                {
                    bool isMinePoint = '*' == _board[rowIdx, colIdx];
                    if (isMinePoint)
                    {
                        tips[rowIdx, colIdx] = -1;

                        IncreaseTipsBoard(tips, rowIdx + 1, colIdx);
                        IncreaseTipsBoard(tips, rowIdx - 1, colIdx);
                        IncreaseTipsBoard(tips, rowIdx, colIdx + 1);
                        IncreaseTipsBoard(tips, rowIdx, colIdx - 1);

                        IncreaseTipsBoard(tips, rowIdx + 1, colIdx + 1);
                        IncreaseTipsBoard(tips, rowIdx - 1, colIdx - 1);
                        IncreaseTipsBoard(tips, rowIdx + 1, colIdx - 1);
                        IncreaseTipsBoard(tips, rowIdx - 1, colIdx + 1);
                    }
                }
            }

            for (int rowIdx = 0; rowIdx < _boardRowCount; rowIdx++)
            {
                for (int colIdx = 0; colIdx < _boardColumnCount; colIdx++)
                {
                    bool isMine = -1 == tips[rowIdx, colIdx];
                    if (isMine)
                    {
                        sb.Append('*');
                    }
                    else
                    {
                        sb.Append(tips[rowIdx, colIdx]);
                    }
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        private int[,] InitialTipsBoard()
        {
            int[,] tips = new int[_boardRowCount, _boardColumnCount];
            for (int rowIdx = 0; rowIdx < _boardRowCount; rowIdx++)
            {
                for (int colIdx = 0; colIdx < _boardColumnCount; colIdx++)
                {
                    tips[rowIdx, colIdx] = 0;
                }
            }
            return tips;
        }

        private void IncreaseTipsBoard(int[,] tips, int rowIdx, int colIdx)
        {
            if (IsValidRowIndex(rowIdx) && IsValidColumnIndex(colIdx) &&
                tips[rowIdx, colIdx] != -1)
            {
                tips[rowIdx, colIdx]++;
            }
        }

        private bool IsValidColumnIndex(int index)
        {
            return 0 <= index && index < _boardColumnCount;
        }

        private bool IsValidRowIndex(int index)
        {
            return 0 <= index && index < _boardRowCount;
        }
    }
}
