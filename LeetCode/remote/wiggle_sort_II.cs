//  https://leetcode.com/problems/wiggle-sort-ii/
//
//   Given an unsorted array nums, reorder it such that nums[0] < nums[1] > nums[2] < nums[3]....
//
//   Example:
//   (1) Given nums = [1, 5, 1, 1, 6, 4], one possible answer is [1, 4, 1, 5, 1, 6].
//   (2) Given nums = [1, 3, 2, 2, 3, 1], one possible answer is [2, 3, 1, 3, 1, 2].
//
//   Note:
//   You may assume all input has valid answer.
//
//   Follow Up:
//   Can you do it in O(n) time and/or in-place with O(1) extra space? 

using System;
using System.Linq;

public class Solution {
    //  
    //  Submission Details
    //  39 / 39 test cases passed.
    //      Status: Accepted
    //      Runtime: 252 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          https://leetcode.com/submissions/detail/49415901/
    //
    //          Hey, at least I learned something. Happy New Year! 🎆
    public void WiggleSort(int[] nums) {
        var sorted = nums.OrderBy(x => x).ToArray();
        var half = (nums.Length - 1) / 2 + 1;
        var a = 0;
        var b = half;
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            nums[i] = i % 2 == 0 ? sorted[a++] : sorted[b++];
        }
    }

    static void Main()
    {
        var s = new Solution();
        foreach (var x in new [] {
                    new [] { 1, 5, 1, 1, 6, 4 },
                    new [] { 1, 3, 2, 2, 3, 1 },
                    new [] { 4, 5, 5, 6 },
                    new [] { 2, 5, 1, 3, 2, 1, 1 }
                })
        {
            Console.Write("{0} -> ", String.Join(", ", x));
            s.WiggleSort(x);
            Console.WriteLine("{0} ", String.Join(", ", x));
        }
    }
}
