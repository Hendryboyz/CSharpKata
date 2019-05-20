using System;
using System.Linq;
using System.Text;

// https://www.codewars.com/kata/559536379512a64472000053
namespace Kata.CodeWar
{
    public class PlayPass
    {
        public string Convert(string password, int shift)
        {
            string result = CircularShiftPassword(password, shift);
            result = DownCaseOddLetter(result);
            result = string.Join("", result.Reverse());

            return result;
        }

        private string DownCaseOddLetter(string password)
        {
            StringBuilder sb = new StringBuilder();
            for (int passwordIdx = 0; passwordIdx < password.Length; passwordIdx++)
            {
                char eachCharacter = password[passwordIdx];
                if (char.IsLetter(eachCharacter) && (passwordIdx & 1) == 0)
                {
                    sb.Append(char.ToLower(eachCharacter));
                }
                else
                {
                    sb.Append(eachCharacter);
                }
            }
            return sb.ToString();
        }

        private string CircularShiftPassword(string password, int shift)
        {
            StringBuilder shiftedPassword = new StringBuilder();
            foreach (char eachCharacter in password)
            {
                if (char.IsLetter(eachCharacter))
                {
                    char result = (char)(eachCharacter + shift);
                    if (result > 'Z')
                    {
                        shiftedPassword.Append((char)(result % 'Z' + ('A' - 1)));
                    }
                    else
                    {
                        shiftedPassword.Append(result);
                    }
                }
            }
            return shiftedPassword.ToString();
        }
    }
}
