//  https://leetcode.com/problems/find-the-duplicate-number/
//
//   Given an array nums containing n + 1 integers where each integer is between 1 and n
//   (inclusive), prove that at least one duplicate number must exist.
//   Assume that there is only one duplicate number, find the duplicate one.
//
//   Note:
//
//       You must not modify the array (assume the array is read only).
//       You must use only constant, O(1) extra space.
//       Your runtime complexity should be less than O(n2).
//       There is only one duplicate number in the array, but it could be repeated more than once.

using System;
using System.Linq;

public class Solution {
    //  
    //  Submission Details
    //  53 / 53 test cases passed.
    //      Status: Accepted
    //      Runtime: 172 ms
    //          
    //          Submitted: 0 minutes ago
    //  
    //  https://leetcode.com/submissions/detail/49253089/
    public int FindDuplicate(int[] nums) {
        var low = 1;
        var high = nums.Length - 1;
        while (low < high)
        {
            var mid = low + (high - low) / 2;
            var lowFloor = low;
            var lowCeil = mid;
            var highFloor = + mid + 1;
            var highCeil = high;
            var lowCount = nums.Count(x => lowFloor <= x && x <= lowCeil);
            if (lowCount > lowCeil - lowFloor + 1)
            {
                low = lowFloor;
                high = lowCeil;
            }
            else
            {
                low = highFloor;
                high = highCeil;
            }
        }

        return low;
    }

    static void Main()
    {
        Console.WriteLine(new Solution().FindDuplicate(new [] { 1, 2, 2, 3, 4, 5 }));
        Console.WriteLine(new Solution().FindDuplicate(new [] { 1, 2, 3, 4, 4, 5, 4, 4 }));
        Console.WriteLine(new Solution().FindDuplicate(new [] { 1, 3, 4, 2, 2 }));
    }
}
