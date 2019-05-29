namespace Kata.CodeWar
{
    public class WeightSort
    {
        public string Sort(string weightList)
        {
            string[] weights = weightList.Split(" ");
            for (int i = 0; i < weights.Length - 1; i++)
            {
                for (int j = 0; j < weights.Length - i - 1; j++)
                {
                    if (CompareWeightDigit(weights, j, j + 1) > 0)
                    {
                        Swap(weights, j, j + 1);
                    }
                }
            }
            return string.Join(" ", weights);
        }

        private int CompareWeightDigit(string[] weights, int source, int destination)
        {
            if (DigitSum(weights[source]) > DigitSum(weights[destination]))
            {
                return 1;
            }
            else if (DigitSum(weights[source]) < DigitSum(weights[destination]))
            {
                return -1;
            }
            else
            {
                if (weights[source].CompareTo(weights[destination]) > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        private int DigitSum(string number)
        {
            int sum = 0;
            foreach (char digit in number)
            {
                sum += digit - '0';
            }
            return sum;
        }

        private void Swap(string[] weights, int source, int destination)
        {
            string tmp = weights[source];
            weights[source] = weights[destination];
            weights[destination] = tmp;
        }
    }
}
