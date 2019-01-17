using System.Text;

namespace Kata.FizBuz
{
    public class BuzzNumberConverter : INumberConverterDecorator
    {
        public INumberConverter Context { get; set; }

        private StringBuilder _result;

        public BuzzNumberConverter(INumberConverter context, StringBuilder result)
        {
            Context = context;
            _result = result;
        }

        public string Convert(int number)
        {
            if (number % 5 == 0)
            {
                _result.Insert(0, "Buzz");
            }
            return Context.Convert(number);
        }
    }
}