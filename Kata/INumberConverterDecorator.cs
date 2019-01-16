namespace Kata
{
    public interface INumberConverterDecorator : INumberConverter
    {
        INumberConverter Context { get; set; }
    }
}
