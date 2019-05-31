using System;
using System.Collections.Generic;

namespace Kata.CodeWar
{
    public class IntrestingNumber
    {
        public int Check(int number, List<int> awesomePhrases)
        {
            CheckNumberRange(number);


            if (number < 98)
            {
                return 0;
            }

            if (number > 99 && CheckingInteresting(number, awesomePhrases))
            {
                return 2;
            }

            for (int possibleNumber = number - 2; possibleNumber < number + 3; possibleNumber++)
            {
                if (possibleNumber != number && CheckingInteresting(possibleNumber, awesomePhrases))
                {
                    return 1;
                }
            }

            return 0;
        }

        private bool CheckingInteresting(int number, List<int> awesomePhrases)
        {
            return IsOnlyFirstDigitNotZero(number) ||
                    IsAllDigitsTheSame(number) ||
                    IsPalindrome(number) ||
                    IsIncrementingSequence(number) ||
                    IsDescrementingSequence(number) ||
                    awesomePhrases.Contains(number);
        }

        private bool IsIncrementingSequence(int number)
        {
            char[] digits = Convert.ToString(number).ToCharArray();
            
            for (int i = 0; i < digits.Length - 1; i++)
            {
                int before = digits[i] - '0';
                int after = (digits[i + 1] - '0') == 0 ? 10 : digits[i + 1] - '0';
                
                if (after - before != 1)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsDescrementingSequence(int number)
        {
            char[] digits = Convert.ToString(number).ToCharArray();
            for (int i = 0; i < digits.Length - 1 ; i++)
            {
                if (digits[i] - digits[i + 1] != 1)
                {
                    return false;
                }
            }
            return true;
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
