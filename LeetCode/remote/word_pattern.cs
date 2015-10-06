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

    static void Main()
    {
        if (!WordPattern("abba", "dog cat cat dog"))
        {
            throw new Exception("U r dumb!");
        }

        if (WordPattern("abba", "dog cat cat fish"))
        {
            throw new Exception("U r dumb!");
        }
        
        if (WordPattern("aaaa", "dog cat cat dog"))
        {
            throw new Exception("U r dumb!");
        }
        
        if (WordPattern("abba", "dog dog dog dog"))
        {
            throw new Exception("U r dumb!");
        }

        Console.WriteLine("All good");
    }
}
