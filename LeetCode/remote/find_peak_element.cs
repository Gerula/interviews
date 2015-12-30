//  https://leetcode.com/problems/find-peak-element/
//
//  A peak element is an element that is greater than its neighbors.
//
//  Given an input array where num[i] ≠ num[i+1], find a peak element and return its index.
//
//  The array may contain multiple peaks, in that case return the index to any one of the peaks is fine.
//
//  You may imagine that num[-1] = num[n] = -∞.
//
//  For example, in array [1, 2, 3, 1], 3 is a peak element and your function should return the index number 2.

using System;

public class Solution {
    //  Submission Result: Wrong Answer
    //  Input: [2,1]
    //  Output: 2
    //  Expected: 0 
    //
    //  OJ is tripping on shrooms
    public int FindPeakElement(int[] nums) {
        var low = 0;
        var high = nums.Length - 1;
        while (low < high)
        {
            var mid = low + (high - low) / 2;
            if (nums[mid] > nums[mid + 1])
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        return nums[low];
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.FindPeakElement(new [] {1, 2, 3, 1}));
        Console.WriteLine(s.FindPeakElement(new [] {3, 2, 1}));
        Console.WriteLine(s.FindPeakElement(new [] {1, 2, 3}));
    }
}
