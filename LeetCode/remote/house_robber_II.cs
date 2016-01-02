//  https://leetcode.com/problems/house-robber-ii/
//
//  Note: This is an extension of House Robber.
//
//  After robbing those houses on that street,
//  the thief has found himself a new place for his thievery so that he will not get too much attention.
//  This time, all houses at this place are arranged in a circle.
//  That means the first house is the neighbor of the last one.
//  Meanwhile, the security system for these houses remain the same as for those in the previous street.
//
//  Given a list of non-negative integers representing the amount of money of each house,
//  determine the maximum amount of money you can rob tonight without alerting the police.

using System;

public class Solution {
    //  
    //  Submission Details
    //  74 / 74 test cases passed.
    //      Status: Accepted
    //      Runtime: 152 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          https://leetcode.com/submissions/detail/49514128/
    //
    public int Rob(int[] nums) {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        return Math.Max(Rob(nums, 0, nums.Length - 2), Rob(nums, 1, nums.Length - 1));
    }

    public int Rob(int[] nums, int low, int high)
    {
        var a = 0;
        var b = 0;
        for (var i = low; i <= high; i++)
        {
            var dontBuy = Math.Max(a, b);
            var buy = a + nums[i];
            a = dontBuy;
            b = buy;
        }

        return Math.Max(a, b);
    }
}
