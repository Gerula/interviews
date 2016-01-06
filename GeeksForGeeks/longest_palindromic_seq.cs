//  http://www.geeksforgeeks.org/dynamic-programming-set-12-longest-palindromic-subsequence/
//
//  Given a sequence, find the length of the longest palindromic subsequence in it.
//  For example, if the given sequence is “BBABCBCAB”,
//  then the output should be 7 as “BABCBAB” is the longest palindromic subseuqnce in it.
//  “BBBBB” and “BBCBB” are also palindromic subsequences of the given sequence, but not the longest ones.

using System;

static class Solution
{
    static String Palind(this String s)
    {
        var n = s.Length;
        var dp = new int[n, n];

        for (var i = 0; i < n; i++)
        {
            dp[i, i] = 1;
        }

        for (var len = 2; len <= n; len++)
        {
            for (var i = 0; i < n - len + 1; i++)
            {
                var j = i + len - 1;
                if (s[i] == s[j])
                {
                    dp[i, j] = 2 + (len == 2 ? 0 : dp[i + 1, j - 1]);
                }
                else
                {
                    dp[i, j] = Math.Max(dp[i, j - 1], dp[i + 1, j]);
                }
            }
        }

        return dp[0, n - 1].ToString();
    }

    static void Main()
    {
        Console.WriteLine("BBABCBCAB".Palind());
    }
}
