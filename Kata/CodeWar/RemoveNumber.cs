using System;
using System.Collections.Generic;

namespace Kata.CodeWar
{
    public class RemoveNumber
    {
        public List<long[]> Remove(long number)
        {
            List<long[]> possibleRemoval = new List<long[]>();
            ValidateArgument(number);
            long sum = (number + 1) * number / 2;
            for (long i = 1; i <= number; i++)
            {
                for (long j = 1; j <= number; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    if (i * j == (sum - i - j))
                    {
                        possibleRemoval.Add(new long[] { i, j });
                    }
                }
            }
            return possibleRemoval;
        }

        private void ValidateArgument(long number)
        {
            if (number < 1)
            {
                throw new ArgumentException();
            }
        }
    }
}
