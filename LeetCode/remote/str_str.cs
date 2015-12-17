//  https://leetcode.com/problems/implement-strstr/
//
//   Implement strStr().
//
//   Returns the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack. 

using System;
using System.Linq;

public class Solution {
    //  
    //  Submission Details
    //  72 / 72 test cases passed.
    //      Status: Accepted
    //      Runtime: 128 ms
    //          
    //          Submitted: 1 minute ago
    public int StrStr(string haystack, string needle) {
        if (needle.Length > haystack.Length)
        {
            return -1;
        }

        if (needle.Length == haystack.Length)
        {
            return needle == haystack ? 0 : -1;
        }

        long _base = 7;
        long needleFingerPrint = needle.Aggregate((long) 0, (acc, x) => acc * _base + x);
        long hayFingerPrint = Enumerable
                              .Range(0, needle.Length)
                              .Aggregate((long) 0, (acc, x) => acc * _base + haystack[x]);
        long rank = (long) Math.Pow(_base, needle.Length - 1);

        var start = 0;
        for (var i = needle.Length; i < haystack.Length; i++)
        {
            start = i - needle.Length;
            if (hayFingerPrint == needleFingerPrint && Match(haystack, needle, start))
            {
                return start;
            }

            hayFingerPrint -= rank * haystack[start];
            hayFingerPrint = hayFingerPrint * _base + haystack[i];
        }

        start++;
        return hayFingerPrint == needleFingerPrint && Match(haystack, needle, start) ? start : -1;
    }

    public bool Match(string haystack, string needle, int index)
    {
        var needleIdx = 0;
        while (needleIdx < needle.Length && needle[needleIdx++] == haystack[index++]) {}
        return needleIdx == needle.Length;
    }

    static void Main()
    {
        Console.WriteLine(new Solution().StrStr("abcdefghi", "def"));
        Console.WriteLine(new Solution().StrStr("defghi", "def"));
        Console.WriteLine(new Solution().StrStr("abcdefghi", "df"));
    }
}
