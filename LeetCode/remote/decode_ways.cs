//  https://leetcode.com/problems/decode-ways/
//
//   A message containing letters from A-Z is being encoded to numbers using the following mapping:
//
//   'A' -> 1
//   'B' -> 2
//   ...
//   'Z' -> 26
//
//   Given an encoded message containing digits, determine the total number of ways to decode it.
//
//   For example,
//   Given encoded message "12", it could be decoded as "AB" (1 2) or "L" (12).
//
//   The number of ways decoding "12" is 2. 

using System;
using System.Collections.Generic;

public class Solution {
    //  
    //  Submission Details
    //  259 / 259 test cases passed.
    //      Status: Accepted
    //      Runtime: 144 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  Yay! Did this all by myself after fishing out all the fucking corner-cases from the OJ
    //  Remember kids, CORNER CASES!!
    public int NumDecodings(string s) {
        var dp = new int[s.Length + 1];
        if (String.IsNullOrEmpty(s))
        {
            return 0;
        }

        dp[s.Length] = 1;
        for (var i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == '0')
            {
                dp[i] = 0;
            }
            else
            {
                var nextTwo = i + 1 < s.Length ? int.Parse(s.Substring(i, 2)) : 0;
                dp[i] = dp[i + 1] + (0 < nextTwo && nextTwo < 27 ? dp[i + 2] : 0);
            }
        }

        return dp[0];
    }

    //  https://leetcode.com/submissions/detail/64023392/
    //
    //  Submission Details
    //  259 / 259 test cases passed.
    //      Status: Accepted
    //      Runtime: 128 ms
    //          
    //          Submitted: 0 minutes ago
    public int NumDecodings(string s) {
        if (String.IsNullOrWhiteSpace(s)) {
            return 0;
        }
        
        var ways = new int[s.Length + 1];
        ways[s.Length] = 1;
        
        for (var i = s.Length - 1; i >= 0; i--) {
            if (s[i] == '0') {
                continue;
            }
            
            ways[i] = ways[i + 1];
            
            if (i < s.Length - 1 && int.Parse(s.Substring(i, 2)) < 27)
            {
                ways[i] += ways[i + 2];
            }
        }
        
        return ways[0];
    }

    static void Main()
    {
        var s = new Solution();
        // 1 2 2 6
        // 12 2 6
        // 12 26
        // 1 2 26
        // 1 22 6
        foreach (var t in new [] { "12", "1226", "", "1", "00", "01" })
        {
            Console.WriteLine("{0} - {1}", t, s.NumDecodings(t));
        }
    }
}
