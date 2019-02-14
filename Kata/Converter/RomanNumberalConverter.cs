using System.Collections.Generic;
using System.Text;

namespace Kata.Converter
{
    public class RomanNumberalConverter
    {
        private readonly int[] _decimalNumber;
        private readonly IDictionary<int, string> _romanNumberalsTable;

        public RomanNumberalConverter()
        {
            _decimalNumber = new int[] { 10, 5, 1 };
            _romanNumberalsTable = new Dictionary<int, string>()
            {
                { 1, "I" },
                { 5, "V" },
                { 10, "X" }
            };
        }

        public string Convert(int number)
        {
            StringBuilder _result = new StringBuilder();
            for (int i = 0; i < _decimalNumber.Length; i++)
            {
                int baseNumber = _decimalNumber[i];
                int decrement = GetDecrement(i);

                while (number >= baseNumber - decrement)
                {
                    if (number < baseNumber)
                    {
                        number -= baseNumber - decrement;
                        _result.Append(_romanNumberalsTable[decrement]);
                    }
                    else
                    {
                        number -= baseNumber;
                    }
                    _result.Append(_romanNumberalsTable[baseNumber]);

                }
            }
            return _result.ToString();
        }

        private int GetDecrement(int i)
        {
            int decrement = 0;
            if (i + 1 < _decimalNumber.Length)
            {
                decrement = _decimalNumber[i + 1];
            }

            if (IsInvalidDecrement(decrement))
            {
                if (i + 2 < _decimalNumber.Length)
                {
                    decrement = _decimalNumber[i + 2];
                }
            }
            return decrement;
        }

        private bool IsInvalidDecrement(int decrement)
        {
            return decrement == 5;
        }
    }
}
