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
    //  
    //  Submission Details
    //  169 / 169 test cases passed.
    //      Status: Accepted
    //      Runtime: 712 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          You are here!
    //          Your runtime beats 84.00% of csharp submissions.
    public IList<int> FindSubstring(string s, string[] words) {
        var result = new List<int>();
        var i = 0;
        var partition = words[0].Length;
        var wordsHash = words.Aggregate(new Dictionary<String, int>(), (acc, x) => {
                if (!acc.ContainsKey(x))
                {
                    acc[x] = 0;
                }

                acc[x]++;
                return acc;
        });
        while (i <= s.Length - partition * words.Length)
        {
            var part = s.Substring(i, partition);
            if (wordsHash.ContainsKey(part))
            {
                var hash = new Dictionary<String, int>(wordsHash);
                var j = i;
                while (hash.ContainsKey(part))
                {
                    hash[part]--;
                    if (hash[part] == 0)
                    {
                        hash.Remove(part);
                    }

                    j += partition;
                    if (j <= s.Length - partition)
                    {
                        part = s.Substring(j, partition);
                    }
                    else
                    {
                        break;
                    }
                }

                if (hash.Count == 0)
                {
                    result.Add(i);
                }
            }

            i++;
        }

        return result;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(", ", new Solution().FindSubstring("barfoothefoobarman", new [] { "foo", "bar" })));
        Console.WriteLine(String.Join(", ", new Solution().FindSubstring("barfoofoobarthefoobarman", new [] { "foo", "bar", "the" })));
        Console.WriteLine(String.Join(", ", new Solution().FindSubstring("aaa", new [] { "aa", "aa" })));
        Console.WriteLine(String.Join(", ", new Solution().FindSubstring("wordgoodgoodgoodbestword", new [] { "word","good","best","good" })));
    }
}
