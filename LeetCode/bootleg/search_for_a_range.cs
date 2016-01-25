//  https://leetcode.com/problems/search-for-a-range/
//
//  Given a sorted array of integers, find the starting and ending position of a given target value.
//
//  Your algorithm's runtime complexity must be in the order of O(log n).
//
//  If the target is not found in the array, return [-1, -1].
//
//  For example,
//  Given [5, 7, 7, 8, 8, 10] and target value 8,
//  return [3, 4]. 

using System;

public class Solution {
    //  
    //  Submission Details
    //  81 / 81 test cases passed.
    //      Status: Accepted
    //      Runtime: 496 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/51687811/
    //
    //  You are here!
    //  Your runtime beats 69.49% of csharp submissions.
    public int[] SearchRange(int[] nums, int target) {
        var result = new int[2];
        result[0] = Search(nums, target, left: true);
        if (result[0] == -1)
        {
            result[1] = -1;
            return result;
        }

        result[1] = Search(nums, target, left: false);
        return result;
    }

    public int Search(int[] nums, int target, bool left)
    {
        var low = 0;
        var high = nums.Length - 1;
        var index = -1;
        while (low <= high)
        {
            var mid = low + (high - low) / 2;
            if (nums[mid] == target)
            {
                index = mid;
                if (left)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }

                continue;
            }

            if (nums[mid] < target)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return index;
    }

    static void Main()
    {
        Console.WriteLine(String.Format("[{0}]", String.Join(", ", new Solution().SearchRange(new [] { 5, 7, 7, 8, 8, 10 }, 8))));
        Console.WriteLine(String.Format("[{0}]", String.Join(", ", new Solution().SearchRange(new [] { 1 }, 1))));
    }
}
