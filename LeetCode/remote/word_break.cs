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
    //  
    //  Submission Details
    //  32 / 32 test cases passed.
    //      Status: Accepted
    //      Runtime: 184 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/50902355/
    //
    public bool WordBreak(string s, ISet<string> wordDict) {
        var n = s.Length;
        var wb = new bool[n + 1];
        wb[0] = true;
        for (var i = 0; i < n; i++)
        {
            if (!wb[i])
            {
                continue;
            }

            var current = s.Substring(i);
            foreach (var word in wordDict)
            {
                if (current.StartsWith(word))
                {
                    wb[i + word.Length] = true;
                }
            }
        }

        return wb[n];
    }

    public bool WordBreakRec(string s, ISet<string> wordDict) {
        if (String.IsNullOrEmpty(s))
        {
            return true;
        }

        return wordDict.
               Aggregate(
                    false,
                    (acc, x) => acc || s.StartsWith(x) && WordBreakRec(s.Substring(x.Length), wordDict));
    }

    //  https://leetcode.com/submissions/detail/61354399/
    //
    //  Submission Details
    //  34 / 34 test cases passed.
    //      Status: Accepted
    //      Runtime: 196 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public bool WordBreak(string s, ISet<string> wordDict, Dictionary<string, bool> broken = null) {
        if (broken == null)
        {
            broken = new Dictionary<string, bool>();
        }
        
        if (broken.ContainsKey(s))
        {
            return broken[s];
        }
        
        if (String.IsNullOrWhiteSpace(s))
        {
            return true;
        }
        
        return broken[s] = wordDict
                           .Where(x => s.StartsWith(x))
                           .Select(x => WordBreak(s.Substring(x.Length), wordDict, broken))
                           .Any(x => x);
    }

    //  https://leetcode.com/submissions/detail/63800796/
    //
    //  Submission Details
    //  34 / 34 test cases passed.
    //      Status: Accepted
    //      Runtime: 196 ms
    //          
    //          Submitted: 1 minute ago
    //
    public bool WordBreak(string s, ISet<string> wordDict, Dictionary<String, bool> hash = null) {
        if (String.IsNullOrWhiteSpace(s)) {
            return true;
        }
        
        if (hash == null) {
            hash = new Dictionary<String, bool>();
        }
        
        if (!hash.ContainsKey(s)) {
            hash[s] = wordDict //   And the below boolean statement is exactly why we can't have nice things
                      .Any(x => !s.StartsWith(x) ? false : WordBreak(s.Substring(x.Length), wordDict, hash));
        }
        
        return hash[s];
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.WordBreakRec("leetcode", new HashSet<String> { "leet", "code" }));
        Console.WriteLine(s.WordBreak("leetcode", new HashSet<String> { "leet", "code" }));
        Console.WriteLine(s.WordBreakRec("leetcode", new HashSet<String> { "leet", "cod" }));
        Console.WriteLine(s.WordBreak("leetcode", new HashSet<String> { "leet", "cod" }));
    }
}
