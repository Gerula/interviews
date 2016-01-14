//  https://leetcode.com/problems/majority-element/
//
//  Given an array of size n, find the majority element.
//  The majority element is the element that appears more than ⌊ n/2 ⌋ times.
//
//  You may assume that the array is non-empty and the majority element always exist in the array.

using System;
using System.Linq;

public class Solution {
    //  
    //  Submission Details
    //  42 / 42 test cases passed.
    //      Status: Accepted
    //      Runtime: 180 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/50634819/
    //
    public int MajorityElement(int[] nums) {
        var count = 1;
        return nums.Aggregate((acc, x) => {
                    count += acc == x ? 1 : -1;

                    if (count == 0)
                    {
                        acc = x;
                        count = 1;
                    }

                    return acc;
                });
    }

    static void Main()
    {
        var s = new Solution();
        var random = new Random();
        Console.WriteLine(s.MajorityElement(Enumerable.Repeat(1, 6).Concat(Enumerable.Repeat(1, 4).Select(x => random.Next(10))).ToArray()));
    }
}
