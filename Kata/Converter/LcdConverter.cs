using System;
using System.Text;

namespace Kata.Converter
{
    public class LcdConverter
    {
        private readonly string[] LCD_NUMBERS = new string[]
        {
            " _ \n| |\n|_|", // 0
            "   \n  |\n  |", // 1
            " _ \n _|\n|_ ", // 2
            " _ \n _|\n _|", // 3
            "   \n|_|\n  |", // 4
            " _ \n|_ \n _|", // 5
            "   \n|_ \n|_|", // 6
            " _ \n  |\n  |", // 7
            " _ \n|_|\n|_|", // 8
            " _ \n|_|\n _|" // 9
        };
        private StringBuilder _scaleResult;

        public string Convert(int digit, int widthScale = 1, int heightScale = 1)
        {
            if (digit < 0 || digit > 9)
            {
                throw new InvalidCastException();
            }

            if (widthScale == 1 && heightScale == 1)
            {
                return LCD_NUMBERS[digit];
            }
            else
            {
                return ScaleDigitNumber(digit, widthScale, heightScale);
            }
        }

        private string ScaleDigitNumber(int digit, int widthScale, int heightScale)
        {
            _scaleResult = new StringBuilder();
            foreach (string eachPart in SplitDigitPart(digit))
            {
                if (eachPart.Equals(" _ "))
                {
                    AppendTopLine(widthScale, eachPart.Length);
                }
                else if (eachPart.Equals("| |"))
                { }
                else if (eachPart.Equals("|_|"))
                { }
                else if (eachPart.Equals("|_ "))
                {
                    AppendLeftLine(eachPart, widthScale, heightScale);
                    AppendTopLine(widthScale, eachPart.Length);
                }
                else if (eachPart.Equals(" _|"))
                {
                    AppendRightLine(eachPart, widthScale, heightScale);
                    AppendTopLine(widthScale, eachPart.Length);
                }
                else if (eachPart.Equals("  |"))
                { }
                else if (eachPart.Equals("|  "))
                { }
            }
            return _scaleResult.ToString();
        }

        private void AppendRightLine(string eachPart, int widthScale, int heightScale)
        {
            char[] scalePart = new char[eachPart.Length * widthScale];
            for (int i = 0; i < scalePart.Length; i++)
            {
                scalePart[i] = ' ';
            }
            scalePart[scalePart.Length - 1] = '|';
            for (int i = 0; i < heightScale; i++)
            {
                AppendScalePartToResult(scalePart);
            }
        }

        private void AppendLeftLine(string eachPart, int widthScale, int heightScale)
        {
            char[] scalePart = new char[eachPart.Length * widthScale];
            for (int i = 0; i < scalePart.Length; i++)
            {
                scalePart[i] = ' ';
            }
            scalePart[0] = '|';
            for (int i = 0; i < heightScale; i++)
            {
                AppendScalePartToResult(scalePart);
            }
        }

        private void AppendTopLine(int widthScale, int unitOfPart)
        {
            char[] scalePart = new char[unitOfPart * widthScale];
            for (int i = 0; i < scalePart.Length; i++)
            {
                scalePart[i] = ' ';
            }
            for (int i = 1; i < scalePart.Length - 1; i++)
            {
                scalePart[i] = '_';
            }
            AppendScalePartToResult(scalePart);
        }

        private void AppendScalePartToResult(char[] scalePart)
        {
            _scaleResult.AppendFormat("{0}\n", new string(scalePart));
        }

        private string[] SplitDigitPart(int digit)
        {
            string digitUnit = LCD_NUMBERS[digit];
            return digitUnit.Split("\n");
        }
    }
}
