//  https://leetcode.com/problems/anagrams/
//
//  Given an array of strings, group anagrams together. 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    //  
    //  Submission Details
    //  100 / 100 test cases passed.
    //      Status: Accepted
    //      Runtime: 652 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          https://leetcode.com/submissions/detail/49377759/
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var anagrams = strs
               .Aggregate(
                       new Dictionary<String, List<String>>(),
                       (acc, x) => {
                            var hash = new String(x.OrderBy(y => y).ToArray());
                            if (!acc.ContainsKey(hash))
                            {
                                acc[hash] = new List<String>();
                            }

                            acc[hash].Add(x);
                            return acc;
                       })
               .Values
               .Select(x => x.OrderBy(y => y).ToList())
               .ToList();

        var result = new List<IList<String>>();
        result.AddRange(anagrams);
        return result;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, new Solution().GroupAnagrams(new [] { "eat", "tea", "tan", "ate", "nat", "bat" }).Select(x => String.Join(", ", x))));
    }
}
