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

        private StringBuilder _scaledLcdNumber;

        private string ScaleLcdNumber(int digit, int widthScale, int heightScale)
        {
            _scaledLcdNumber = new StringBuilder();
            string unitLcdNumber = LCD_NUMBERS[digit];
            string[] lcdNumberParts = unitLcdNumber.Split("\n");
            foreach (string eachPart in lcdNumberParts)
            {
                if (eachPart.Equals("   "))
                {
                    char[] scaledPart = AllocateScaledSpace(eachPart.Length, widthScale);
                    AppendScaledPart(scaledPart);
                }
                else if (eachPart.Equals("  |"))
                {
                    ScaleRightLine(widthScale, heightScale, eachPart);
                }
                else if (eachPart.Equals(" _ "))
                {
                    ScaleBottomLine(widthScale, eachPart);
                }
                else if (eachPart.Equals(" _|"))
                {
                    ScaleRightLine(widthScale, heightScale, eachPart);
                    ScaleBottomLine(widthScale, eachPart);
                }
                else if (eachPart.Equals("|_ "))
                {
                    ScaleLeftLine(widthScale, heightScale, eachPart);
                    ScaleBottomLine(widthScale, eachPart);
                }
                else if (eachPart.Equals("|_|"))
                {
                    ScaleBothLine(widthScale, heightScale, eachPart);
                    ScaleBottomLine(widthScale, eachPart);
                }
            }
            return _scaledLcdNumber.ToString();
        }

        private void VerifyDigit(int digit)
        {
            if (digit < 0 || digit > 9)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private void ScaleBottomLine(int widthScale, string eachPart)
        {
            char[] scaledPart = AllocateScaledSpace(eachPart.Length, widthScale);
            for (int i = 1; i < scaledPart.Length - 1; i++)
            {
                scaledPart[i] = '_';
            }
            AppendScaledPart(scaledPart);
        }

        private void AppendScaledPart(char[] scaledPart)
        {
            _scaledLcdNumber.AppendFormat("{0}\n", new string(scaledPart));
        }

        private char[] AllocateScaledSpace(int unitOfLength, int widthScale)
        {
            char[] scaledPart = new char[unitOfLength * widthScale];
            for (int i = 0; i < scaledPart.Length; i++)
            {
                scaledPart[i] = ' ';
            }
            return scaledPart;
        }

        private void ScaleLeftLine(int widthScale, int heightScale, string eachPart)
        {
            char[] scaledPart = AllocateScaledSpace(eachPart.Length, widthScale);
            scaledPart[0] = '|';
            AppendVerticalComponent(heightScale, scaledPart);
        }

        private void ScaleRightLine(int widthScale, int heightScale, string eachPart)
        {
            char[] scaledPart = AllocateScaledSpace(eachPart.Length, widthScale);
            scaledPart[scaledPart.Length - 1] = '|';
            AppendVerticalComponent(heightScale, scaledPart);
        }

        private void ScaleBothLine(int widthScale, int heightScale, string eachPart)
        {
            char[] scaledPart = AllocateScaledSpace(eachPart.Length, widthScale);
            scaledPart[0] = '|';
            scaledPart[scaledPart.Length - 1] = '|';
            AppendVerticalComponent(heightScale, scaledPart);
        }

        private void AppendVerticalComponent(int heightScale, char[] scaledPart)
        {
            for (int i = 0; i < heightScale; i++)
            {
                AppendScaledPart(scaledPart);
            }
        }
    }
}
