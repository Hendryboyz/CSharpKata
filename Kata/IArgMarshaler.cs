using System.Collections.Generic;

namespace Kata
{
    public interface IArgMarshaler
    {
        object GetValue(IEnumerator<string> argEnumerator);
    }
}