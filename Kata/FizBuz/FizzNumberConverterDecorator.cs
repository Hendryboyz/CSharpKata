namespace Kata.FizBuz
{
    public class FizzNumberConverterDecorator : INumberConverterDecorator
    {
        public INumberConverter Context { get; set; }

        public FizzNumberConverterDecorator(INumberConverter context)
        {
            Context = context;
        }

        public string Parse(int number)
        {
            string parse = string.Empty;
            if (number % 3 == 0)
            {
                parse = "Fizz";
            }
            return Context.Parse(number) + parse;
        }
    }
}