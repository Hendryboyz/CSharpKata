using System;
using System.Text;

namespace Kata.Converter
{
    public class LcdConverter
    {
        private readonly string[] LCD_NUMBERS = new string[]
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
        private StringBuilder _scaledResult;

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
                return ScaleLcdNumber(digit, widthScale, heightScale);
            }
        }

        private string ScaleLcdNumber(int digit, int widthScale, int heightScale)
        {
            _scaledResult = new StringBuilder();
            foreach (string eachPart in GetLcdNumberParts(digit))
            {
                if (eachPart.Equals(" _ "))
                {
                    AppendScaledUnderLine(widthScale, eachPart);
                }
                else if (eachPart.Equals(" _|"))
                {
                    AppendScaledRightLine(widthScale, heightScale, eachPart);
                    AppendScaledUnderLine(widthScale, eachPart);
                }
                else if (eachPart.Equals("|_ "))
                {
                    AppendScaledLeftLine(widthScale, heightScale, eachPart);
                    AppendScaledUnderLine(widthScale, eachPart);
                }
                else if (eachPart.Equals("|_|"))
                {
                    AppendScaledBothLine(widthScale, heightScale, eachPart);
                    AppendScaledUnderLine(widthScale, eachPart);
                }
                else if (eachPart.Equals("   "))
                {
                    AppendScaledEmptyLine(widthScale, eachPart);
                }
                else if (eachPart.Equals("  |"))
                {
                    AppendScaledRightLine(widthScale, heightScale, eachPart);
                }
            }
            return _scaledResult.ToString();
        }

        private string[] GetLcdNumberParts(int digit)
        {
            string unitDigit = LCD_NUMBERS[digit];
            string[] digitParts = unitDigit.Split("\n");
            return digitParts;
        }

        private void AppendScaledUnderLine(int widthScale, string eachPart)
        {
            char[] scaledPart = GetScaleNumberSpace(widthScale, eachPart);
            for (int i = 1; i < scaledPart.Length - 1; i++)
            {
                scaledPart[i] = '_';
            }
            AppendScaledLcdPart(scaledPart);
        }

        private char[] GetScaleNumberSpace(int widthScale, string eachPart)
        {
            char[] scaledPart = new char[eachPart.Length * widthScale];
            for (int i = 0; i < scaledPart.Length; i++)
            {
                scaledPart[i] = ' ';
            }

            return scaledPart;
        }

        private void AppendScaledLcdPart(char[] scaledPart)
        {
            _scaledResult.AppendFormat("{0}\n", new string(scaledPart));
        }

        private void AppendScaledLeftLine(int widthScale, int heightScale, string eachPart)
        {
            char[] scaledPart = GetScaleNumberSpace(widthScale, eachPart);
            scaledPart[0] = '|';
            for (int i = 0; i < heightScale; i++)
            {
                AppendScaledLcdPart(scaledPart);
            }
        }

        private void AppendScaledRightLine(int widthScale, int heightScale, string eachPart)
        {
            char[] scaledPart = GetScaleNumberSpace(widthScale, eachPart);
            scaledPart[scaledPart.Length - 1] = '|';
            for (int i = 0; i < heightScale; i++)
            {
                AppendScaledLcdPart(scaledPart);
            }
        }

        private void AppendScaledEmptyLine(int widthScale, string eachPart)
        {
            char[] scaledPart = GetScaleNumberSpace(widthScale, eachPart);
            AppendScaledLcdPart(scaledPart);
        }

        private void AppendScaledBothLine(int widthScale, int heightScale, string eachPart)
        {
            char[] scaledPart = GetScaleNumberSpace(widthScale, eachPart);
            scaledPart[scaledPart.Length - 1] = '|';
            scaledPart[0] = '|';
            for (int i = 0; i < heightScale; i++)
            {
                AppendScaledLcdPart(scaledPart);
            }
        }
    }
}
