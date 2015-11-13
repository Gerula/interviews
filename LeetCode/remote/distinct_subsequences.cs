// https://leetcode.com/problems/distinct-subsequences/
//
//  Given a string S and a string T, count the number of distinct subsequences of T in S.
//
//  A subsequence of a string is a new string which is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. (ie, "ACE" is a subsequence of "ABCDE" while "AEC" is not).
//
//  Here is an example:
//  S = "rabbbit", T = "rabbit"
//
//  Return 3. 
//
// 
// Submission Details
// 63 / 63 test cases passed.
//  Status: Accepted
//  Runtime: 136 ms
//      
//      Submitted: 0 minutes ago
//

using System;

public class Solution {
    public int NumDistinct(string s, string t) 
    {
        int [,] dp = new int[t.Length + 1, s.Length + 1];
        for (int j = 0; j <= s.Length; j++) dp[0, j] = 1;
        for (int j = 1; j <= s.Length; j++)
        {
            for (int i = 1; i <= t.Length; i++)
            {
                dp[i, j] = dp[i, j - 1] + (t[i - 1] == s[j - 1] ? dp[i - 1, j - 1] : 0);
            }
        }

        return dp[t.Length, s.Length];
    }

    static void Main()
    {
        Console.WriteLine(new Solution().NumDistinct("rabbbit", "rabbit"));
    }
}

