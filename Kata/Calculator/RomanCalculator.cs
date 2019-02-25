using System.Collections.Generic;
using System.Text;

namespace Kata.Calculator
{
    public class RomanCalculator
    {
        private IDictionary<char, int> _romanDecimalTable;

        public RomanCalculator()
        {
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

        public string Add(string augend, string addend)
        {
            StringBuilder result = new StringBuilder();
            int augendIndex = 0;
            int addendIndex = 0;
            while (augendIndex < augend.Length && addendIndex < addend.Length)
            {
                char augendChar = augend[augendIndex];
                char addendChar = addend[addendIndex];
                char appendChar = addendChar;

                if (_romanDecimalTable[augendChar] >= _romanDecimalTable[addendChar])
                {
                    appendChar = augendChar;
                    augendIndex++;
                }
                else
                {
                    addendIndex++;
                }
                result.Append(appendChar);
            }

            AppendRemainingRomanNotation(augend, augendIndex, result);
            AppendRemainingRomanNotation(addend, addendIndex, result);

            result.Replace("IIII", "IV");
            result.Replace("IVI", "V");
            result.Replace("IXI", "X");

            return result.ToString();
        }

        private void AppendRemainingRomanNotation(
            string romanNumberal, int notationIndex, StringBuilder result)
        {
            while (notationIndex < romanNumberal.Length)
            {
                char notation = romanNumberal[notationIndex];
                result.Append(notation);
                notationIndex++;
            }
        }
    }
}
