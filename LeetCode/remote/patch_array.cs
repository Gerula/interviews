//  https://leetcode.com/problems/patching-array/
//
//  Given a sorted positive integer array nums and an integer n, add/patch elements to the array such that any number in range [1, n] inclusive can be formed by the sum of some elements in the array. Return the minimum number of patches required.
//
//  Example 1:
//  nums = [1, 3], n = 6
//  Return 1.
//
//  Combinations of nums are [1], [3], [1,3], which form possible sums of: 1, 3, 4.
//  Now if we add/patch 2 to nums, the combinations are: [1], [2], [3], [1,3], [2,3], [1,2,3].
//  Possible sums are 1, 2, 3, 4, 5, 6, which now covers the range [1, 6].
//  So we only need 1 patch.

using System;
using System.Collections.Generic;

public class Solution {
    public int MinPatches(int[] nums, int n) 
    {
        return Patches(nums, n).Count;
    }

    public List<int> Patches(int[] nums, int n)
    {
        var sum = 0;
        var i = 0;
        var patches = new List<int>();
        while (i < nums.Length)
        {
            while (sum + 1 < nums[i] && i < n)
            {
                sum += sum + 1;
                patches.Add(sum);
            }

            sum += nums[i++];
        }

        while (sum < n)
        {
            sum++;
            patches.Add(sum);
        }

        return patches;
    }

    static void Main()
    {
        var s = new Solution();
        foreach (var x in new [] {
                    Tuple.Create(new [] { 1, 3 }, 6),
                    Tuple.Create(new [] { 1, 5, 10 }, 20),
                    Tuple.Create(new [] { 1, 2, 2 }, 5)
                })
        {
            Console.WriteLine(
                    "[{0} -- {1}] - [{2}]",
                    String.Join(", ", x.Item1),
                    x.Item2,
                    String.Join(", ", s.Patches(x.Item1, x.Item2)));
        }
    }
}
