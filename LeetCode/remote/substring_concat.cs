//  https://leetcode.com/problems/substring-with-concatenation-of-all-words/
//
//   You are given a string, s, and a list of words, words, that are all of the same length. Find all starting indices of substring(s) in s that is a concatenation of each word in words exactly once and without any intervening characters.
//
//   For example, given:
//   s: "barfoothefoobarman"
//   words: ["foo", "bar"]
//
//   You should return the indices: [0,9].
//   (order does not matter). 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public IList<int> FindSubstring(string s, string[] words) {
        var result = new List<int>();
        var hash = words.Aggregate(new HashSet<String>(), (acc, x) => {
                    acc.Add(x);
                    return acc;
                });

        var partition = words[0].Length;
        var i = 0;
        while (i < s.Length - partition)
        {
            Console.WriteLine(s.Substring(i, partition));
            if (hash.Contains(s.Substring(i, partition)))
            {
                result.Add(i);
                while (i < s.Length - partition && hash.Contains(s.Substring(i, partition)))
                {
                    i += partition;
                }
            }
            else
            {
                i++;
            }
        }

        return result;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(", ", new Solution().FindSubstring("barfoothefoobarman", new [] { "foo", "bar" })));
        Console.WriteLine(String.Join(", ", new Solution().FindSubstring("barfoofoobarthefoobarman", new [] { "foo", "bar", "the" })));
    }
}
