using System.Collections.Generic;
using System.Text;

namespace Kata.Converter
{
    public class RomanNumberalConverter
    {
        private readonly int[] DECIMAL_UNITS = new int[] { 100, 50, 10, 5, 1 };

        private readonly IDictionary<int, string> _decimalMapping;

        public RomanNumberalConverter()
        {
            _decimalMapping = new Dictionary<int, string>()
            {
                { 1, "I" },
                { 5, "V" },
                { 10, "X" },
                { 50, "L" },
                { 100, "C" }
            };
        }

        public string ConvertFromDigit(int digit)
        {
            StringBuilder _result = new StringBuilder();
            while(true)
            {
                for (int i = 0; i < DECIMAL_UNITS.Length; i++)
                {
                    int eachUnit = DECIMAL_UNITS[i];
                    if (digit >= eachUnit)
                    {
                        _result.Append(_decimalMapping[eachUnit]);
                        digit -= eachUnit;
                    }
                    else if (GetDecrementSize(digit, i, eachUnit) > 0)
                    {
                        int decrement = GetDecrement(digit, i, eachUnit);
                        _result.Append(_decimalMapping[decrement]);
                        _result.Append(_decimalMapping[eachUnit]);
                        digit -= (eachUnit - decrement);
                    }
                }
                if (digit == 0)
                {
                    break;
                }
            }
            return _result.ToString();
        }

        private int GetDecrementSize(int digit, int i, int eachUnit)
        {
            if (i < DECIMAL_UNITS.Length - 1 &&
                digit == eachUnit - DECIMAL_UNITS[i + 1] &&
                digit != DECIMAL_UNITS[i + 1])
            {
                return 1;
            }
            else if (i < DECIMAL_UNITS.Length - 2 &&
                     digit >= eachUnit - DECIMAL_UNITS[i + 2])
            {
                return 2;
            }
            return 0;
        }

        private int GetDecrement(int digit, int i, int eachUnit)
        {
            int decrementSize = GetDecrementSize(digit, i, eachUnit);

            if ((DECIMAL_UNITS[i + decrementSize] == 1 || 
                DECIMAL_UNITS[i + decrementSize] == 10))
            {

                return DECIMAL_UNITS[i + decrementSize];
            }
            else
            {
                if (eachUnit - 10 < digit)
                {
                    return 10;
                }
            }
            return 0;
        }
    }
}
