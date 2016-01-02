//  https://leetcode.com/problems/kth-largest-element-in-an-array/
//
//  Find the kth largest element in an unsorted array. Note that it is the kth largest element in the sorted order, not the kth distinct element.
//
//  For example,
//  Given [3,2,1,5,6,4] and k = 2, return 5.
//
//  Note:
//  You may assume k is always valid, 1 ≤ k ≤ array's length.

using System;
using System.Linq;

public class Solution {
    static Random r = new Random();

    public int FindKthLargest(int[] nums, int k) 
    {
        var low = 0;
        var high = nums.Length;
        k = nums.Length - k;
        while (low < high)
        {
            var pivot = r.Next(low, high);
            var num = nums[pivot];
            var smaller = low;
            var larger = high - 1;
            while (smaller < larger)
            {
                if (nums[smaller] < num)
                {
                    smaller++;
                }
                else
                {
                    var c = nums[smaller];
                    nums[smaller] = nums[larger];
                    nums[larger] = c;
                    larger--;
                }
            }

            if (smaller > larger)
            {
                smaller--;
            }

            if (smaller == k)
            {
                return nums[smaller];
            }

            if (smaller > k)
            {
                high = smaller + 1;
            }
            else
            {
                low = smaller;
            }
        }

        return nums[low];
    }

    public int KthLargest(int[] nums, int k) 
    {
        return nums
               .OrderBy(x => x)
               .Reverse()
               .Skip(k - 1)
               .Take(1)
               .First();
    }

    static void Main()
    {
        var s = new Solution();
        var times = r.Next(1, 10);
        for (var i = 0; i < times; i++)
        {
            var nums = Enumerable
                       .Repeat(1, r.Next(3, 13))
                       .Select(x => r.Next(1, 20))
                       .ToArray();
            var k = r.Next(1, nums.Length);
            Console.WriteLine(
                    "{0}:{1} - naive {2} - efficient {3}. Sorted {4}",
                    String.Join(", ", nums),
                    k,
                    s.KthLargest(nums, k),
                    s.FindKthLargest(nums, k),
                    String.Join(", ", nums.OrderBy(x => x).Reverse()));
        }
    }
}
