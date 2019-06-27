using System;

namespace Kata.LeetCode
{
    public class SortArray
    {
        public int[] Buble(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = 0; j < nums.Length - i; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        Swap(nums, j, j + 1);
                    }
                }
            }
            return nums;
        }

        private void Swap(int[] nums, int source, int target)
        {
            nums[source] = nums[source] + nums[target];
            nums[target] = nums[source] - nums[target];
            nums[source] = nums[source] - nums[target];
        }

        public int[] QuickSort(int[] nums)
        {
            DoQuickSort(nums, 0, nums.Length - 1);
            return nums;
        }

        private void DoQuickSort(int[] nums, int front, int end)
        {
            if (front >= end) return;
            int pivot = nums[end];
            int i = front;
            int j = end - 1;

            while (i < j)
            {
                if (nums[i] <= pivot) i++;
                if (nums[j] > pivot) j--;
                if (nums[i] > pivot && nums[j] <= pivot)
                {
                    Swap(nums, i, j);
                }
            }
            Swap(nums, i, end);

            DoQuickSort(nums, front, j);
            DoQuickSort(nums, i + 1, end);
        }
    }
}
