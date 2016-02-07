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
            return Enumerable
                   .Range(0, s.Length)
                   .Select(x => IsMatch(s.Substring(0, x), p.Substring(1)))
                   .Aggregate((acc, x) => acc || x);
        }

        return false;
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
        }
    }
}
