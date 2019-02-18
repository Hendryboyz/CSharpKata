using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Converter
{
    public class RomanNumberalConverter
    {
        private readonly int[] _decimal;
        private readonly IDictionary<int, string> _decimalRomanTable;

        public RomanNumberalConverter()
        {
            _decimal = new int[] { 1000, 500, 100, 50, 10, 5, 1 };
            _decimalRomanTable = new Dictionary<int, string>()
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
            VerifyNumber(number);

            StringBuilder _result = new StringBuilder();

            for (int i = 0; i < _decimal.Length; i++)
            {
                int decimalUnit = _decimal[i];
                int decrement = GetDecrement(i);
                while (number >= decimalUnit - decrement)
                {
                    bool mustHandleByDecrement = number < decimalUnit;
                    if (mustHandleByDecrement)
                    {
                        number -= (decimalUnit - decrement);
                        _result.Append(_decimalRomanTable[decrement]);
                    }
                    else
                    {
                        number -= decimalUnit;
                    }
                    _result.Append(_decimalRomanTable[decimalUnit]);
                }
            }

            return _result.ToString();
        }

        private void VerifyNumber(int number)
        {
            if (number < 1)
            {
                throw new ArgumentException();
            }
        }

        private int GetDecrement(int i)
        {
            int decrement = 0;
            if (i + 1 < _decimal.Length)
            {
                decrement = _decimal[i + 1];
            }
            if (i + 2 < _decimal.Length && !IsValidDrement(decrement))
            {
                decrement = _decimal[i + 2];
            }

            return decrement;
        }

        private bool IsValidDrement(int decrement)
        {
            return decrement != 5 && decrement != 50 && decrement != 500;
        }
    }
}
