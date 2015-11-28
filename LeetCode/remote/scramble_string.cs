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
        return IsScrambleHelper(s1, s2, new Dictionary<String, bool>());
    }

    public bool IsScrambleHelper(string s1, string s2, Dictionary<String, bool> cache)
    {
        var key = s1 + "." + s2;
        if (cache.ContainsKey(key))
        {
            return cache[key];
        }

        if (s1 == s2)
        {
            cache[key] = true;
            return cache[key];
        }

        if (!s1.OrderBy(x => x).SequenceEqual(s2.OrderBy(x => x)))
        {
            cache[key] = false;
            return cache[key];
        }

        for (var i = 1; i < s1.Length; i++)
        {
            var s11 = s1.Substring(0, i);
            var s12 = s1.Substring(i);
            var s21 = s2.Substring(0, i);
            var s22 = s2.Substring(i);
            if (IsScramble(s11, s21) && IsScramble(s12, s22))
            {
                cache[key] = true;
                return cache[key];
            }

            s21 = s2.Substring(0, s2.Length - i);
            s22 = s2.Substring(s2.Length - i);
            if (IsScramble(s11, s22) && IsScramble(s12, s21))
            {
                cache[key] = true;
                return cache[key];
            }
        }

        cache[key] = false;
        return cache[key];
    }

    static void Main()
    {
        var c = new Solution();
        Console.WriteLine(c.IsScramble("rgtae", "great"));
        Console.WriteLine(c.IsScramble("rgeat", "great"));
        Console.WriteLine(c.IsScramble("treag", "great"));
    }
}
