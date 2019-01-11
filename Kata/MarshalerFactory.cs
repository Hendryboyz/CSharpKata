using System;

namespace Kata
{
    public class MarshalerFactory
    {
        public static IArgMarshaler Get(ArgSpec spec)
        {
            if (spec.Type == typeof(bool))
            {
                return new BoolArgMarshaler(spec);
            }
            else if (spec.Type  == typeof(string))
            {
                return new StringArgMarshaler(spec);
            }
            else if (spec.Type == typeof(int))
            {
                return new IntArgMarshaler(spec);
            }

            return null;
        }
    }
}