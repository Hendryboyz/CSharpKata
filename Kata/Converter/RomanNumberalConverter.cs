using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Converter
{
    public class RomanNumberalConverter
    {
        private readonly int[] _decimal;
        private readonly IDictionary<int, string> _decimalRomanTable;
        private readonly IDictionary<char, int> _romanDecimalTable;

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
                { 1000, "M" }
            };
            _romanDecimalTable = new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };
        }

        #region ConvertFromDecimal
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
        #endregion

        #region ConvertFromRoman
        public int ConvertFromRoman(string romanNumberal)
        {
            int result = 0;
            Stack<int> summarizingNumbers = new Stack<int>();
            foreach (char eachNotation in romanNumberal)
            {
                int currentDecimal = _romanDecimalTable[eachNotation];
                if (!HasSummarizingNumbers(summarizingNumbers))
                {
                    summarizingNumbers.Push(currentDecimal);
                }
                else if (summarizingNumbers.Peek() == currentDecimal)
                {
                    summarizingNumbers.Push(currentDecimal);
                }
                else if (summarizingNumbers.Peek() > currentDecimal)
                {
                    result += SummarizeResult(summarizingNumbers);
                    summarizingNumbers.Push(currentDecimal);
                }
                else if (ContainLegalDecrement(summarizingNumbers))
                {
                    result += (currentDecimal - summarizingNumbers.Pop());
                }
                else
                {
                    throw new InvalidOperationException();
                }

                VerifyDuplicationNumbers(summarizingNumbers);
            }

            result += SummarizeResult(summarizingNumbers);
            return result;
        }

        private bool HasSummarizingNumbers(Stack<int> summarizingNumber)
        {
            return summarizingNumber.Count > 0;
        }

        private int SummarizeResult(Stack<int> summarizingNumbers)
        {
            int result = 0;
            while (HasSummarizingNumbers(summarizingNumbers))
            {
                result += summarizingNumbers.Pop();
            }
            return result;
        }

        private bool ContainLegalDecrement(Stack<int> summarizingNumbers)
        {
            return summarizingNumbers.Peek() == 1 || summarizingNumbers.Peek() == 10 || summarizingNumbers.Peek() == 100;
        }

        private void VerifyDuplicationNumbers(Stack<int> summarizingNumbers)
        {
            if (summarizingNumbers.Count > 3 ||
                ContainDuplicatedMiddleNumber(summarizingNumbers))
            {
                throw new InvalidOperationException();
            }
        }

        private bool ContainDuplicatedMiddleNumber(Stack<int> summarizingNumbers)
        {
            return summarizingNumbers.Count > 1 &&
                (summarizingNumbers.Peek() == 5 || summarizingNumbers.Peek() == 50 || summarizingNumbers.Peek() == 500);
        }
        #endregion
    }
}