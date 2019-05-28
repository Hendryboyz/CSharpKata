namespace Kata.CodeWar
{
    public class MoveZero
    {
        public int[] MoveToLast(int[] intArray)
        {
            for (int index = 0; index < intArray.Length; index++)
            {
                bool isZero = (0 == intArray[index]);
                int swappingTimes = 0;
                while (isZero && swappingTimes < intArray.Length - index)
                {
                    intArray = SwapToLast(intArray, index);
                    swappingTimes++;
                    isZero = (0 == intArray[index]);
                }
            }
            return intArray;
        }

        private int[] SwapToLast(int[] intArray, int swappingIndex)
        {
            for (int index = swappingIndex; index < intArray.Length - 1; index++)
            {
                intArray[index] = intArray[index + 1];
            }
            intArray[intArray.Length - 1] = 0;
            return intArray;
        }
    }
}
