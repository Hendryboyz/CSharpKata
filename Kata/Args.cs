using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    // http://codingdojo.org/kata/Args/
    // Solution : https://github.com/unclebob/rubyargs/tree/master
    public class Args
    {
        private IList<string> _results;
        private string[] _args;

        public Args()
        {
            _results = new List<string>();
        }

        public string[] Parse(string[] args)
        {
            _args = args;
            for (int argumentsIndex = 0; argumentsIndex < _args.Length;)
            {
                ParseFlag(argumentsIndex);
                argumentsIndex++;
            }
            return _results.ToArray();
        }

        private void ParseFlag(int argumentsIndex)
        {
            bool isFlag = _args[argumentsIndex].ElementAt(0) == '-';
            if (isFlag)
            {
                char flag = _args[argumentsIndex].ElementAt(1);
                switch (flag)
                {
                    case 'p':
                        ParseFlagWithValue(argumentsIndex, "8080");
                        break;
                    case 'l':
                        _results.Add(Convert.ToString(true));
                        break;
                    case 'd':
                        ParseFlagWithValue(argumentsIndex, "/var/logs");
                        break;
                    default:
                        _results.Add("Not Support Flag");
                        break;
                }
            }
        }

        private void ParseFlagWithValue(int argumentsIndex, string defaultValue)
        {
            if (argumentsIndex < _args.Length - 1 && _args[argumentsIndex + 1][0] != '-')
            {
                _results.Add(_args[argumentsIndex + 1]);
            }
            else
            {
                _results.Add(defaultValue);
            }
        }
    }
}
