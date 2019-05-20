using System.Collections.Generic;
using System.Linq;

namespace Kata.CodeWar
{
    public class MyThreadPool
    {
        public int CheckQueueTime(int[] taskArray, int threadNumber)
        {
            int[] threads = new int[threadNumber];
            foreach (int taskConsume in taskArray)
            {
                int minTimeConsumeThread = threads.ToList().FindIndex(x => x == threads.Min());
                threads[minTimeConsumeThread] += taskConsume;
            }
            return threads.Max();
        }

        private int LoopWithQueue(int[] taskArray, int threadNumber)
        {
            Queue<int> taskQueue = new Queue<int>(taskArray);
            int[] pools = new int[threadNumber];
            int timeConsumes = 0;
            while (taskQueue.Count > 0 || pools.Count(x => x > 0) > 0)
            {
                for (int poolIndex = 0; poolIndex < threadNumber; poolIndex++)
                {
                    if (0 == pools[poolIndex] && 0 < taskQueue.Count)
                    {
                        pools[poolIndex] = taskQueue.Dequeue();
                    }
                    if (0 < pools[poolIndex])
                    {
                        pools[poolIndex]--;
                    }
                }
                timeConsumes++;
            }
            return timeConsumes;
        }
    }
}
