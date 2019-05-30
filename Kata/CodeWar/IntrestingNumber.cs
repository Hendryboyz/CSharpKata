using System;
using System.Collections.Generic;

namespace Kata.CodeWar
{
    public class IntrestingNumber
    {
        public int Check(int number, List<int> awesomePhrases)
        {
            CheckNumberRange(number);
            if (number < 100)
            {
                return 0;
            }

            int isIntresting = 0;
            if (IsOnlyFirstDigitNotZero(number) ||
                IsAllDigitsTheSame(number) ||
                IsPalindrome(number) ||
                awesomePhrases.Contains(number))
            {
                isIntresting = 2;
            }

            return isIntresting;
        }

        private bool IsPalindrome(int number)
        {
            char[] digits = Convert.ToString(number).ToCharArray();
            for (int i = 0; i < digits.Length; i++)
            {
                if ((digits[digits.Length - 1 - i] - digits[i]) != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsAllDigitsTheSame(int number)
        {
            char[] digits = Convert.ToString(number).ToCharArray();
            char digit = digits[0];
            for (int i = 1; i < digits.Length; i++)
            {
                if ((digits[i] - digit) != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void CheckNumberRange(int number)
        {
            if (number <= 0 || 1000000000 <= number)
            {
                throw new ArgumentException();
            }
        }

        private bool IsOnlyFirstDigitNotZero(int number)
        {
            char[] digits = Convert.ToString(number).ToCharArray();
            int digitSum = 0;
            for (int i = 1; i < digits.Length; i++)
            {
                digitSum += (digits[i] - '0');
            }
            if (0 == digitSum)
            {
                return true;
            }
            return false;
        }
    }
}
