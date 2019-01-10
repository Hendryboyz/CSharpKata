using System.Collections.Generic;

namespace Kata
{
    public class BoolArgMarshaler : IArgMarshaler
    {
        private ArgSpec _eachSpec;

        public BoolArgMarshaler(ArgSpec eachSpec)
        {
            _eachSpec = eachSpec;
        }

        public object GetValue(IEnumerator<string> argsEnumerator)
        {
            return true;
        }
    }
}