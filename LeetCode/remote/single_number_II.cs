//  https://leetcode.com/problems/single-number-ii/
//
//   Given an array of integers, every element appears three times except for one. Find that single one. 

using System;

public class Solution {
    //  
    //  Submission Details
    //  11 / 11 test cases passed.
    //      Status: Accepted
    //      Runtime: 224 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          but why?


    public int SingleNumber(int[] nums) {
        int ones = 0;
        int twos = 0;
        foreach (var x in nums)
        {
            ones = (ones ^ x) & ~twos;
            twos = (twos ^ x) & ~ones;
        }

        return ones;
    }

    static void Main()
    {
        Console.WriteLine(new Solution().SingleNumber(new [] { 1, 1, 1, 2, 3, 2, 2, 3, 1, 3 }));
    }
}
