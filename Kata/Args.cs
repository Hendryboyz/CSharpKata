using System;
using System.Collections.Generic;

namespace Kata
{
    // http://codingdojo.org/kata/Args/
    // Solution : https://github.com/unclebob/rubyargs/tree/master
    public class Args
    {
        private ArgSpec[] argSpec;
        IDictionary<string, object> _results;
        IDictionary<string, IArgMarshaler> _marshalers;

        public Args()
        {

        }

        public Args(ArgSpec[] argSpec)
        {
            this.argSpec = argSpec;
            _results = new Dictionary<string, object>();
            _marshalers = new Dictionary<string, IArgMarshaler>();
            foreach (ArgSpec eachSpec in argSpec)
            {
                _marshalers.Add(eachSpec.Flag, MarshalerFactory.Get(eachSpec));
                _results.Add(eachSpec.Flag, eachSpec.Default);
            }
        }

        public IDictionary<string, object> Parse(string args)
        {
            if (string.IsNullOrEmpty(args))
            {
                return _results;
            }
            IEnumerator<string> argsEnumerator = new List<string>(args.Split(" ")).GetEnumerator();
            while(argsEnumerator.MoveNext())
            {
                ParseEachArg(argsEnumerator);
            }
            return _results;
        }

        private void ParseEachArg(IEnumerator<string> argsEnumerator)
        {
            string curArg = argsEnumerator.Current;
            if (IsFlag(curArg))
            {
                string flag = curArg.Substring(1);
                if (_marshalers.ContainsKey(flag))
                {
                    _results[flag] = _marshalers[flag].GetValue(argsEnumerator);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private bool IsFlag(string arg)
        {
            return arg.Substring(0, 1) == "-";
        }
    }
}
