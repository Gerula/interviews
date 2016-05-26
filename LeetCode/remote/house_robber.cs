// https://leetcode.com/problems/house-robber/
//
// You are a professional robber planning to rob houses along a street.
// Each house has a certain amount of money stashed,
// the only constraint stopping you from robbing each of them is that
// adjacent houses have security system connected and it will automatically
// contact the police if two adjacent houses were broken into on the same night.
//
// Given a list of non-negative integers representing the amount of money of each house,
// determine the maximum amount of money you can rob tonight without alerting the police.
//
//
// Submission Details
// 69 / 69 test cases passed.
//  Status: Accepted
//  Runtime: 164 ms
//      
//      Submitted: 0 minutes ago
//

using System;

public class Solution {

    // 
    //     M(k) = money at the kth house
    //     P(0) = 0
    //     P(1) = M(1)
    //     P(k) = max(P(k−2) + M(k), P(k−1))
    //
    public int Rob(int[] nums) {
        if (nums.Length == 0)
        {
            return 0;
        }

        if (nums.Length == 1)
        {
            return nums[0];
        }

        var s1 = 0;
        var s2 = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            s1 = Math.Max(s1 + nums[i], s2);
            var c = s1; s1 = s2; s2 = c;
        }

        return s2;
    }

    static void Main()
    {
        var c = new Solution();
        Console.WriteLine(c.Rob(new [] { 1, 2, 3, 4, 5, 6 }));
    }

    //  https://leetcode.com/submissions/detail/62518565/
    //
    //  Submission Details
    //  69 / 69 test cases passed.
    //      Status: Accepted
    //      Runtime: 168 ms
    //          
    //          Submitted: 0 minutes ago
    public int Rob(int[] nums) {
        return nums.Aggregate(
                Tuple.Create(0, 0),
                (acc, x) => {
                    return Tuple.Create(acc.Item2, Math.Max(x + acc.Item1, acc.Item2));
                }).Item2;
    }
}
