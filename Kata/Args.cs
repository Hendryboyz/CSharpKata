using System.Collections.Generic;

namespace Kata
{
    // http://codingdojo.org/kata/Args/
    // Solution : https://github.com/unclebob/rubyargs/tree/master
    public class Args
    {
        private IDictionary<string, object> results;
        private IDictionary<string, IArgMarshaler> marshalers;

        public Args()
        {

        }

        public Args(ArgSpec[] argSpecs)
        {
            results = new Dictionary<string, object>();
            marshalers = new Dictionary<string, IArgMarshaler>();
            foreach (ArgSpec spec in argSpecs)
            {
                marshalers.Add(spec.Flag, MarshalerFactory.Get(spec));
                results.Add(spec.Flag, spec.Default);
            }
        }

        public IDictionary<string, object> Parse(string args)
        {
            if (string.IsNullOrEmpty(args))
            {
                return results;
            }
            IEnumerator<string> argEnumerator = 
                new List<string>(args.Split(" ")).GetEnumerator();
            while(argEnumerator.MoveNext())
            {
                string curArg = argEnumerator.Current;
                if (IsFlag(curArg))
                {
                    string flag = curArg.Substring(1);
                    results[flag] = marshalers[flag].GetValue(argEnumerator);
                }
            }
            return results;
        }

        private bool IsFlag(string arg)
        {
            return arg.Substring(0, 1) == "-";
        }
    }
}
