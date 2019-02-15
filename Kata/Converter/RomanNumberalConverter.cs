using System.Collections.Generic;
using System.Text;

namespace Kata.Converter
{
    public class RomanNumberalConverter
    {
        private readonly int[] _decimal;
        private readonly IDictionary<int, string> _decimalToRomanTable;

        public RomanNumberalConverter()
        {
            _decimal = new int[] { 1000, 500, 100, 50, 10, 5, 1 };
            _decimalToRomanTable = new Dictionary<int, string>()
            {
                { 1, "I" },
                { 5, "V" },
                { 10, "X" },
                { 50, "L" },
                { 100, "C" },
                { 500, "D" },
                { 1000, "M" },
            };
        }

        public string ConvertFromDecimal(int number)
        {
            StringBuilder _result = new StringBuilder();
            for (int i = 0; i < _decimal.Length; i++)
            {
                int baseNumber = _decimal[i];
                int decrement = GetDecrement(i);

                while (number >= baseNumber - decrement)
                {
                    if (number < baseNumber)
                    {
                        number -= baseNumber - decrement;
                        _result.Append(_decimalToRomanTable[decrement]);
                    }
                    else
                    {
                        number -= baseNumber;
                    }
                    _result.Append(_decimalToRomanTable[baseNumber]);
                }
            }
            return _result.ToString();
        }

        private int GetDecrement(int decimalIndex)
        {
            int decrement = 0;

            if (decimalIndex + 1 < _decimal.Length)
            {
                decrement = _decimal[decimalIndex + 1];
            }

            if (decimalIndex + 2 < _decimal.Length && 
                !IsValidDecrement(decimalIndex))
            {
                decrement = _decimal[decimalIndex + 2];
            }

            return decrement;
        }

        private bool IsValidDecrement(int decimalIndex)
        {
            return _decimal[decimalIndex + 1] != 5 &&
                _decimal[decimalIndex + 1] != 50 && 
                _decimal[decimalIndex + 1] != 500;
        }
    }
}
