using System.Collections.Generic;

namespace Kata
{
    // http://codingdojo.org/kata/Args/
    // Solution : https://github.com/unclebob/rubyargs/tree/master
    public class Args
    {
        private IDictionary<string, object> result;
        private IDictionary<string, IMarshaler> marshalers;

        public IDictionary<string, object> Parse(ArgSpec[] argSpecs, string args)
        {
            result = new Dictionary<string, object>();
            marshalers = new Dictionary<string, IMarshaler>();
            foreach (ArgSpec spec in argSpecs)
            {
                result.Add(spec.Flag, spec.Default);
                BuildMarshalers(spec);
            }
            DoParse(args);
            return result;
        }

        private void BuildMarshalers(ArgSpec spec)
        {
            if (spec.Type == typeof(bool))
            {
                marshalers.Add(spec.Flag, new BooleanMarshaler(spec));
            }
            else if (spec.Type == typeof(string))
            {
                marshalers.Add(spec.Flag, new StringMarshaler(spec));
            }
        }

        private void DoParse(string args)
        {
            if (string.IsNullOrEmpty(args))
            {
                return;
            }
            IList<string> argList = new List<string>(args.Split(" "));
            IEnumerator<string> argEnumerable = argList.GetEnumerator();
            while(argEnumerable.MoveNext())
            {
                string eachArg = argEnumerable.Current;
                bool isFlag = eachArg.Substring(0, 1) == "-";
                if (isFlag)
                {
                    result[eachArg.Substring(1)] = 
                        GetFlagValue(eachArg.Substring(1), argEnumerable);
                }
            }
        }

        private object GetFlagValue(string eachArg, IEnumerator<string> argEnumerable)
        {
            return marshalers[eachArg].GetValue(argEnumerable);
        }
    }
}
