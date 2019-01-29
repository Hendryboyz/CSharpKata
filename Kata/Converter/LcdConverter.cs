using System.Text;

namespace Kata.Converter
{
    public class LcdConverter
    {
        private readonly string[] lcdNumbers = new string[] 
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
            " _ \n|_|\n _|"  // 9
        };

        private int _convertingDigit;

        public string Convert(int digit, int widthScale = 1, int heightScale = 1)
        {
            _convertingDigit = digit;
            if (widthScale == 1 && heightScale == 1)
            {
                return lcdNumbers[_convertingDigit];
            }
            else
            {
                return ScaleLcdNumber(widthScale, heightScale);
            }
        }

        private StringBuilder _scaledDigitNumber;

        private string ScaleLcdNumber(int widthScale, int heightScale)
        {
            string[] lcdNumParts = lcdNumbers[_convertingDigit].Split("\n");

            _scaledDigitNumber = new StringBuilder();
            foreach (string eachPart in lcdNumParts)
            {
                if (eachPart.Equals(" _ "))
                {
                    char[] scalePart = NewScalePart(widthScale, eachPart);
                    AppendTopLineScale(scalePart);
                }
                else if (eachPart.Equals("| |"))
                {
                    char[] scalePart = NewScalePart(widthScale, eachPart);
                    AppendBothSideScale(heightScale, scalePart);
                }
                else if (eachPart.Equals("|_ "))
                {
                    char[] scalePart = NewScalePart(widthScale, eachPart);
                    AppendLeftSideScale(heightScale, scalePart);

                    scalePart = NewScalePart(widthScale, eachPart);
                    AppendTopLineScale(scalePart);
                }
                else if (eachPart.Equals(" _|"))
                {
                    char[] scalePart = NewScalePart(widthScale, eachPart);
                    AppendRightSideScale(heightScale, scalePart);

                    scalePart = NewScalePart(widthScale, eachPart);
                    AppendTopLineScale(scalePart);
                }
                else if (eachPart.Equals("  |"))
                {
                    char[] scalePart = NewScalePart(widthScale, eachPart);
                    AppendRightSideScale(heightScale, scalePart);
                }
                else if (eachPart.Equals("|_|"))
                {
                    char[] scalePart = NewScalePart(widthScale, eachPart);
                    AppendBothSideScale(heightScale, scalePart);

                    scalePart = NewScalePart(widthScale, eachPart);
                    AppendTopLineScale(scalePart);
                }
            }
            return _scaledDigitNumber.ToString();
        }

        private void AppendLeftSideScale(int heightScale, char[] scalePart)
        {
            scalePart[0] = '|';
            for (int i = 0; i < heightScale; i++)
            {
                AppendScalePart(scalePart);
            }
        }

        private void AppendRightSideScale(int heightScale, char[] scalePart)
        {
            scalePart[scalePart.Length - 1] = '|';
            for (int i = 0; i < heightScale; i++)
            {
                AppendScalePart(scalePart);
            }
        }

        private void AppendBothSideScale(int heightScale, char[] scalePart)
        {
            scalePart[0] = '|';
            scalePart[scalePart.Length - 1] = '|';
            for (int i = 0; i < heightScale; i++)
            {
                AppendScalePart(scalePart);
            }
        }

        private void AppendTopLineScale(char[] scalePart)
        {
            for (int i = 1; i < scalePart.Length - 1; i++)
            {
                scalePart[i] = '_';
            }
            AppendScalePart(scalePart);
        }

        private void AppendScalePart(char[] scalePart)
        {
            _scaledDigitNumber.AppendFormat("{0}\n", new string(scalePart));
        }

        private char[] NewScalePart(int widthScale, string eachPart)
        {
            char[] scalePart = new char[eachPart.Length * widthScale];
            for (int i = 0; i < eachPart.Length * widthScale; i++)
            {
                scalePart[i] = ' ';
            }

            return scalePart;
        }
    }
}
