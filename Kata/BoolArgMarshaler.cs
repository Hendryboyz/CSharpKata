using System.Collections.Generic;

namespace Kata
{
    public class BoolArgMarshaler : IArgMarshaler
    {
        private ArgSpec _spec;

        public BoolArgMarshaler(ArgSpec spec)
        {
            _spec = spec;
        }

        public object GetValue(IEnumerator<string> argEnumerator)
        {
            return true;
        }
    }
}