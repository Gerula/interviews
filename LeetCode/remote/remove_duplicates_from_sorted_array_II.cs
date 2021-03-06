//  https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/
//
//   Follow up for "Remove Duplicates":
//   What if duplicates are allowed at most twice?
//
//   For example,
//   Given sorted array nums = [1,1,1,2,2,3],
//
//   Your function should return length = 5,
//   with the first five elements of nums being 1, 1, 2, 2 and 3.
//   It doesn't matter what you leave beyond the new length. 

//  https://leetcode.com/submissions/detail/53326968/
//
//
//  Submission Details
//  164 / 164 test cases passed.
//      Status: Accepted
//      Runtime: 496 ms
//          
//          Submitted: 0 minutes ago

public class Solution {
    public int RemoveDuplicates(int[] nums) {
        if (nums.Length < 3)
        {
            return nums.Length;
        }
        
        var write = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (write < 2 || nums[i] > nums[write - 2])
            {
                nums[write++] = nums[i];
            }
        }
        
        return write;
    }
}

//  https://leetcode.com/submissions/detail/59906831/
//  
//  Submission Details
//  164 / 164 test cases passed.
//      Status: Accepted
//      Runtime: 516 ms
//          
//          Submitted: 0 minutes ago
//
public class Solution {
    public int RemoveDuplicates(int[] nums) {
        if (nums.Length < 3)
        {
            return nums.Length;
        }
        
        var write = 0;
        foreach (var x in nums)
        {
            if (write > 1 && nums[write - 2] == x)
            {
                continue;
            }
            
            nums[write++] = x;
        }
        
        return write;
    }
}

//  https://leetcode.com/submissions/detail/66656225/
//
//  Submission Details
//  164 / 164 test cases passed.
//      Status: Accepted
//      Runtime: 508 ms
//          
//          Submitted: 1 minute ago
public class Solution {
    public int RemoveDuplicates(int[] nums) {
        var last = 0;
        for (var i = 0; i < nums.Length; i++) {
            if (last < 2 || nums[last - 2] != nums[i]) {
                nums[last++] = nums[i];
            }
        }
        
        return last;
    }
}
