using System;
using System.Text;

namespace Kata.FizBuz
{
    public class FizzBuzz
    {
        private INumberConverter _numberConverter;
        private StringBuilder _result = new StringBuilder();

        public FizzBuzz()
        {
            // TODO maybe introduce builder pattern will be bettern
            INumberConverter defaultConverter = new DefaultNumberConverter(_result);
            INumberConverter fizzConverter = new FizzNumberConverter(defaultConverter, _result);
            INumberConverter buzzConverter = new BuzzNumberConverter(fizzConverter, _result);
            AssignNumberConverter(buzzConverter);
        }

        public FizzBuzz(INumberConverter numberConverter)
        {
            AssignNumberConverter(numberConverter);
        }

        private void AssignNumberConverter(INumberConverter numberConverter)
        {
            _numberConverter = numberConverter;
        }

        public string Given(int number)
        {
            return _numberConverter.Convert(number);
        }
    }
}
