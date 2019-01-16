using System.Text;

namespace Kata
{
    public class FizzBuzz
    {
        INumberConverter _numberConverter;
        private StringBuilder _resultBuilder;

        public FizzBuzz()
        {
            _resultBuilder = new StringBuilder();

            AssignNumberConverter(new DefaultNumberConverter(_resultBuilder));
        }

        public FizzBuzz(INumberConverter numberConverter)
        {
            _resultBuilder = new StringBuilder();

            AssignNumberConverter(numberConverter);
        }

        private void AssignNumberConverter(INumberConverter numberConverter)
        {
            _numberConverter = numberConverter;
            _numberConverter = new FizzNumberConvertDecorator(_numberConverter, _resultBuilder);
            _numberConverter = new BuzzNumberConvertDecorator(_numberConverter, _resultBuilder);
        }

        public string Given(int number)
        {
            _numberConverter.Parse(number);
            return _resultBuilder.ToString();
        }
    }
}
