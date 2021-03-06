// https://leetcode.com/problems/burst-balloons/
//
//  Given n balloons, indexed from 0 to n-1.
//  Each balloon is painted with a number on it represented by array nums.
//  You are asked to burst all the balloons.
//  If the you burst balloon i you will get nums[left] * nums[i] * nums[right] coins.
//  Here left and right are adjacent indices of i. After the burst, the left and right then becomes adjacent.
//
//  Find the maximum coins you can collect by bursting the balloons wisely. 
//
// 
// Submission Details
// 76 / 76 test cases passed.
//  Status: Accepted
//  Runtime: 1348 ms
//      
//      Submitted: 0 minutes ago
//

using System;
using System.Collections.Generic;

public class Solution {
    // 3 1 5 8 -> 3 5 8 (15) -> 3 8 (120) -> 8 (24) -> (8) = 167
    // 3 1 5 8 -> 1 5 8 (3) -> 5 8 (5) -> 8 (40) -> (8)
    //                                 -> 5 (40) - (5) 

    public int MaxCoins(int[] nums) {
        var n = nums.Length;
        var others = new int[n + 2];
        others[0] = others[n + 1] = 1;
        Array.Copy(nums, 0, others, 1, n);
        var cache = new int[n + 2, n + 2];
        return Burst(others, 0, n + 1, cache);
    }

    public int Burst(int[] nums, int low, int high, int[,] cache)
    {
        if (low + 1 == high)
        {
            return 0;
        }

        if (cache[low, high] > 0)
        {
            return cache[low, high];
        }

        var max = int.MinValue;
        for (var i = low + 1; i < high; i++)
        {
            var localMax = nums[low] * nums[i] * nums[high];
            max = Math.Max(
                    max,
                    Burst(nums, low, i, cache) + localMax + Burst(nums, i, high, cache));
        }

        cache[low, high] = max;
        return max;
    }

    static void Main()
    {
        var c = new Solution();
        Console.WriteLine(c.MaxCoins(new int[] {3, 1, 5, 8}));
    }
}
