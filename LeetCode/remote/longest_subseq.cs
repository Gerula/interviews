// https://leetcode.com/problems/longest-increasing-subsequence/
//
//  Given an unsorted array of integers, find the length of longest increasing subsequence.
//
//  For example,
//  Given [10, 9, 2, 5, 3, 7, 101, 18],
//  The longest increasing subsequence is [2, 3, 7, 101], therefore the length is 4. Note that there may be more than one LIS combination, it is only necessary for you to return the length.
//
//  Your algorithm should run in O(n2) complexity. 
//
// 
// Submission Details
// 22 / 22 test cases passed.
//  Status: Accepted
//  Runtime: 200 ms
//      
//      Submitted: 0 minutes ago
//

using System;
using System.Linq;

public class Solution {
    public static int LengthOfLIS(int[] nums) 
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        var subseq = Enumerable.Repeat(1, nums.Length).ToArray();
        for (int i = 1; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[j] < nums[i] && subseq[i] < subseq[j] + 1)
                {
                    subseq[i] = subseq[j] + 1;
                }
            }
        }

        return subseq.Max();
    }

    static void Main()
    {
        Console.WriteLine(LengthOfLIS(new [] {10, 9, 2, 5, 3, 7, 101, 18}));
    }
}
