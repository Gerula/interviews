// http://qa.geeksforgeeks.org/3916/find-starting-indices-substring-that-concatenation-each-word
//
// You are given a string, S, and a list of words, L, that are all of the same length.
//
// Find all starting indices of substring(s) in S that is a concatenation of each word in L exactly once and without any intervening characters.
//
// Example :
//
// S: "barfoothefoobarman"
// L: ["foo", "bar"]
//
// You should return the indices: [0,9].
// (order does not matter).
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static IEnumerable<int> Indices(this String s, String[] words)
    {
        var hashes = new HashSet<long>();
        int size = words[0].Length;
        words.
            Select(x => x.Hash()).
            ToList().
            ForEach(y => hashes.Add(y));

        var originalString = new List<long>();
        for (int i = 0; i < s.Length; i += size)
        {
            String local = s.Substring(i, Math.Min(size, s.Length - i));
            originalString.Add(local.Hash());
        }

        int idx = 0;
        while (idx < originalString.Count)
        {
            if (hashes.Contains(originalString[idx])) 
            {
                yield return idx * size;
                while (idx < originalString.Count && hashes.Contains(originalString[idx]))
                {
                    idx++;
                }
            }
            else
            {
                idx++;
            }
        }
    }

    static long Hash(this String s)
    {
        return s.Aggregate(0, (acc, x) => acc * 27 + x);
    }

    static void Main()
    {
        String s = "barfoothefoobarman";
        Console.WriteLine(String.Join(",",
                          s.Indices(new [] {"foo", "bar"})));
    }
}
