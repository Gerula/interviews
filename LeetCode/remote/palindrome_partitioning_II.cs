// https://leetcode.com/problems/palindrome-partitioning-ii/
//
//  Given a string s, partition s such that every substring of the partition is a palindrome.
//
//  Return the minimum cuts needed for a palindrome partitioning of s.
//
//  For example, given s = "aab",
//  Return 1 since the palindrome partitioning ["aa","b"] could be produced using 1 cut. 
//
// 
// Submission Details
// 28 / 28 test cases passed.
//  Status: Accepted
//  Runtime: 136 ms
//      
//      Submitted: 0 minutes ago
//

using System;

public class Solution {
    public int MinCut(string s) {
        var n = s.Length;
        var palindrome = new bool[n, n];
        var minCuts = new int[n + 1];

        for (var i = n - 2; i >=0; i--)
        {
            minCuts[i] = n - i - 1;
            for (var j = i; j < n; j++)
            {
                if (s[i] == s[j] && (j - i < 2 || palindrome[i + 1, j - 1]))
                {
                    palindrome[i, j] = true;
                    if (j == n - 1)
                    {
                        minCuts[i] = 0;
                    }
                    else
                    {
                        minCuts[i] = Math.Min(minCuts[i], 1 + minCuts[j + 1]);
                    }
                }
            }
        }

        return minCuts[0];
    }

    public static void Main()
    {
        Console.WriteLine(new Solution().MinCut("aab"));
        Console.WriteLine(new Solution().MinCut("bb"));
        Console.WriteLine(new Solution().MinCut("a"));
        Console.WriteLine(new Solution().MinCut("cdd"));
    }
}
