using System.Collections.Generic;

namespace Kata
{
    public class BooleanMarshaler : IMarshaler
    {
        private ArgSpec _spec;

        public BooleanMarshaler(ArgSpec spec)
        {
            _spec = spec;
        }

        public object GetValue(IEnumerator<string> argEnumerable)
        {
            return true;
        }
    }
}