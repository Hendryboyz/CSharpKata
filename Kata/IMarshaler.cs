using System.Collections.Generic;

namespace Kata
{
    public interface IMarshaler
    {
        object GetValue(IEnumerator<string> argEnumerable);
    }
}