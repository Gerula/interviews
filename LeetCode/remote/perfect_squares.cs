//  https://leetcode.com/problems/perfect-squares/
//
//   Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n.
//
//   For example, given n = 12, return 3 because 12 = 4 + 4 + 4; given n = 13, return 2 because 13 = 4 + 9. 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    // 
    // Submission Details
    // 600 / 600 test cases passed.
    //  Status: Accepted
    //  Runtime: 180 ms
    //      
    //      Submitted: 0 minutes ago
    //
    public int NumSquares(int n) {
        var dp = new int[n + 1];

        for (var i = 1; i <= n; i++)
        {
            dp[i] = int.MaxValue;
            for (var j = 1; j * j <= i; j++)
            {
                dp[i] = Math.Min(dp[i], dp[i - j * j] + 1);
            }
        }

        return dp[n];
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.NumSquares(4));
        Console.WriteLine(s.NumSquares(12));
        Console.WriteLine(s.NumSquares(13));
        Console.WriteLine(s.NumSquares(1535));
    }
}
