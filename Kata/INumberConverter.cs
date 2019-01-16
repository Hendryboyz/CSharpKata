using System.Text;

namespace Kata
{
    public interface INumberConverter
    {
        StringBuilder Parse(int number);
    }
}