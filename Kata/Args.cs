using System;
using System.Collections.Generic;

namespace Kata
{
    // http://codingdojo.org/kata/Args/
    // Solution : https://github.com/unclebob/rubyargs/tree/master
    public class Args
    {
        private IDictionary<string, object> results;
        private IDictionary<string, Type> argTypes;

        public Args()
        {

        }

        public Args(ArgSpec[] argSpecs)
        {
            results = new Dictionary<string, object>();
            argTypes = new Dictionary<string, Type>();
            foreach (ArgSpec spec in argSpecs)
            {
                argTypes.Add(spec.Flag, spec.Type);
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
                    if (argTypes.ContainsKey(flag))
                    {
                        if (argTypes[flag] == typeof(bool))
                        {
                            results[flag] = true;
                        }
                        else if (argTypes[flag] == typeof(string))
                        {
                            if (IsContainsValue(argEnumerator, flag))
                            {
                                results[flag] = Convert.ToString(argEnumerator.Current);
                            }
                        }
                        else if (argTypes[flag] == typeof(int))
                        {
                            if (IsContainsValue(argEnumerator, flag))
                            {
                                results[flag] = Convert.ToInt32(argEnumerator.Current);
                            }
                        }
                    }
                }
            }
            return results;
        }

        private bool IsContainsValue(IEnumerator<string> argEnumerator, string flag)
        {
            if (argEnumerator.MoveNext() && !IsFlag(argEnumerator.Current))
            {
                return true;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private bool IsFlag(string arg)
        {
            return arg.Substring(0, 1) == "-";
        }
    }
}
