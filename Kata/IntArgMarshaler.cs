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

        public object GetValue(IEnumerator<string> argsEnumerator)
        {
            if (argsEnumerator.MoveNext())
            {
                string valueArg = argsEnumerator.Current;
                if (!IsFlag(valueArg))
                {
                    return Convert.ToInt32(valueArg);
                }
            }
            return Convert.ToInt32(_eachSpec.Default);
        }

        private bool IsFlag(string arg)
        {
            return arg.Substring(0, 1) == "-";
        }
    }
}