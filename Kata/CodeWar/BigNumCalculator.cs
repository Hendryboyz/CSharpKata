using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CodeWar
{
    public class BigNumCalculator
    {
        public string Add(string augend, string addend)
        {
            if (addend.Length > augend.Length)
            {
                string temp = augend;
                augend = addend;
                addend = temp;
            }
            Stack<char> augendDigits = new Stack<char>(augend.ToCharArray());
            Stack<char> addendDigits = new Stack<char>(addend.ToCharArray());
            StringBuilder sum = new StringBuilder();
            int carry = 0;
            while (augendDigits.Count > 0)
            {
                int augendInt = augendDigits.Pop() - '0';
                int addendInt = 0;
                if (addendDigits.Count > 0)
                {
                    addendInt = addendDigits.Pop() - '0';
                }
                int digitSum = augendInt + addendInt + carry;
                int digit = digitSum % 10;
                carry = digitSum / 10;
                sum.Insert(0, digit);
            }
            if (carry > 0)
            {
                sum.Insert(0, carry);
            }
            return sum.ToString();
        }

        public string Multiple(string multiplicand, string multiplier)
        {
            if (multiplier.Length > multiplicand.Length)
            {
                string temp = multiplicand;
                multiplicand = multiplier;
                multiplier = temp;
            }

            StringBuilder multiple = new StringBuilder();
            int carry = 0;
            int multiplicandLastIdx = multiplicand.Length - 1;
            int multiplierInt = Convert.ToInt32(multiplier);
            for (int index = multiplicandLastIdx; index >= 0; index--)
            {
                int multiplicandDigit = multiplicand[index] - '0';
                int digitMultiple = multiplicandDigit * multiplierInt + carry;
                multiple.Insert(0, digitMultiple % 10);
                carry = digitMultiple / 10;
            }

            if (carry > 0)
            {
                multiple.Insert(0, carry);
            }
            return multiple.ToString();
        }
    }
}
