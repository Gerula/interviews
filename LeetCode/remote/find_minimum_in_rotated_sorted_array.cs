//  https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/
//
//  Suppose a sorted array is rotated at some pivot unknown to you beforehand.
//
//  (i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).
//
//  Find the minimum element.
//
//  You may assume no duplicate exists in the array.

using System;

public class Solution {
    //  
    //  Submission Details
    //  146 / 146 test cases passed.
    //      Status: Accepted
    //      Runtime: 164 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public int FindMin(int[] nums) {
        var low = 0;
        var high = nums.Length - 1;
        while (low < high)
        {
            var mid = low + (high - low) / 2;
            if (nums[low] < nums[high])
            {
                return nums[low];
            }

            if (nums[mid] >= nums[low])
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }

        return nums[low];
    }

    //  https://leetcode.com/submissions/detail/60246275/
    //
    //  Submission Details
    //  146 / 146 test cases passed.
    //      Status: Accepted
    //      Runtime: 188 ms
    //          
    //          Submitted: 0 minutes ago
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
            else
            {
                high = mid;
            }
        }
        
        return nums[low];
    }  

    static void Main()
    {
        Console.WriteLine(new Solution().FindMin(new [] { 1, 2, 3, 4, 5, 6 }));
        Console.WriteLine(new Solution().FindMin(new [] { 3, 4, 5, 6, 0, 1, 2 }));
        Console.WriteLine(new Solution().FindMin(new [] { 5, 6, 0, 1, 2, 3, 4 }));
        Console.WriteLine(new Solution().FindMin(new [] { 2, 1 }));
    }
}
