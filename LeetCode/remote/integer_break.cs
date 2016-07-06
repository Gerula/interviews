//  Don't know why I haven't solved this until today..
//  https://leetcode.com/problems/integer-break/
//   Given a positive integer n, break it into the sum of at least two positive integers and maximize the product of those integers. Return the maximum product you can get.
//
//   For example, given n = 2, return 1 (2 = 1 + 1); given n = 10, return 36 (10 = 3 + 3 + 4).
//
//   Note: You may assume that n is not less than 2 and not larger than 58. 
//   https://leetcode.com/submissions/detail/66317712/
//
//   Submission Details
//   50 / 50 test cases passed.
//      Status: Accepted
//      Runtime: 52 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    public int IntegerBreak(int n) {
        var dp = new int[n + 1];
        dp[0] = 0;
        dp[1] = 1;
        dp[2] = 1;
        for (var i = 3; i <= n; i++)
        {
            dp[i] = 0;
            for (var j = 1; j < i; j++)
            {
                if (Math.Max(dp[i - j], i - j) * j > dp[i]) {
                    dp[i] = Math.Max(dp[i - j], i - j) * j;
                }
            }
        }
        
        return dp[n];
    }
}
