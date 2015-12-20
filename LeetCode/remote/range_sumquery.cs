//  https://leetcode.com/problems/range-sum-query-mutable/
//
//  Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.
//  The update(i, val) function modifies nums by updating the element at index i to val.
//
//  Example:
//
//  Given nums = [1, 3, 5]
//
//  sumRange(0, 2) -> 9
//  update(1, 2)
//  sumRange(0, 2) -> 8

using System;

public class NumArray {
    public NumArray(int[] nums) {

    }

    public void Update(int i, int val) {

    }

    public int SumRange(int i, int j) {
        return 1; 
    }
}
//          0 []
//         /|\ \
//       /  |  \ \
//      1   2   4 8
//
//
//      10 =   1 0 1 0 = 2 ^ 1 + 2 ^ 3
//      11 =           = 2 ^ 0 + 2 ^ 1 + 2 ^ 3
//

class Program
{
    static void Main()
    {
        NumArray numArray = new NumArray(new [] { 1, 2, 5, 10, 6, 7 });
        Console.WriteLine(numArray.SumRange(0, 1));
        numArray.Update(1, 10);
        Console.WriteLine(numArray.SumRange(1, 5));
    }
}
