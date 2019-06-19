using System;

namespace Kata.CodeWar
{
    public class LargeFactorials
    {
        private BigNumCalculator _calculator;

        public LargeFactorials()
        {
            _calculator = new BigNumCalculator();
        }

        public string Calculate(int n)
        {
            string factorials = "1";
            for (int i = 2; i <= n; i++)
            {
                factorials = _calculator.Multiple(factorials, Convert.ToString(i));
            }
            return factorials;
        }
    }
}
