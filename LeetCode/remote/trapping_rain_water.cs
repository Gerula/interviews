//  https://leetcode.com/problems/trapping-rain-water/
//
//   Given n non-negative integers representing an elevation map where the width of each bar is 1,
//   compute how much water it is able to trap after raining.
//
//   For example,
//   Given [0,1,0,2,1,0,1,3,2,1,2,1], return 6. 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    //  https://leetcode.com/submissions/detail/52081761/
    //
    //
    //  Submission Details
    //  315 / 315 test cases passed.
    //      Status: Accepted
    //      Runtime: 164 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  You are here!
    //  Your runtime beats 71.79% of csharp submissions.
    public int Trap2(int[] height) {
        var n = height.Length;
        if (n < 3)
        {
            return 0;
        }

        var maxLeft = new int[n];
        for (var i = 1; i < n - 1; i++)
        {
            maxLeft[i] = Math.Max(maxLeft[i - 1], height[i - 1]);
        }

        var water = 0;
        var maxRight = height[n - 1];
        for (var i = n - 2; i > 0; i--)
        {
            maxRight = Math.Max(maxRight, height[i + 1]);
            water += Math.Max(0, Math.Min(maxRight, maxLeft[i]) - height[i]);
        }

        return water;
    }

    public int Trap(int[] height)
    {
        if (height.Length < 3)
        {
            return 0;
        }

        Func<List<int>, int, List<int>> runningMax = (acc, x) => {
            acc.Add(acc.Count == 0 ? x : Math.Max(x, acc.Last()));
            return acc;
        };

        return height
               .Aggregate(
                       new List<int>(),
                       runningMax)
               .Zip(height
                    .Reverse()
                    .Aggregate(
                        new List<int>(),
                        runningMam)
                    .AsEnumerable()
                    .Reverse(),
                    (a, b) => Math.Min(a, b))
               .Zip(height,
                    (a, b) => a - b)
               .Where(x => x > 0)
               .Sum();
    }

    static void Main()
    {
        Console.WriteLine(new Solution().Trap(new [] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
    }
}
