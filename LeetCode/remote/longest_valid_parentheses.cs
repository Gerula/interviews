//  https://leetcode.com/problems/longest-valid-parentheses/
//
//  Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.
//
//  For "(()", the longest valid parentheses substring is "()", which has length = 2.
//
//  Another example is ")()())", where the longest valid parentheses substring is "()()", which has length = 4. 

using System;

public class Solution {
    //  
    //  Submission Details
    //  229 / 229 test cases passed.
    //      Status: Accepted
    //      Runtime: 128 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public int LongestValidParentheses(string s) {
        var dp = new int[s.Length];
        var longest = 0;
        for (var i = 1; i < s.Length; i++)
        {
            if (s[i] == '(') 
            {
                continue;
            }

            if (s[i - 1] == '(')
            {
                dp[i] = (i > 1 ? dp[i - 2] : 0) + 2;
            }
            else if (i - dp[i - 1] - 1 >= 0 && s[i - dp[i - 1] - 1] == '(')
            {
                dp[i] = dp[i - 1] + 2 + (i - dp[i - 1] - 2 >= 0 ? dp[i - dp[i - 1] - 2] : 0);
            }

            longest = Math.Max(longest, dp[i]);
        }

        return longest;
    }
    
    //  https://leetcode.com/submissions/detail/59848735/
    //
    //  Submission Details
    //  229 / 229 test cases passed.
    //      Status: Accepted
    //      Runtime: 152 ms
    //          
    //          Submitted: 0 minutes ago
    //  Warm fuzzy feeling that I got this right at the first try. Got it actually almost identical LoL coding olympics
    public class Solution {
        public int LongestValidParentheses(string s) {
            var longest = new int[s.Length];
            var max = 0;
            for (var i = 1; i < s.Length; i++)
            {
                if (s[i] != ')')
                {
                    continue;
                }
                
                if (s[i - 1] == '(')
                {
                    longest[i] = 2 + (i >= 2 ? longest[i - 2] : 0); 
                }
                else if (i - 1 - longest[i - 1] >= 0 && s[i - 1 - longest[i - 1]] == '(')
                {
                    longest[i] = longest[i - 1] + 2 + (i - 2 - longest[i - 1] < 0 ? 0 : longest[i - 2 - longest[i - 1]]);
                }
                
                max = Math.Max(longest[i], max);
            }
            
            return max;
        }
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.LongestValidParentheses("(()"));
        Console.WriteLine(s.LongestValidParentheses("())"));
        Console.WriteLine(s.LongestValidParentheses("()(())"));
        Console.WriteLine(s.LongestValidParentheses(")()())"));
    }
}
