//  https://leetcode.com/problems/longest-increasing-subsequence/
//   Given an unsorted array of integers, find the length of longest increasing subsequence.
//
//   For example,
//   Given [10, 9, 2, 5, 3, 7, 101, 18],
//   The longest increasing subsequence is [2, 3, 7, 101], therefore the length is 4.
//   Note that there may be more than one LIS combination, it is only necessary for you to return the length.
//
//   Your algorithm should run in O(n2) complexity. 
//   https://leetcode.com/submissions/detail/64550047/
//
//   Submission Details
//   22 / 22 test cases passed.
//      Status: Accepted
//      Runtime: 172 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    public int LengthOfLIS(int[] nums) {
        var dp = new int[nums.Length];
        var max = 0;
        for (var i = 0; i < nums.Length; i++) {
            dp[i] = 1;
            for (var j = 0; j < i; j++) {
                if (nums[i] > nums[j]) {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
            
            max = Math.Max(max, dp[i]);
        }
        
        return max;
    }
}
