//  https://leetcode.com/problems/wildcard-matching/
//
//  '?' Matches any single character.
//  '*' Matches any sequence of characters (including the empty sequence).
//
//  The matching should cover the entire input string (not partial).
//
//  The function prototype should be:
//  bool isMatch(const char *s, const char *p)
//
//  Some examples:
//  isMatch("aa","a") → false
//  isMatch("aa","aa") → true
//  isMatch("aaa","aa") → false
//  isMatch("aa", "*") → true
//  isMatch("aa", "a*") → true
//  isMatch("ab", "?*") → true
//  isMatch("aab", "c*a*b") → false

using System;
using System.Linq;

public class Solution {
    public bool IsMatch(string s, string p) {
        if (String.IsNullOrEmpty(s))
        {
            return String.IsNullOrEmpty(p) || p[0] == '*' && IsMatch(s, p.Substring(1));
        }

        if (String.IsNullOrEmpty(p))
        {
            return false;
        }

        if (s[0] == p[0])
        {
            return IsMatch(s.Substring(1), p.Substring(1));
        }

        if (p[0] == '?')
        {
            return IsMatch(s.Substring(1), p.Substring(1));
        }

        if (p[0] == '*')
        {
            return IsMatch(s, p.Substring(1)) || IsMatch(s.Substring(1), p);
        }

        return false;
    }

    //  
    //  Submission Details
    //  1801 / 1801 test cases passed.
    //      Status: Accepted
    //      Runtime: 304 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/52922349/
    public bool IsMatchDp(string s, string p)
    {
        var dp = new bool[s.Length + 1, p.Length + 1];
        dp[0, 0] = true;
        for (var i = 1; i <= p.Length && p[i - 1] == '*'; i++)
        {
            dp[0, i] = true;
        }

        for (var i = 1; i <= s.Length; i++)
        {
            for (var j = 1; j <= p.Length; j++)
            {
                if (s[i - 1] == p[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else
                {
                    switch (p[j - 1])
                    {
                        case '?': dp[i, j] = dp[i - 1, j - 1]; break;
                        case '*': dp[i, j] = dp[i - 1, j] || dp[i, j - 1]; break;
                        default : dp[i, j] = false; break;
                    }
                }
            }
        }

        return dp[s.Length, p.Length];
    }

    static void Main()
    {
        var s = new Solution();
        foreach (var x in new [] {
                    Tuple.Create("aa", "a", false),
                    Tuple.Create("aa", "aa", true),
                    Tuple.Create("aaa", "aa", false),
                    Tuple.Create("aa", "*", true),
                    Tuple.Create("aa", "a*", true),
                    Tuple.Create("ab", "?*", true),
                    Tuple.Create("aab", "c*a*b", false),
                })
        {
            if (s.IsMatch(x.Item1, x.Item2) != x.Item3)
            {
                Console.WriteLine("hahaha idioit!. {0} {1}", x, s.IsMatch(x.Item1, x.Item2));
            }

            if (s.IsMatchDp(x.Item1, x.Item2) != x.Item3)
            {
                Console.WriteLine("hahaha idioit!. {0} {1}", x, s.IsMatch(x.Item1, x.Item2));
            }
        }
    }
}
