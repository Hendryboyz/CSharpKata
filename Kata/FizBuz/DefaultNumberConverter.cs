using System.Text;

namespace Kata.FizBuz
{
    public class DefaultNumberConverter : INumberConverter
    {
        private StringBuilder _result;

        public DefaultNumberConverter(StringBuilder result)
        {
            _result = result;
        }

        public string Convert(int number)
        {
            if (_result.Length == 0)
            {
                _result.Append(number);
            }
            return _result.ToString();
        }
    }
}