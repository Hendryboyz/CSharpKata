using System.Text;

namespace Kata
{
    public class BuzzNumberConvertDecorator : INumberConverterDecorator
    {
        public INumberConverter Context { get; set; }

        private StringBuilder _resultBuilder;

        public BuzzNumberConvertDecorator(
            INumberConverter context, StringBuilder resultBuilder)
        {
            Context = context;
            _resultBuilder = resultBuilder;
        }

        public StringBuilder Parse(int number)
        {
            if (number % 5 == 0)
            {
                _resultBuilder.Insert(0, "Buzz");
            }
            return Context.Parse(number);
        }
    }
}
