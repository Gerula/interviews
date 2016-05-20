//  https://leetcode.com/problems/jump-game-ii/
//  Given an array of non-negative integers, you are initially positioned at the first index of the array.
//
//  Each element in the array represents your maximum jump length at that position.
//
//  Your goal is to reach the last index in the minimum number of jumps. 
//  https://leetcode.com/submissions/detail/59084918/
//  Submission Details
//  91 / 91 test cases passed.
//      Status: Accepted
//      Runtime: 180 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    public int Jump(int[] nums) {
        var edge = 1;
        var maxJump = nums[0];
        var count = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            edge--;
            maxJump--;
            if (edge < 0)
            {
                count++;
                edge = maxJump;
            }
            
            maxJump = Math.Max(maxJump, nums[i]);
        }
        
        return count;
    }
}

public class Solution {
    public int Jump(int[] nums) {
        var reach = 1;
        var maxReach = nums[0];
        var steps = 0;
        for (var i = 0; i < nums.Length; i++) 
        {
            reach--;
            maxReach--;
            if (reach < 0)
            {
                reach = maxReach;
                steps += 1;
            }
            
            maxReach = Math.Max(maxReach, nums[i]);
        }
        
        return steps;
    }
}
