namespace Kata.FizBuz
{
    public interface INumberConverterDecorator : INumberConverter
    {
        INumberConverter Context { get; set; }
    }
}
