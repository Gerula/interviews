//  https://leetcode.com/problems/count-of-range-sum/
//
//   Given an integer array nums, return the number of range sums that lie in [lower, upper] inclusive.
//   Range sum S(i, j) is defined as the sum of the elements in nums between indices i and j (i ≤ j), inclusive.
//
//   Note:
//   A naive algorithm of O(n2) is trivial. You MUST do better than that. 

using System;
using System.Linq;

public class Solution {
    public int CountRangeSum(int[] nums, int lower, int upper) {
        var n = nums.Length;
        var pre = new int[n];
        pre[0] = nums[0];
        for (var i = 1; i < n; i++)
        {
            pre[i] = pre[i - 1] + nums[i];
        }

        var count = 0;
        for (var i = 0; i < n; i++)
        {
            for (var j = i; j < n; j++)
            {
                var sum = pre[j] - pre[i] + nums[j];
                if (lower <= sum && sum <= upper)
                {
                    count++;
                }
            }
        }

        return count;
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.CountRangeSum(new [] { -2, 5, -1 }, -2, 2));
        Console.WriteLine(s.CountRangeSum(new [] { -2, 5, -1 }, -1, 2));
    }
}
