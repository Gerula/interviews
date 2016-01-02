//  https://leetcode.com/problems/house-robber/
//
//  You are a professional robber planning to rob houses along a street.
//  Each house has a certain amount of money stashed,
//  the only constraint stopping you from robbing each of them is that
//  adjacent houses have security system connected and it will automatically
//  contact the police if two adjacent houses were broken into on the same night.
//
//  Given a list of non-negative integers representing the amount of money of each house,
//  determine the maximum amount of money you can rob tonight without alerting the police.

using System;

public class Solution {
    public int Rob(int[] nums) {
        var dp = new int[nums.Length + 1, 2];
        for (var i = 1; i <= nums.Length; i++)
        {
            dp[i, 0] = Math.Max(dp[i - 1, 1], dp[i - 1, 0]);
            dp[i, 1] = nums[i - 1] + dp[i - 1, 0];
        }

        return Math.Max(dp[nums.Length, 0], dp[nums.Length, 1]);
    }

    static void Main()
    {
        var s = new Solution();
        foreach (var a in new [] {
                    new [] { 1, 2, 3 },
                    new [] { 1, 2, 3, 4, 5, 6 },
                    new [] { 3, 4, 10, 1, 3, 5 }
                })
        {
            Console.WriteLine(
                    "{0} {1}",
                    String.Join(", ", a),
                    s.Rob(a));
        }
    }
}
