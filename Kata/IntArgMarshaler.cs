using System;
using System.Collections.Generic;

namespace Kata
{
    public class IntArgMarshaler : ValueArgMarshaler
    {
        private ArgSpec _spec;

        public IntArgMarshaler(ArgSpec spec)
        {
            _spec = spec;
        }

        public override object GetValue(IEnumerator<string> argEnumerator)
        {
            if (IsContainsValue(argEnumerator))
            {
                return Convert.ToInt32(argEnumerator.Current);
            }
            return Convert.ToInt32(_spec.Default);
        }
    }
}