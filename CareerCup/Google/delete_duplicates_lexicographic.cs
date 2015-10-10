// http://careercup.com/question?id=5758790009880576
//
// Given a string with lowercase chars, delete the repeated
// letters and only leave one but with the optimal
// lexicographic order

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

static class Program
{
    static String GoodDeDup(this String s)
    {
        var hash = new Dictionary<char, int>();
        hash[s[s.Length - 1]] = s.Length - 1;
        for (int i = s.Length - 2; i >= 0; i--)
        {
            if (!hash.ContainsKey(s[i]) || s[i] < s[i + 1] && hash[s[i + 1]] == i + 1)
            {
                hash[s[i]] = i;
            }
        }

        var result = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            if (hash[s[i]] == i)
            {
                result.Append(s[i]);
            }
        }

        return result.ToString();
    }

    static String DeDup(this String s)
    {
        var hash = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (!hash.ContainsKey(s[i]))
            {
                hash[s[i]] = i;
            }
        }

        StringBuilder result = new StringBuilder();
        for (var c = 'a'; c < 'z'; c++)
        {
            if (hash.ContainsKey(c))
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }

    static void Main()
    {
        new [] {
            Tuple.Create("bcabc", "abc"),
            Tuple.Create("cbacdcbc", "acdb")
        }.ToList().ForEach(x => {
                    if (x.Item1.GoodDeDup() != x.Item2) 
                    {
                        throw new Exception(String.Format("You're not good enough, look : {0}={1}", x.Item1, x.Item1.GoodDeDup()));
                    }
                });

        Console.WriteLine("All appears to be well");
    }
}
