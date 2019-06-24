using System.Collections.Generic;

namespace Kata.CodeWar
{
    public class TwiceLinear
    {
        public int GetAt(int n)
        {
            
            IList<int> linearList = new List<int>();
            Queue<int> yQueue = InitialQueue();
            Queue<int> zQueue = InitialQueue();
            while (linearList.Count <= n)
            {
                int current = 1;
                if (yQueue.Peek() < zQueue.Peek())
                {
                    current = yQueue.Dequeue();
                }
                else
                {
                    current = zQueue.Dequeue();
                }
                yQueue.Enqueue(current * 2 + 1);
                zQueue.Enqueue(current * 3 + 1);
                if (!linearList.Contains(current))
                {
                    linearList.Add(current);
                }
            }
            return linearList[n];
        }

        private Queue<int> InitialQueue()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            return queue;
        }
    }
}
