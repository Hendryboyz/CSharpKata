using System.Collections.Generic;
using System.Linq;

namespace Kata.CodeWar
{
    public class WhichAreIn
    {
        public string[] CheckSubset(string[] subset, string[] stringSequence)
        {
            SortedSet<string> validSubset = new SortedSet<string>();
            foreach (string eachSub in subset)
            {
                foreach (string eachString in stringSequence)
                {
                    if (eachString.Contains(eachSub))
                    {
                        validSubset.Add(eachSub);
                        break;
                    }
                }
            }
            return validSubset.ToArray();
        }
    }
}
