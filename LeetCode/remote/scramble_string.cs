// https://leetcode.com/problems/scramble-string/
//
//  Given a string s1, we may represent it as a binary tree by partitioning it to two non-empty substrings recursively. 
//
// First attempt:
//
// 
// Submission Details
// 281 / 281 test cases passed.
//  Status: Accepted
//  Runtime: 160 ms
//      
//      Submitted: 0 minutes ago

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public bool IsScramble(string s1, string s2) {
        if (s1.Length != s2.Length)
        {
            return false;
        }

        var n = s1.Length;
        var dp = new bool[n, n, n];

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                dp[i, j, 0] = s1[i] == s2[j];
            }
        }

        for (var l = 1; l < n; l++)
        {
            for (var i = 0; i <= n - l; i++)
            {
                for (var j = 0; j <= n - l; j++)
                {
                    dp[i, j, l] = false;
                    for (var k = 1; k < l; k++)
                    {
                        dp[i, j, l] = dp[i, j, l] ||
                                      dp[i, j, k] && dp[i + k + 1, j + k + 1, l - k - 1] ||
                                      dp[i, j + l - k, k] && dp[i + k + 1, j, l - k - 1];
                    }
                }
            }
        }

        return dp[0, 0, n - 1];
    }

    static void Main()
    {
        var c = new Solution();
        Console.WriteLine(c.IsScramble("rgtae", "great"));
        Console.WriteLine(c.IsScramble("rgeat", "great"));
        Console.WriteLine(c.IsScramble("treag", "great"));
    }
}
