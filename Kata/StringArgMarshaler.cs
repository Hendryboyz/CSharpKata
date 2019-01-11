using System;
using System.Collections.Generic;

namespace Kata
{
    public class StringArgMarshaler : ValueArgMarshaler
    {
        private ArgSpec _spec;

        public StringArgMarshaler(ArgSpec spec)
        {
            _spec = spec;
        }

        public override object GetValue(IEnumerator<string> argEnumerator)
        {
            if (IsContainsValue(argEnumerator))
            {
                return Convert.ToString(argEnumerator.Current);
            }
            return Convert.ToString(_spec.Default);
        }
    }
}