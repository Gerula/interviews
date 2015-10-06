// https://leetcode.com/problems/word-pattern/
//
// Given a pattern and a string str, find if str follows the same pattern.
//
// Examples:
//
//  pattern = "abba", str = "dog cat cat dog" should return true.
//  pattern = "abba", str = "dog cat cat fish" should return false.
//  pattern = "aaaa", str = "dog cat cat dog" should return false.
//  pattern = "abba", str = "dog dog dog dog" should return false.

using System;
using System.Collections.Generic;
using System.Linq;

class Program 
{
    // 
    // Submission Details
    // 23 / 23 test cases passed.
    //  Status: Accepted
    //  Runtime: 120 ms
    //      
    //      Submitted: 0 minutes ago
    //      
    public static bool WordPattern(string pattern, string str) 
    {
        var words = str.Split(new [] {" "}, StringSplitOptions.RemoveEmptyEntries);
        return pattern.Select(x => pattern.IndexOf(x)).SequenceEqual(words.Select(y => Array.IndexOf(words, y))); 
    }

    // 23 / 23 test cases passed.
    //  Status: Accepted
    //  Runtime: 128 ms <-- Yeah faster my ass.
    //      
    //      Submitted: 0 minutes ago
    //
    public static bool WordPatternFast(string pattern, string str) 
    {
        var hash = new Dictionary<char, String>();
        var seen = new HashSet<String>();
        var words = str.Split(new [] {" "}, StringSplitOptions.RemoveEmptyEntries);
        if (pattern.Length != words.Length)
        {
            return false;
        }

        for (int i = 0; i < pattern.Length; i++)
        {
            if (hash.ContainsKey(pattern[i]))
            {
                if (hash[pattern[i]] != words[i])
                {
                    return false;
                }
            }
            else
            {
                if (seen.Contains(words[i]))
                {
                    return false;
                }
                
                seen.Add(words[i]);
                hash[pattern[i]] = words[i];
            }
        }

        return true;
    }

    static void Main()
    {
        if (!WordPatternFast("abba", "dog cat cat dog"))
        {
            throw new Exception("U r dumb!");
        }

        if (WordPatternFast("abba", "dog cat cat fish"))
        {
            throw new Exception("U r dumb!");
        }
        
        if (WordPatternFast("aaaa", "dog cat cat dog"))
        {
            throw new Exception("U r dumb!");
        }
        
        if (WordPatternFast("abba", "dog dog dog dog"))
        {
            throw new Exception("U r dumb!");
        }

        Console.WriteLine("All good");
    }
}
