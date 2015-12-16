//  https://leetcode.com/problems/implement-strstr/
//
//   Implement strStr().
//
//   Returns the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack. 

using System;
using System.Linq;

public class Solution {
    public int StrStr(string haystack, string needle) {
        if (needle.Length > haystack.Length)
        {
            return -1;
        }

        if (needle.Length == haystack.Length)
        {
            return needle == haystack? 0 : -1;
        }

        long _base = 37;
        long needleValue = needle.Aggregate((long) 0, (acc, x) => acc * _base + x);
        long haystackValue = Enumerable.Range(0, needle.Length).Aggregate((long) 0, (acc, x) => acc * _base + haystack[x]);
        long rank = (long) Math.Pow(_base, needle.Length - 1);

        for (var i = needle.Length; i < haystack.Length; i++)
        {
            if (needleValue == haystackValue && Contains(haystack, needle, i - needle.Length))
            {
                return i - needle.Length;
            }

            haystackValue -= rank * haystack[i - needle.Length];
            haystackValue *= _base;
            haystackValue += haystack[i];
        }

        return -1;
    }

    static bool Contains(string haystack, string needle, int pos)
    {
        var i = 0;
        while (i< needle.Length && needle[i++] == haystack[pos++]) {}
        return i == needle.Length;
    }

    static void Main()
    {
        Console.WriteLine(new Solution().StrStr("abcdefghi", "def"));
        Console.WriteLine(new Solution().StrStr("defghi", "def"));
        Console.WriteLine(new Solution().StrStr("abcdefghi", "df"));
    }
}
