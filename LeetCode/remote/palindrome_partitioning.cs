//  https://leetcode.com/problems/palindrome-partitioning/
//
//   Given a string s, partition s such that every substring of the partition is a palindrome.
//
//   Return all possible palindrome partitioning of s.
//
//   For example, given s = "aab",
//   Return
//
//     [
//      ["aa","b"],
//      ["a","a","b"]
//     ]

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    //  
    //  Submission Details
    //  21 / 21 test cases passed.
    //      Status: Accepted
    //      Runtime: 668 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/50924368/
    //
    //  Can't believe this was accepted. It's slow as fuck because of all the Linq trickery
    public IList<IList<string>> Partition(string s) {
        var result = new List<IList<string>>();
        if (String.IsNullOrEmpty(s))
        {
            return result;
        }

        if (IsPalindrome(s))
        {
            result.Add(new List<string> { s });
        }

        result.AddRange(
                Enumerable
                .Range(1, s.Length)
                .Select(x => s.Substring(0, x))
                .Where(x => IsPalindrome(x))
                .SelectMany(x => Partition(s.Substring(x.Length)).Select(y => new List<String> { x }.Concat(y).ToList()))
                .Where(x => x.Count > 1));
        return result;
    }

    public bool IsPalindrome(string s)
    {
        var i = 0;
        var j = s.Length - 1;
        while (i < j)
        {
            if (s[i++] != s[j--])
            {
                return false;
            }
        }

        return true;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, new Solution().Partition("aab").Select(x => String.Join(", ", x))));
    }
}
