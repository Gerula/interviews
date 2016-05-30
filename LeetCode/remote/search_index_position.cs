//  https://leetcode.com/problems/search-insert-position/
//  Vanilla binary search
//  https://leetcode.com/submissions/detail/62863160/
//
//  Submission Details
//  62 / 62 test cases passed.
//      Status: Accepted
//      Runtime: 168 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    public int SearchInsert(int[] nums, int target) {
        var low = 0;
        var high = nums.Length;
        while (low < high) 
        {
            var mid = low + (high - low) / 2;
            if (target <= nums[mid])
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }
        
        return low;
    }
}
