using System;

namespace Kata.CodeWar
{
    public class FibProduct
    {
        private readonly int SEQUECE_LENGTH = 1000;
        private ulong[] _fedSequence;

        public FibProduct()
        {
        }

        public ulong[] ProductFib(ulong product)
        {
            _fedSequence = new ulong[SEQUECE_LENGTH + 1];
            BuildFibnacci(SEQUECE_LENGTH, _fedSequence);

            int index = 1;
            while (_fedSequence[index] * _fedSequence[index - 1] < product)
            {
                index++;
            }
            ulong isEqual = _fedSequence[index] * _fedSequence[index - 1] == product ? 1UL : 0UL;
            return new ulong[] { _fedSequence[index - 1], _fedSequence[index], isEqual };
        }

        public ulong BuildFibnacci(int index, ulong[] fibSequence)
        {
            if (0 == index || 1 == index)
            {
                fibSequence[index] = Convert.ToUInt64(index);
                return Convert.ToUInt64(index);
            }
            else if (0 == fibSequence[index])
            {
                fibSequence[index] = BuildFibnacci(index - 1, fibSequence) + BuildFibnacci(index - 2, fibSequence);
                return fibSequence[index];
            }
            else
            {
                return fibSequence[index];
            }
        }
    }
}
