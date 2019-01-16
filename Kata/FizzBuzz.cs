using System;
using System.Text;

namespace Kata
{
    public class FizzBuzz
    {
        public string Given(int number)
        {
            StringBuilder sb = new StringBuilder();
            if (number % 3 == 0)
            {
                sb.Append("Fizz");
            }
            if (number % 5 == 0)
            {
                sb.Append("Buzz");
            }
            return sb.Length > 0 ? sb.ToString() : Convert.ToString(number);
        }
    }
}
