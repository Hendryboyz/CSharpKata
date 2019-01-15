namespace Kata
{
    // http://codingdojo.org/kata/LeapYears/
    public class LeapYear
    {
        public bool Verify(int year)
        {
            bool isDivisibleBy100 = year % 100 == 0;
            if (isDivisibleBy100)
            {
                return IsDivisibleBy400(year);
            }
            return IsDivisibleBy4(year);
        }

        private bool IsDivisibleBy400(int year)
        {
            return IsDivisibleBy4(year / 100);
        }

        private bool IsDivisibleBy4(int year)
        {
            return (year & 3) == 0;
        }
    }
}
