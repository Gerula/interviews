//  https://leetcode.com/problems/jump-game/
//   Given an array of non-negative integers, you are initially positioned at the first index of the array.
//
//   Each element in the array represents your maximum jump length at that position.
//
//   Determine if you are able to reach the last index. 
//   https://leetcode.com/submissions/detail/59083963/
//
//   Submission Details
//   72 / 72 test cases passed.
//      Status: Accepted
//      Runtime: 184 ms
//          
//          Submitted: 0 minutes ago

public class Solution {
    public bool CanJump(int[] nums) {
        var maxJump = 1;
        for (var i = 0; i < nums.Length; i++)
        {
            maxJump -= 1;
            if (maxJump < 0)
            {
                return false;
            }
            
            maxJump = Math.Max(maxJump, nums[i]);
        }
        
        return true;
    }

    //  
    //  Submission Details
    //  72 / 72 test cases passed.
    //      Status: Accepted
    //      Runtime: 164 ms
    //          
    //          Submitted: 0 minutes ago
    //  https://leetcode.com/submissions/detail/62751025/
    public bool CanJump(int[] nums) {
        var maxReach = 1;
        for (var i = 0; i < nums.Length; i++) {
            maxReach--;
            if (maxReach < 0) {
                return false;
            }
            
            maxReach = Math.Max(maxReach, nums[i]);
        }
        
        return true;
    }
}
