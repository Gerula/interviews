// https://leetcode.com/problems/minimum-window-substring/
//
//  Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).
//
//  For example,
//  S = "ADOBECODEBANC"
//  T = "ABC"
//
//  Minimum window is "BANC". 
//

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public string MinWindow(string s, string t) {
        if (String.IsNullOrWhiteSpace(s) || 
            String.IsNullOrWhiteSpace(t))
        {
            return String.Empty;
        }

        var set = t.Aggregate(
                    new HashSet<char>(),
                    (acc, x) => {
                        acc.Add(x);
                        return acc;
                    });

        if (t.Length == 1)
        {
            return s.Contains(t[0]) ? t[0].ToString() : String.Empty;
        }

        var freq = new Dictionary<char, int>();

        var minStart = 0;
        var minLength = s.Length;
        var left = 0;
        for (int i = 0; i < s.Length; i++)
        {
            var c = s[i];
            if (set.Contains(c))
            {
                if (!freq.ContainsKey(c))
                {
                    freq[c] = 0;
                }

                freq[c]++;
            }

            if (freq.Count != set.Count) 
            {
                continue;
            }

            while (left <= i && 
                    (set.Contains(s[left]) && freq[s[left]] > 1 || !set.Contains(s[left])))
            {
                left++;
                if (set.Contains(s[left]))
                {
                    freq[c]--;
                }
            }

            if (minLength > i - left + 2)
            {
                minStart = left - 1;
                minLength = i - left + 2;
            }
        }

        return s.Substring(minStart, minLength);
    }

    static void Main()
    {
        Console.WriteLine(new Program().MinWindow("ADOBECODEBANC", "ABC"));
        Console.WriteLine(new Program().MinWindow("ADOBECODEBANC", "A"));
        Console.WriteLine(new Program().MinWindow("DOBECODEBNC", "A"));
        Console.WriteLine(new Program().MinWindow("BABB", "BABA"));
    }
}
