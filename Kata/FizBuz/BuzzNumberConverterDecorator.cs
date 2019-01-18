namespace Kata.FizBuz
{
    public class BuzzNumberConverterDecorator : INumberConverterDecorator
    {
        public INumberConverter Context { get; set; }

        public BuzzNumberConverterDecorator(INumberConverter context)
        {
            Context = context;
        }

        public string Parse(int number)
        {
            string parse = string.Empty;
            if (number % 5 == 0)
            {
                parse = "Buzz";
            }
            return Context.Parse(number) + parse;
        }
    }
}