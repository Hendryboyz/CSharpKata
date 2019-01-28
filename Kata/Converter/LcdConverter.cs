namespace Kata.Converter
{
    public class LcdConverter
    {
        private readonly string[] lcdNumbers = new string[] 
        {
            " _ \n| |\n|_|",
            "   \n  |\n  |",
            " _ \n _|\n|_ ",
            " _ \n _|\n _|",
            "   \n|_|\n  |",
            " _ \n|_ \n _|",
            "   \n|_ \n|_|",
            " _ \n  |\n  |",
            " _ \n|_|\n|_|",
            " _ \n|_|\n _|"
        };
        public string Convert(int digit, int widthScale = 1, int heightScale = 1)
        {
            return lcdNumbers[digit];
        }
    }
}
