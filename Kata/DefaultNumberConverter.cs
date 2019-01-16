using System.Text;

namespace Kata
{
    internal class DefaultNumberConverter : INumberConverter
    {
        private StringBuilder _resultBuilder;

        public DefaultNumberConverter(StringBuilder resultBuilder)
        {
            _resultBuilder = resultBuilder;
        }

        public StringBuilder Parse(int number)
        {
            if (_resultBuilder.Length == 0)
            {
                _resultBuilder.Append(number);
            }
            return _resultBuilder;
        }
    }
}