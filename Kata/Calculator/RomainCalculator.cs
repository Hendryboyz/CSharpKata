using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Kata.Calculator
{
    public class RomainCalculator
    {
        private readonly IDictionary<string, string> romanNumberGroup;

        public RomainCalculator()
        {
            romanNumberGroup = new Dictionary<string, string>
            {
                { "IIII", "IV" },
                { "IVI", "V" },
            };
        }

        public string Add(string augend, string addend)
        {
            StringBuilder summary = new StringBuilder(augend);
            foreach (char romanDigit in addend)
            {
                summary.Append(romanDigit);
                if (romanNumberGroup.ContainsKey(summary.ToString()))
                {
                    summary.Replace(summary.ToString(), romanNumberGroup[summary.ToString()]);
                }
            }
            return summary.ToString();
        }
    }
}
