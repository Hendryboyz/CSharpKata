using System.Text;

namespace Kata.CodeWar
{
    public class RotateCipher
    {
        public string Rotate(string original)
        {
            StringBuilder result = new StringBuilder();
            foreach (char eachCharacter in original.ToCharArray())
            {
                if (char.IsLetter(eachCharacter))
                {
                    result.Append(RotateLetters(eachCharacter));
                }
                else
                {
                    result.Append(eachCharacter);
                }
            }
            return result.ToString();
        }

        private char RotateLetters(char originalCharacter)
        {
            string rotateLetters = "nopqrstuvwxyzabcdefghijklm";

            if (char.IsUpper(originalCharacter))
            {
                int letterIndex = char.ToLower(originalCharacter) - 'a';
                return char.ToUpper(rotateLetters[letterIndex]);
            }
            else
            {
                int letterIndex = originalCharacter - 'a';
                return rotateLetters[letterIndex];
            }
        }
    }
}
