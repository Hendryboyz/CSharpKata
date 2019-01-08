using System.Collections.Generic;

namespace Kata
{
    public class StringMarshaler : IMarshaler
    {
        private ArgSpec _spec;

        public StringMarshaler(ArgSpec spec)
        {
            _spec = spec;
        }

        public object GetValue(IEnumerator<string> argEnumerable)
        {
            if (argEnumerable.MoveNext())
            {
                return argEnumerable.Current;
            }
            return _spec.Default;
        }
    }
}