//  https://leetcode.com/problems/word-break/
//
//   Given a string s and a dictionary of words dict,
//   determine if s can be segmented into a space-separated sequence of one or more dictionary words.
//
//   For example, given
//   s = "leetcode",
//   dict = ["leet", "code"].
//
//   Return true because "leetcode" can be segmented as "leet code". 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public bool WordBreak(string s, ISet<string> wordDict) {
        if (String.IsNullOrEmpty(s))
        {
            return true;
        }

        return wordDict.
               Aggregate(
                    false,
                    (acc, x) => acc || s.StartsWith(x) && WordBreak(s.Substring(x.Length), wordDict));
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.WordBreak("leetcode", new HashSet<String> { "leet", "code" }));
        Console.WriteLine(s.WordBreak("leetcode", new HashSet<String> { "leet", "cod" }));
    }
}
