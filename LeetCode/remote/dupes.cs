//  https://leetcode.com/problems/remove-duplicates-from-sorted-array/

//  
//  Submission Details
//  161 / 161 test cases passed.
//      Status: Accepted
//      Runtime: 508 ms
//          
//          Submitted: 1 minute ago
//
public class Solution {
    public int RemoveDuplicates(int[] nums) {
        var hashSet = new HashSet<int>();
        var write = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (!hashSet.Contains(nums[i]))
            {
                nums[write++] = nums[i];
                hashSet.Add(nums[i]);
            }
        }
        
        return write;
    }
}
