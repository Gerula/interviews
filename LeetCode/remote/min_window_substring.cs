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

//  Starting off the day with a nice dose of fail
public class Solution {
    public string MinWindow(string s, string t) {
        var set = t.Aggregate(new HashSet<char>(), (acc, x) => {
           acc.Add(x);
           return acc;
        });
        
        var inclusionSet = t.Aggregate(new Dictionary<char, int>(), (acc, x) => {
            if (!acc.ContainsKey(x))
            {
                acc[x] = 0;
            }
            
            acc[x]++;
            return acc;
        });
        
        var minWindow = s;
        var frequencies = new Dictionary<char, int>();
        var left = 0;
        var right = 0;
        while (right < s.Length)
        {
            if (!set.Contains(s[right]))
            {
                right++;
                continue;
            }
            
            if (!frequencies.ContainsKey(s[right]))
            {
                frequencies[s[right]] = 0;
            }
            
            frequencies[s[right]]++;
            if (inclusionSet.ContainsKey(s[right]))
            {
                inclusionSet[s[right]]--;
                if (inclusionSet[s[right]] == 0)
                {
                    inclusionSet.Remove(s[right]);    
                }
            }
            
            while (left < right && 
                   (!set.Contains(s[left]) || frequencies[s[left]] > 1))
            {
                if (set.Contains(s[left]))
                {
                    frequencies[s[left]]--;
                }
                
                left++;
            }
            
            if (right - left + 1 < minWindow.Length && !inclusionSet.Any())
            {
                minWindow = s.Substring(left, right - left + 1);
            }
            
            right++;
        }
        
        return inclusionSet.Any() ? String.Empty : minWindow;
    }
}
