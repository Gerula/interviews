//  https://leetcode.com/problems/remove-duplicate-letters/
//
//   Given a string which contains only lowercase letters, remove duplicate letters so that every letter appear once and only once. You must make sure your result is the smallest in lexicographical order among all possible results.
//
//   Example:
//
//   Given "bcabc"
//   Return "abc"
//
//   Given "cbacdcbc"
//   Return "acdb" 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    //  
    //  Submission Details
    //  286 / 286 test cases passed.
    //      Status: Accepted
    //      Runtime: 148 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          Nice solution
    public string RemoveDuplicateLetters(string s) {
        if (String.IsNullOrEmpty(s))
        {
            return s;
        }

        var counts = new int[27];
        foreach (var c in s)
        {
            counts[c - 'a']++;
        }

        var pos = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] < s[pos])
            {
                pos = i;
            }

            if (--counts[s[i] - 'a'] == 0)
            {
                break;
            }
        }

        return s[pos] + RemoveDuplicateLetters(s.Substring(pos + 1).Replace(s[pos].ToString(), ""));
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.RemoveDuplicateLetters("bcabc"));
        Console.WriteLine(s.RemoveDuplicateLetters("cbacdcbc"));
        Console.WriteLine(s.RemoveDuplicateLetters("bcabc"));
        Console.WriteLine(s.RemoveDuplicateLetters("dbdd"));
        Console.WriteLine(s.RemoveDuplicateLetters("abacb"));
        Console.WriteLine(s.RemoveDuplicateLetters("bbcaac"));
    }
}
