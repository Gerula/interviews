// https://leetcode.com/problems/range-sum-query-immutable/
//
// Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.
//
// Example:
//
// Given nums = [-2, 0, 3, -5, 2, -1]
//
// sumRange(0, 2) -> 1
// sumRange(2, 5) -> -1
// sumRange(0, 5) -> -3
//

using System;
using System.Collections.Generic;

public class NumArray {
    Dictionary<int, int> Pre = new Dictionary<int, int>();

    public NumArray(int[] nums) {
        Pre[-1] = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            Pre[i] = Pre[i - 1] + nums[i];                
        }
    }

    public int SumRange(int i, int j) {
        return Pre[j] - Pre[i - 1];
    }

    static void Main()
    {
        var n = new NumArray(new int [] {-2, 0, 3, -5, 2, -1});
        Console.WriteLine(n.SumRange(0, 2));
        Console.WriteLine(n.SumRange(2, 5));
        Console.WriteLine(n.SumRange(0, 5));
    }
}
