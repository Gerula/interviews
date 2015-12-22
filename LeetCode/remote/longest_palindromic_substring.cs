//  https://leetcode.com/problems/longest-palindromic-substring/
//
//  Given a string S, find the longest palindromic substring in S.
//  You may assume that the maximum length of S is 1000, and there exists one unique longest palindromic substring.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class Solution {
    //  
    //  Submission Details
    //  88 / 88 test cases passed.
    //      Status: Accepted
    //      Runtime: 128 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          Your runtime beats 95.71% of csharp submissions.
    //          Wow! Holy shit.
    public string LongestPalindrome(string s) {
        var start = -1;
        var length = 0;
        for (var i = 0; i < s.Length; i++)
        {
            var odd = CheckPalindrome(s, i, i);
            var even = CheckPalindrome(s, i, i + 1);
            if (odd * 2 - 1 > length)
            {
                length = odd * 2 - 1;
                start = i - odd + 1;
            }
            if (even * 2 > length)
            {
                length = even * 2;
                start = i - even + 1;
            }
        }

        return s.Substring(start, length);
    }

    //  You are here!
    //  Your runtime beats 1.43% of csharp submissions.
    //
    //  HAHAHA - Parallel
    public string LongestPalindrome2(string s) {
        var start = -1;
        var length = 0;
        Parallel.ForEach(Enumerable.Range(0, s.Length), i => 
        {
            var odd = CheckPalindrome(s, i, i);
            var even = CheckPalindrome(s, i, i + 1);
            if (odd * 2 - 1 > length)
            {
                length = odd * 2 - 1;
                start = i - odd + 1;
            }
            if (even * 2 > length)
            {
                length = even * 2;
                start = i - even + 1;
            }
        });

        return s.Substring(start, length);
    }

    public int CheckPalindrome(String s, int left, int right)
    {
        var length = 0;
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;
            right++;
            length++;
        }

        return length;
    }

    static void Main()
    {
        Console.WriteLine(new Solution().LongestPalindrome("abcdcba234"));
        Console.WriteLine(new Solution().LongestPalindrome("abccba2"));
        Console.WriteLine(new Solution().LongestPalindrome2("abcdcba234"));
        Console.WriteLine(new Solution().LongestPalindrome2("abccba2"));
    }
}
