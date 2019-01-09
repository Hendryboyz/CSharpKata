namespace Kata
{
    public class ArgMarshalerFactory
    {
        public static IArgMarshaler GetMarshaler(ArgSpec eachSpec)
        {
            if (eachSpec.Type == typeof(string))
            {
                return new StringArgMarshaler(eachSpec);
            }
            else if (eachSpec.Type == typeof(int))
            {
                return new IntArgMarshaler(eachSpec);
            }
            else if (eachSpec.Type == typeof(bool))
            {
                return new BoolArgMarshaler(eachSpec);
            }
            return null;
        }
    }
}