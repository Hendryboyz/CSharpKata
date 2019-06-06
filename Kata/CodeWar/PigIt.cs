using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.CodeWar
{
    public class PigIt
    {
        private readonly string SUFFIX = "ay";

        public string MoveAndAppend(string sentence)
        {
            List<string> words = new List<string>();
            foreach (string eachWord in sentence.Split(" "))
            {
                if (IsPunctuation(eachWord))
                {
                    words.Add(eachWord);
                }
                else
                {
                    words.Add(HandleWord(eachWord));
                }
            }
            return string.Join(" ", words);
        }

        private bool IsPunctuation(string eachWord)
        {
            return eachWord.Length == 1 && char.IsPunctuation(eachWord[0]);
        }

        private string HandleWord(string word)
        {
            StringBuilder sb = new StringBuilder(word.Substring(1));
            sb.Append(word[0]);
            sb.Append(SUFFIX);
            return sb.ToString();
        }
    }
}
