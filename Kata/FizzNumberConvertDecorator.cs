using System.Text;

namespace Kata
{
    public class FizzNumberConvertDecorator : INumberConverterDecorator
    {
        public INumberConverter Context { get; set; }

        private StringBuilder _resultBuilder;

        public FizzNumberConvertDecorator(
            INumberConverter context, StringBuilder resultBuilder)
        {
            Context = context;
            _resultBuilder = resultBuilder;
        }

        public StringBuilder Parse(int number)
        {
            if (number % 3 == 0)
            {
                _resultBuilder.Insert(0, "Fizz");
            }
            return Context.Parse(number);
        }
    }
}
