namespace Kata.FizBuz
{
    public class FizzBuzz
    {
        private INumberConverter _numberConverter;

        public FizzBuzz()
        {
            INumberConverter defaultConverter = new DefaultNumberConverter();
            INumberConverterDecorator fizzConverterDecorator = new FizzNumberConverterDecorator(defaultConverter);
            INumberConverterDecorator buzzConverterDecorator = new BuzzNumberConverterDecorator(fizzConverterDecorator);
            AssignConverter(buzzConverterDecorator);
        }

        private void AssignConverter(INumberConverter numberConverter)
        {
            _numberConverter = numberConverter;
        }

        public FizzBuzz(INumberConverter numberConverter)
        {
            AssignConverter(numberConverter);
        }

        public string Given(int number)
        {
            return _numberConverter.Parse(number);
        }
    }
}
