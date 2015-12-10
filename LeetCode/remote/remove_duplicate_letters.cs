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
    public string RemoveDuplicateLetters(string s) {
        if (String.IsNullOrEmpty(s)) // FUCK YOU!! ('Given a string which contains only lowercase letters,')
        {
            return s;
        }

        var positions = new Dictionary<char, int>();
        positions[s[s.Length - 1]] = s.Length - 1;
        for (var i = s.Length - 2; i >= 0; i--)
        {
            Console.WriteLine(s[i] + " " + s[i + 1]);
            if (s[i] > s[i + 1] && !positions.ContainsKey(s[i]) ||
                s[i] <= s[i + 1] && positions[s[i + 1]] == i + 1)
            {
                positions[s[i]] = i;
            }
        }

        return String.Join(
                String.Empty, 
                s
                .Select((item, index) => new { item, index })
                .Where(x => positions[x.item] == x.index)
                .Select(x => x.item));
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.RemoveDuplicateLetters("bcabc"));
        Console.WriteLine(s.RemoveDuplicateLetters("cbacdcbc"));
        Console.WriteLine(s.RemoveDuplicateLetters("bcabc"));
        Console.WriteLine(s.RemoveDuplicateLetters("dbdd"));
        Console.WriteLine(s.RemoveDuplicateLetters("bbcaac"));
    }
}
