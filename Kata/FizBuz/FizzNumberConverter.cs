using System.Text;

namespace Kata.FizBuz
{
    public class FizzNumberConverter : INumberConverterDecorator
    {
        public INumberConverter Context { get; set; }

        private StringBuilder _result;

        public FizzNumberConverter(INumberConverter context, StringBuilder result)
        {
            Context = context;
            _result = result;
        }

        public string Convert(int number)
        {
            if (number % 3 == 0)
            {
                _result.Insert(0, "Fizz");
            }
            return Context.Convert(number);
        }
    }
}