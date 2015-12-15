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

    //  
    //  Submission Details
    //  117 / 117 test cases passed.
    //      Status: Accepted
    //      Runtime: 128 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public String ShortestPalindrome2(string s) 
    {
        long _base = 19;
        if (String.IsNullOrEmpty(s))
        {
            return s;
        }

        var hashA = new long[s.Length];
        var hashB = new long[s.Length];
        hashA[0] = hashB[0] = (long) s[0];
        var mul = _base;
        for (var i = 1; i < s.Length; i++)
        {
            hashA[i] = hashA[i - 1] * _base + s[i];
            hashB[i] = hashB[i - 1] + s[i] * mul;
            mul *= _base;
        }

        for (var i = s.Length - 1; i >= 0; i--)
        {
            if (EqualHash(s, hashA[i], hashB[i], i))
            {
                return new String(s.Substring(i + 1, s.Length - i - 1).Reverse().ToArray()) + s;
            }
        }

        return String.Empty;
    }

    public bool EqualHash(String a, long hashA, long hashB, int length)
    {
        if (hashA != hashB)
        {
            return false;
        }

        var i = 0;
        var j = length;
        while (length > 0)
        {
            length--;
            if (a[i++] != a[j--])
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
            Console.WriteLine("{0} - {1}", str, s.ShortestPalindrome2(str));
        }
    }
}
