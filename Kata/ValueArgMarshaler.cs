using System;
using System.Collections.Generic;

namespace Kata
{
    public abstract class ValueArgMarshaler : IArgMarshaler
    {
        public abstract object GetValue(IEnumerator<string> argEnumerator);

        protected bool IsContainsValue(IEnumerator<string> argEnumerator)
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

        protected bool IsFlag(string arg)
        {
            return arg.Substring(0, 1) == "-";
        }
    }
}