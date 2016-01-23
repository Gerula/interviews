//  http://lcoj.tk/problems/word-pattern-ii/
//
//  Given a pattern and a string, find if the string str follows the same pattern.
//
//  Here follow means a full match, such that there is a bijection between letter in pattern and substring in str.
//
//  Examples:
//
//      pattern = "abab", str = "redblueredblue" should return true.
//      pattern = "aaaa", str = "asdasdasdasd" should return true.
//      pattern = "aabb", str = "xyzabcxzyabc" should return false.
//
//  Notes:
//
//  Input contains only lowercase alphabetical letters.
//  Each letter in pattern maps to a substring with length at least 1.

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static bool Match(String a, String b)
    {
        var mapping = new Dictionary<char, String>();
        return Match(a, b, mapping);
    }

    static bool Match(String a, String b, Dictionary<char, String> mapping)
    {
        if (String.IsNullOrEmpty(a) || String.IsNullOrEmpty(b))
        {
            var result = String.IsNullOrEmpty(a) && String.IsNullOrEmpty(b);
            if (result)
            {
                Console.WriteLine(String.Join(Environment.NewLine, mapping.Select(x => String.Format("{0} - {1}", x.Key, x.Value))));
            }

            return result;
        }

        var pattern = a[0];
        if (mapping.ContainsKey(pattern))
        {
            var match = mapping[pattern];
            return b.StartsWith(match) && Match(a.Substring(1), b.Substring(match.Length), mapping);
        }

        var isMatch = false;
        for (var i = 1; i <= b.Length - a.Length - 1; i++)
        {
            mapping[pattern] = b.Substring(0, i);
            isMatch = isMatch || Match(a.Substring(1), b.Substring(i), mapping); // It's cool here that there are multiple possibilites
            //  a - r
            //  b - edblue
            //  a - re
            //  b - dblue
            //  a - red
            //  b - blue
            //  a - redb
            //  b - lue
            //  a - redbl
            //  b - ue
            //  a - redblu
            //  b - e
            //  But short-circuiting this operation will deliver only one.
            mapping.Remove(pattern);
        }

        return isMatch;
    }

    static void Main()
    {
        Console.WriteLine(Match("abab", "redblueredblue"));
        Console.WriteLine(Match("aaaa", "asdasdasdasd"));
        Console.WriteLine(Match("aabb", "xyzabcxzyabc"));
    }
}
