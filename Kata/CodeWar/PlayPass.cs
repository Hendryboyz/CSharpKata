using System.Linq;
using System.Text;

namespace Kata.CodeWar
{
    public class PlayPass
    {
        private readonly int LETTER_COUNT = 26;

        public string Convert(string passphrase, int shift)
        {
            StringBuilder sb = new StringBuilder();
            for (int passIndex = 0; passIndex < passphrase.Length; passIndex++)
            {
                char eachCharacter = passphrase[passIndex];
                sb.Append(ConvertCharacter(shift, passIndex, eachCharacter));
            }

            return string.Join("", sb.ToString().Reverse());
        }

        private char ConvertCharacter(int shift, int position, char character)
        {
            if (char.IsLetter(character))
            {
                return ShiftCharacter(shift, position, character);
            }
            else if (char.IsDigit(character))
            {
                return ComplementDigit(character);
            }
            else
            {
                return character;
            }
        }

        private char ShiftCharacter(int shift, int position, char letter)
        {
            char shifted = (char)((letter - 'A' + shift) % LETTER_COUNT + 'A');
            int isOdd = position & 1;
            if (isOdd == 1)
            {
                return char.ToLower(shifted);
            }
            return shifted;
        }

        private char ComplementDigit(char digit)
        {
            int complementResult = '9' - digit;
            return (char)(complementResult + '0'); ;
        }
    }
}