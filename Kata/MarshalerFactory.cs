namespace Kata
{
    public class MarshalerFactory
    {
        public static IArgMarshaler Get(ArgSpec eachSpec)
        {
            if (typeof(bool) == eachSpec.Type)
            {
                return new BoolArgMarshaler(eachSpec);
            }
            else if (typeof(int) == eachSpec.Type)
            {
                return new IntArgMarshaler(eachSpec);
            }
            else if (typeof(string) == eachSpec.Type)
            {
                return new StringArgMarshaler(eachSpec);
            }
            else
            {
                return null;
            }
        }
    }
}