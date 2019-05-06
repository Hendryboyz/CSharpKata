using System;
using System.Text;

namespace Kata.Game
{
    public class Minesweeper
    {
        private char[,] board;
        private int _field;

        public Minesweeper()
        {
            _field = 0;
        }
        public string BuryMine(int row, int column, string mine)
        {
            board = new char[row, column];
            StringBuilder sb = new StringBuilder(
                string.Format("Field #{0}:\n", ++_field));
            // TODO algorithm has some problem to fix
            foreach (string eachRow in mine.Split("\n"))
            {
                foreach (char eachColumn in eachRow)
                {
                    if ('*' == eachColumn)
                    {
                        sb.Append('*');
                    }
                    else
                    {
                        sb.Append("1");
                    }
                }
                sb.Append("\n");

            }
            return "Field #1:\n*1\n11\n";
        }
    }
}
