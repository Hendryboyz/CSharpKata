using System.Text;

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
            if (widthScale == 1 && heightScale == 1)
            {
                return lcdNumbers[digit];
            }
            else
            {
                string[] lcdNumParts = lcdNumbers[digit].Split("\n");
                StringBuilder sb = new StringBuilder();
                foreach (string eachPart in lcdNumParts)
                {
                    if (eachPart.Equals(" _ "))
                    {
                        char[] scalePart = NewScalePart(widthScale, eachPart);
                        for (int i = 1; i < scalePart.Length - 1; i++)
                        {
                            scalePart[i] = '_';
                        }
                        AppendScalePart(sb, scalePart);
                    }
                    else if (eachPart.Equals("| |"))
                    {
                        char[] scalePart = NewScalePart(widthScale, eachPart);
                        scalePart[0] = '|';
                        scalePart[scalePart.Length - 1] = '|';
                        for (int i = 0; i < heightScale; i++)
                        {
                            AppendScalePart(sb, scalePart);
                        }
                    }
                    else if (eachPart.Equals("|_ "))
                    {
                        char[] scalePart = NewScalePart(widthScale, eachPart);
                        scalePart[0] = '|';
                        for (int i = 0; i < heightScale; i++)
                        {
                            AppendScalePart(sb, scalePart);
                        }

                        scalePart = NewScalePart(widthScale, eachPart);
                        for (int i = 1; i < scalePart.Length - 1; i++)
                        {
                            scalePart[i] = '_';
                        }
                        AppendScalePart(sb, scalePart);
                    }
                    else if (eachPart.Equals(" _|"))
                    {
                        char[] scalePart = NewScalePart(widthScale, eachPart);
                        scalePart[scalePart.Length - 1] = '|';
                        for (int i = 0; i < heightScale; i++)
                        {
                            AppendScalePart(sb, scalePart);
                        }

                        scalePart = NewScalePart(widthScale, eachPart);
                        for (int i = 1; i < scalePart.Length - 1; i++)
                        {
                            scalePart[i] = '_';
                        }
                        AppendScalePart(sb, scalePart);
                    }
                    else if (eachPart.Equals("  |"))
                    {
                        char[] scalePart = NewScalePart(widthScale, eachPart);
                        scalePart[scalePart.Length - 1] = '|';
                        for (int i = 0; i < heightScale; i++)
                        {
                            AppendScalePart(sb, scalePart);
                        }
                    }
                    else if (eachPart.Equals("|_|"))
                    {
                        char[] scalePart = NewScalePart(widthScale, eachPart);
                        scalePart[0] = '|';
                        scalePart[scalePart.Length - 1] = '|';
                        for (int i = 0; i < heightScale; i++)
                        {
                            AppendScalePart(sb, scalePart);
                        }
                        scalePart = NewScalePart(widthScale, eachPart);
                        for (int i = 1; i < scalePart.Length - 1; i++)
                        {
                            scalePart[i] = '_';
                        }
                        AppendScalePart(sb, scalePart);
                    }
                }
                return sb.ToString();
            }
        }

        private static void AppendScalePart(StringBuilder sb, char[] scalePart)
        {
            sb.AppendFormat("{0}\n", new string(scalePart));
        }

        private static char[] NewScalePart(int widthScale, string eachPart)
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
