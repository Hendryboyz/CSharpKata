using System;
using System.Collections.Generic;

namespace Kata
{
    public class IntArgMarshaler : IArgMarshaler
    {
        private ArgSpec _eachSpec;

        public IntArgMarshaler(ArgSpec eachSpec)
        {
            _eachSpec = eachSpec;
        }

        public object GetValue(IEnumerator<string> argEnumerator)
        {
            if (argEnumerator.MoveNext() && !IsFlag(argEnumerator.Current))
            {
                return Convert.ToInt32(argEnumerator.Current);
            }
            return Convert.ToInt32(_eachSpec.Default);
        }

        private bool IsFlag(string arg)
        {
            return arg.Substring(0, 1) == "-";
        }
    }
}