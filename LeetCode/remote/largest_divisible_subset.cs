//  https://leetcode.com/problems/largest-divisible-subset/
//   Given a set of distinct positive integers, find the largest subset such that every pair (Si, Sj) of elements in this subset satisfies: Si % Sj = 0.
//
//   If there are multiple solutions, return any subset is fine. 

//  Fails a test..
public class Solution {
    public int[] LargestDivisibleSubset(int[] nums) {
        if (nums.Length < 2) {
            return nums;
        }
        
        var dp = new int[nums.Length];
        var prev = Enumerable.Repeat(-1, nums.Length).ToArray();
        var max = -1;
        for (var i = 1; i < nums.Length; i++) {
            for (var j = 0; j < i; j++) {
                if (nums[i] > nums[j] && 
                    nums[i] % nums[j] == 0 &&
                    dp[j] + 1 > dp[i])
                {
                    dp[i] = dp[j] + 1;
                    prev[i] = j;
                }
            }
            
            if (max == -1 || dp[i] > dp[max]) {
                max = i;
            }
        }
        
        var result = new LinkedList<int>();
        while (max != -1) {
            result.AddFirst(nums[max]);
            max = prev[max];
        }
        
        return result.ToArray();
    }
}
