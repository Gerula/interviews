//  https://leetcode.com/problems/minimum-size-subarray-sum/
//
//   Given an array of n positive integers and a positive integer s,
//   find the minimal length of a subarray of which the sum ≥ s.
//   If there isn't one, return 0 instead.
//
//   For example, given the array [2,3,1,2,4,3] and s = 7,
//   the subarray [4,3] has the minimal length under the problem constraint. 

using System;

public class Solution {
    //  https://leetcode.com/submissions/detail/49248913/
    //
    //
    //  Submission Details
    //  14 / 14 test cases passed.
    //      Status: Accepted
    //      Runtime: 164 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public int MinSubArrayLen(int s, int[] nums) {
        var len = int.MaxValue;
        var sum = 0;
        var low = 0;
        var high = 0;
        while (high < nums.Length)
        {
            sum += nums[high];
            while (sum >= s)
            {
                var newLen = high - low + 1;
                len = Math.Min(newLen, len);
                sum -= nums[low++];
            }

            high++;
        }

        return len == int.MaxValue ? 0 : len;
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.MinSubArrayLen(7, new [] { 2,3,1,2,4,3 }));
    }
}

//  https://leetcode.com/submissions/detail/58672848/
//  
//  Submission Details
//  14 / 14 test cases passed.
//      Status: Accepted
//      Runtime: 152 ms
//          
//          Submitted: 0 minutes ago
//  You are here!
//  Your runtime beats 80.43% of csharpsubmissions.
public class Solution {
    public int MinSubArrayLen(int s, int[] nums) {
        var sum = 0;
        var left = 0;
        var minLength = int.MaxValue;
        for (var right = 0; right < nums.Length; right++)
        {
            sum += nums[right];
            while (sum >= s && left <= right)
            {
                minLength = right - left + 1 < minLength ? 
                                right - left + 1 : 
                                minLength;
                                
                sum -= nums[left];
                left++;
            }
        }
        
        return minLength == int.MaxValue ? 0 : minLength;
    }
}
