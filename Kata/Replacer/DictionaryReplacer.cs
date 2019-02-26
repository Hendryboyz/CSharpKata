using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.Replacer
{
    public class DictionaryReplacer
    {
        public string Handle(string input, IDictionary<string, string> dictionary)
        {
            return HandleByCharactorArray(input, dictionary);
        }

        private string HandleByCharactorArray(string input, IDictionary<string, string> dictionary)
        {
            bool findKey = false;
            StringBuilder result = new StringBuilder();
            StringBuilder keyBuilder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                char element = input[i];
                if (element == '$')
                {
                    if (findKey)
                    {
                        string key = keyBuilder.ToString();
                        result.Append(dictionary[key]);
                    }
                    else
                    {
                        keyBuilder = new StringBuilder();
                    }
                    findKey ^= true;
                    continue;
                }

                if (findKey)
                {
                    keyBuilder.Append(element);
                }
                else
                {
                    result.Append(element);
                }
            }

            return result.ToString(); ;
        }

        private string HandlyByStringFormat(string input, IDictionary<string, string> dictionary)
        {
            foreach (KeyValuePair<string, string> element in dictionary)
            {
                string key = element.Key;
                string val = element.Value;
                input = input.Replace(string.Format("${0}$", key), val);
            }
            return input;
        }
    }
}
