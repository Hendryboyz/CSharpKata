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

        public string Convert(int digit, int widthScale = 1, int heightScale = 1)
        {
            VerifyDigit(digit);
            if (widthScale == 1 && heightScale == 1)
            {
                return LCD_NUMBERS[digit];
            }
            else
            {
                return ScaleLcdNumber(digit, widthScale, heightScale);
            }
        }

        private void VerifyDigit(int digit)
        {
            if (digit < 0 || digit > 9)
            {
                throw new InvalidCastException();
            }
        }

        private StringBuilder _scaledResult;

        private string ScaleLcdNumber(int digit, int widthScale, int heightScale)
        {
            _scaledResult = new StringBuilder();
            foreach (string eachPart in GetLcdNumberParts(digit))
            {
                if (eachPart.Equals("   "))
                {
                    AppendEmptyLineToResult(widthScale, eachPart);
                }
                else if (eachPart.Equals(" _ "))
                {
                    AppendUnderLineToResult(widthScale, eachPart);
                }
                else if (eachPart.Equals(" _|"))
                {
                    AppendRightLineToResult(widthScale, heightScale, eachPart);
                    AppendUnderLineToResult(widthScale, eachPart);
                }
                else if (eachPart.Equals("|_ "))
                {
                    AppendLeftLineToResult(widthScale, heightScale, eachPart);
                    AppendUnderLineToResult(widthScale, eachPart);
                }
                else if (eachPart.Equals("  |"))
                {
                    AppendRightLineToResult(widthScale, heightScale, eachPart);
                }
                else if (eachPart.Equals("|_|"))
                {
                    AppendBothLineToResult(widthScale, heightScale, eachPart);
                    AppendUnderLineToResult(widthScale, eachPart);
                }
            }
            return _scaledResult.ToString();
        }

        

        private string[] GetLcdNumberParts(int digit)
        {
            string unitNumber = LCD_NUMBERS[digit];
            string[] lcdNumberParts = unitNumber.Split("\n");
            return lcdNumberParts;
        }

        private void AppendEmptyLineToResult(int widthScale, string eachPart)
        {
            char[] scaledPart = GetScaledPartSpcae(widthScale, eachPart);
            AppendScaledNumberPartToResult(scaledPart);
        }

        private void AppendUnderLineToResult(int widthScale, string eachPart)
        {
            char[] scaledPart = GetScaledPartSpcae(widthScale, eachPart);
            for (int i = 1; i < scaledPart.Length - 1; i++)
            {
                scaledPart[i] = '_';
            }
            AppendScaledNumberPartToResult(scaledPart);
        }

        private char[] GetScaledPartSpcae(int widthScale, string eachPart)
        {
            char[] scaledPart = new char[eachPart.Length * widthScale];
            for (int i = 0; i < scaledPart.Length; i++)
            {
                scaledPart[i] = ' ';
            }
            return scaledPart;
        }

        private void AppendScaledNumberPartToResult(char[] scaledPart)
        {
            _scaledResult.AppendFormat("{0}\n", new string(scaledPart));
        }

        private void AppendLeftLineToResult(int widthScale, int heightScale, string eachPart)
        {
            char[] scaledPart = GetScaledPartSpcae(widthScale, eachPart);
            scaledPart[0] = '|';
            AppendVerticalScaledPartToResult(heightScale, scaledPart);
        }

        private void AppendRightLineToResult(int widthScale, int heightScale, string eachPart)
        {
            char[] scaledPart = GetScaledPartSpcae(widthScale, eachPart);
            scaledPart[scaledPart.Length - 1] = '|';
            AppendVerticalScaledPartToResult(heightScale, scaledPart);
        }

        private void AppendVerticalScaledPartToResult(int heightScale, char[] scaledPart)
        {
            for (int i = 0; i < heightScale; i++)
            {
                AppendScaledNumberPartToResult(scaledPart);
            }
        }

        private void AppendBothLineToResult(int widthScale, int heightScale, string eachPart)
        {
            char[] scaledPart = GetScaledPartSpcae(widthScale, eachPart);
            scaledPart[scaledPart.Length - 1] = '|';
            scaledPart[0] = '|';
            AppendVerticalScaledPartToResult(heightScale, scaledPart);
        }
    }
}
