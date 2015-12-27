//  https://leetcode.com/problems/unique-paths/
//
//  A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
//
//  The robot can only move either down or right at any point in time.
//  The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).
//
//  How many possible unique paths are there?

using System;

public class Solution {
    //  
    //  Submission Details
    //  61 / 61 test cases passed.
    //      Status: Accepted
    //      Runtime: 52 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //
    //Submission Details
    //61 / 61 test cases passed.
    //  Status: Accepted
    //  Runtime: 56 ms
    //      
    //      Submitted: 0 minutes ago
    //
    public int UniquePaths(int m, int n) {
        var dp = new int[m + 1, n + 1];
        dp[0, 1] = 1;

        for (var i = 1; i <= m; i++)
        {
            for (var j = 1; j <= n; j++)
            {
                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
            }
        }

        return dp[m, n];
    }

    static void Main()
    {
        Console.WriteLine(new Solution().UniquePaths(3, 7));
    }
}
