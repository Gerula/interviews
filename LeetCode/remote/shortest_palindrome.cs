//  https://leetcode.com/problems/shortest-palindrome/
//
//   Given a string S, you are allowed to convert it to a palindrome by adding characters in front of it. Find and return the shortest palindrome you can find by performing this transformation.
//
//   For example:
//
//   Given "aacecaaa", return "aaacecaaa".
//
//   Given "abcd", return "dcbabcd".

using System;
using System.Linq;

public class Solution {
    //  
    //  Submission Details
    //      Status: Accepted
    //      Runtime: 472 ms
    //          
    //          Submitted: 4 months, 1 week ago
    //
    public string ShortestPalindrome(string s) {
        var palindromeIndex = 0;
        for (var i = 1; i < s.Length; i++)
        {
            if (IsPalindrome(s, 0, i))
            {
                palindromeIndex = i;
            }
        }

        return new String(s.Substring(palindromeIndex + 1, s.Length - palindromeIndex - 1).Reverse().ToArray()) + s;
    }

    public bool IsPalindrome(String s, int i, int j)
    {
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
        var s = new Solution();
        foreach (var str in new [] { "abcd", "aacecaaa"})
        {
            Console.WriteLine("{0} - {1}", str, s.ShortestPalindrome(str));
        }
    }
}
