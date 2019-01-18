using System;

namespace Kata.FizBuz
{
    public class DefaultNumberConverter : INumberConverter
    {
        public string Parse(int number)
        {
            if (number % 3 == 0 || number % 5 == 0)
            {
                return string.Empty;
            }
            return Convert.ToString(number);
        }
    }
}