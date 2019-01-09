using System;
using System.Collections.Generic;

namespace Kata
{
    // http://codingdojo.org/kata/Args/
    // Solution : https://github.com/unclebob/rubyargs/tree/master
    public class Args
    {
        private ArgSpec[] _argSpec;
        private IDictionary<string, IArgMarshaler> _argMarshalers;
        private IDictionary<string, object> _results;


        public Args()
        { }

        public Args(ArgSpec[] argSpec)
        {
            _argSpec = argSpec;
            _argMarshalers = new Dictionary<string, IArgMarshaler>();
            _results = new Dictionary<string, object>();
            foreach (var eachSpec in _argSpec)
            {
                _argMarshalers.Add(eachSpec.Flag, ArgMarshalerFactory.GetMarshaler(eachSpec));
                _results.Add(eachSpec.Flag, eachSpec.Default);
            }
        }

        public IDictionary<string, object> Parse(string args)
        {
            if (string.IsNullOrEmpty(args))
            {
                return _results;
            }
            IEnumerator<string> argEnumerator = new List<string>(args.Split(" ")).GetEnumerator();
            while (argEnumerator.MoveNext())
            {
                string eachArg = argEnumerator.Current;
                if (IsFlag(eachArg))
                {
                    string flag = eachArg.Substring(1);
                    _results[flag] = _argMarshalers[flag].GetValue(argEnumerator);
                }
            }
            return _results;
        }

        private bool IsFlag(string arg)
        {
            return arg.Substring(0, 1) == "-";
        }
    }
}
