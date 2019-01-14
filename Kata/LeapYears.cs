namespace Kata
{
    public class LeapYears
    {
        public bool Verify(int year)
        {
            if (year % 100 == 0)
            {
                return IsDivisibleBy4(year / 100);
            }
            return IsDivisibleBy4(year);
        }

        private bool IsDivisibleBy4(int year)
        {
            return (year & 3) == 0;
        }
    }
}
