// https://leetcode.com/problems/scramble-string/
//
//  Given a string s1, we may represent it as a binary tree by partitioning it to two non-empty substrings recursively. 
//

using System;
using System.Linq;

public class Solution {
    public bool IsScramble(string s1, string s2) {
        if (s1.Length != s2.Length)
        {
            return false;
        }

        if (s1 == s2)
        {
            return true;
        }

        if (!s1.OrderBy(x => x).SequenceEqual(s2.OrderBy(x => x)))
        {
            return false;
        }

        for (var i = 1; i < s1.Length; i++)
        {
            var s11 = s1.Substring(0, i);
            var s12 = s1.Substring(i);
            var s21 = s2.Substring(0, i);
            var s22 = s2.Substring(i);
            if (IsScramble(s11, s21) && IsScramble(s12, s22))
            {
                return true;
            }

            s21 = s2.Substring(0, s2.Length - i);
            s22 = s2.Substring(s2.Length - 1);
            if (IsScramble(s11, s22) && IsScramble(s12, s21))
            {
                return true;
            }
        }

        return false;
    }

    static void Main()
    {
        var c = new Solution();
        Console.WriteLine(c.IsScramble("rgtae", "great"));
        Console.WriteLine(c.IsScramble("rgeat", "great"));
        Console.WriteLine(c.IsScramble("treag", "great"));
    }
}
