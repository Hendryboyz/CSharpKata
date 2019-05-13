using System.Collections;

namespace Kata.CodeWar
{
    public class OddInteger
    {
        public int Find(int[] sequence)
        {
            Hashtable countTable = new Hashtable();
            foreach (int eachInteger in sequence)
            {
                if (countTable.ContainsKey(eachInteger))
                {
                    int count = (int)countTable[eachInteger];
                    countTable[eachInteger] = count + 1;
                }
                else
                {
                    countTable.Add(eachInteger, 1);
                }
            }

            foreach (int eachKey in countTable.Keys)
            {
                int count = (int)countTable[eachKey];
                if (IsOdd(count))
                {
                    return eachKey;
                }
            }
            return 1;
        }

        private bool IsOdd(int count)
        {
            return (count & 1) == 1;
        }
    }
}
