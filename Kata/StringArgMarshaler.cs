using System.Collections.Generic;

namespace Kata
{
    public class StringArgMarshaler : IArgMarshaler
    {
        private ArgSpec _eachSpec;

        public StringArgMarshaler(ArgSpec eachSpec)
        {
            _eachSpec = eachSpec;
        }

        public object GetValue(IEnumerator<string> argEnumerator)
        {
            if (argEnumerator.MoveNext() && !IsFlag(argEnumerator.Current))
            {
                return argEnumerator.Current;
            }
            return _eachSpec.Default;
        }

        private bool IsFlag(string arg)
        {
            return arg.Substring(0, 1) == "-";
        }
    }
}