// http://careercup.com/question?id=5630275595796480
//
// Given a string, print the smallest window containing highest number of distinct characters
//

using System;
using System.Collections.Generic;

static class Program
{
    static String Window(this String s)
    {
        var left = 0;
        var windowRight = 0;
        var hash = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            var letter = s[i];
            if (!hash.ContainsKey(letter))
            {
                hash[letter] = 1;
                continue;
            }

            hash[letter]++;            
            while (hash.ContainsKey(s[left]) && hash[s[left]] > 1)
            {
                hash[s[left]]--;
                left++;
            }

            windowRight = i;
        }

        return s.Substring(left, windowRight - left + 1);
    }

    static void Main()
    {
        Console.WriteLine("aabcbcdbca".Window());
    }
}
