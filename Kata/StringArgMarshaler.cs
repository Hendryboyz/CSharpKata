using System;
using System.Collections.Generic;

namespace Kata
{
    internal class StringArgMarshaler : IArgMarshaler
    {
        private ArgSpec _eachSpec;

        public StringArgMarshaler(ArgSpec eachSpec)
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
                    return valueArg;
                }
            }
            return Convert.ToString(_eachSpec.Default);
        }

        private bool IsFlag(string arg)
        {
            return arg.Substring(0, 1) == "-";
        }
    }
}