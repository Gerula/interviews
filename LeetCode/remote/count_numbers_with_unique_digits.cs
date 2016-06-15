//  https://leetcode.com/problems/count-numbers-with-unique-digits/
//  Given a non-negative integer n, count all numbers with unique digits, x, where 0 ≤ x < 10n.
//
//  Example:
//  Given n = 2, return 91. (The answer should be the total numbers in the range of 0 ≤ x < 100, excluding [11,22,33,44,55,66,77,88,99])
//
//  https://leetcode.com/submissions/detail/64307058/
//
//  Submission Details
//  9 / 9 test cases passed.
//      Status: Accepted
//      Runtime: 62 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    public int CountNumbersWithUniqueDigits(int n) {
        if (n == 0) {
            return 1;
        }
        
        var dp = new int[Math.Max(n, 2) + 1];
        dp[0] = 0;
        dp[1] = 10;
        dp[2] = 81;

        for (var i = 3; i <= n; i++) {
            dp[i] = dp[i - 1] * (9 - i + 2);
        }
        
        var total = dp.Skip(1).Aggregate(
            new List<int> { dp[0] },
            (acc, x) => {
                acc.Add(acc.Last() + x);
                return acc;
            });

        return total[n];
    }
}
