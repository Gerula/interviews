//  https://leetcode.com/problems/largest-divisible-subset/
//  https://leetcode.com/submissions/detail/84838223/
//
//  Submission Details
//  32 / 32 test cases passed.
//      Status: Accepted
//      Runtime: 439 ms
//          Submitted: 1 minute ago

public class Solution {
    public int[] LargestDivisibleSubset(int[] nums) {
        if (nums.Length < 2) {
            return nums;
        }

        var dp = Enumerable.Repeat(1, nums.Length).ToArray();
        var prev = Enumerable.Repeat(-1, nums.Length).ToArray();
        var max = -1;
        var maxIdx = -1;
        Array.Sort(nums);
        for (var i = 1; i < nums.Length; i++) {
            for (var j = i - 1; j >= 0; j--) {
                if (nums[i] % nums[j] == 0 &&
                    dp[j] + 1 > dp[i])
                {
                    dp[i] = dp[j] + 1;
                    prev[i] = j;
                }
            }

            if (dp[i] > max) 
            {
                max = dp[i];
                maxIdx = i;
            }
        }

        var result = new int[max];
        for (var i = max - 1; i >= 0; i--) {
            result[i] = nums[maxIdx];
            maxIdx = prev[maxIdx];
        }

        return result;
    }
}
