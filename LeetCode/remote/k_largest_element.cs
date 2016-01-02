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

    //  
    //  Submission Details
    //  27 / 27 test cases passed.
    //      Status: Accepted
    //      Runtime: 156 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          https://leetcode.com/submissions/detail/49482991/
    public int FindKthLargest(int[] nums, int k) 
    {
        var low = 0;
        var high = nums.Length - 1;
        k = nums.Length - k;
        while (low < high)
        {
            var pivot = r.Next(low, high + 1); // Randomizing added 20ms of speed to the solution
            var num = nums[pivot];
            var smaller = low;
            var larger = high;
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

            if (nums[smaller] > num)
            {
                smaller--;
            }

            if (k <= smaller)
            {
                high = smaller;
            }
            else
            {
                low = smaller + 1;
            }
        }

        return nums[k];
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
            var naive = s.KthLargest(nums, k);
            var efficient = s.FindKthLargest(nums, k);
            Console.WriteLine(
                    "{0}:{1} - naive {2} - efficient {3}. Sorted {4}. {5}",
                    String.Join(", ", nums),
                    k,
                    naive,
                    efficient,
                    String.Join(", ", nums.OrderBy(x => x).Reverse()),
                    naive != efficient ? "FUCK! ಠ_ಠ" : String.Empty);
        }
    }
}
