//  https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii/
//
//
//      Follow up for "Find Minimum in Rotated Sorted Array":
//          What if duplicates are allowed?
//
//              Would this affect the run-time complexity? How and why?
//
//              Suppose a sorted array is rotated at some pivot unknown to you beforehand.
//  https://leetcode.com/submissions/detail/59768811/
//
//  Submission Details
//  189 / 189 test cases passed.
//      Status: Accepted
//      Runtime: 156 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    public int FindMin(int[] nums) {
        var low = 0;
        var high = nums.Length - 1;
        while (low < high)
        {
            var mid = low + (high - low) / 2;
            if (nums[mid] > nums[high])
            {
                low = mid + 1;
            } 
            else if (nums[mid] < nums[high])
            {
                high = mid;
            }
            else
            {
                high--;
            }
        }
        
        return nums[low];
    }
}
