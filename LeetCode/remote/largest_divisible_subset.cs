//  https://leetcode.com/problems/largest-divisible-subset/
//   Given a set of distinct positive integers, find the largest subset such that every pair (Si, Sj) of elements in this subset satisfies: Si % Sj = 0.
//
//   If there are multiple solutions, return any subset is fine. 

//  https://leetcode.com/submissions/detail/65468755/
//
//  Submission Details
//  29 / 29 test cases passed.
//      Status: Accepted
//      Runtime: 544 ms
//          
//          Submitted: 0 minutes ago
//
public class Solution {
    public int[] LargestDivisibleSubset(int[] nums) {
        if (nums.Length < 2) {
            return nums;
        }
        
        Array.Sort(nums);
        var dp = Enumerable.Repeat(1, nums.Length).ToArray();
        var prev = Enumerable.Repeat(-1, nums.Length).ToArray();
        var max = -1;
        var maxIdx = -1;
        for (var i = 1; i < nums.Length; i++) {
            for (var j = 0; j < i; j++) {
                if (nums[i] % nums[j] == 0 &&
                    dp[j] + 1 >= dp[i])
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
    
        Console.WriteLine(max);
        var result = new int[max];
        for (var i = max - 1; i >= 0; i--) {
            result[i] = nums[maxIdx];
            maxIdx = prev[maxIdx];
        }
        
        return result;
    }
}
