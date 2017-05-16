//  https://leetcode.com/problems/search-in-rotated-sorted-array/
//  Suppose a sorted array is rotated at some pivot unknown to you beforehand.
//
//  (i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).
//
//  You are given a target value to search. If found in the array return its index, otherwise return -1.
//  https://leetcode.com/submissions/detail/63192258/
//
//  Submission Details
//  194 / 194 test cases passed.
//      Status: Accepted
//      Runtime: 168 ms
//          
//          Submitted: 0 minutes ago
//
public class Solution {
    public int Search(int[] nums, int target) {
        var low = 0;
        var high = nums.Length - 1;
        while (low <= high) {
            var mid = low + (high - low) / 2;
            if (nums[mid] == target) {
                return mid;
            }
            
            if (nums[low] <= nums[mid]) {
                if (nums[low] <= target && target <= nums[mid]) {
                    high = mid - 1;
                } else {
                    low = mid + 1;
                }
            } else {
                if (nums[mid] <= target && target <= nums[high]) {
                    low = mid + 1;
                } else {
                    high = mid - 1;
                }
            }
        }
        
        return -1;
    }
}
