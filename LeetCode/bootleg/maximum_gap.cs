//  https://leetcode.com/problems/maximum-gap/
//
//  Given an unsorted array, find the maximum difference between the successive elements in its sorted form.
//
//  Try to solve it in linear time/space.
//
//  Return 0 if the array contains less than 2 elements.
//
//  You may assume all elements in the array are non-negative integers and fit in the 32-bit signed integer range.

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int MaximumGap(int[] nums) {
        var sorted = Radix(nums, 1 << 30);
        Console.WriteLine("Ninja sort : {0}", String.Join(", ", sorted));
        return sorted
               .Zip(
                 sorted
                 .Skip(1),
                 (a, b) => b - a)
               .Max();
    }

    public IEnumerable<int> Radix(IEnumerable<int> nums, int mask)
    {
        if (!nums.Any())
        {
            return nums;
        }

        var smaller = nums.Where(x => (x & mask) == 0);
        var larger = nums.Where(x => (x & mask) != 0);
        
        if (mask > 1)
        {
            smaller = Radix(smaller, mask >> 1);
            larger = Radix(larger, mask >> 1);
        }

        return smaller.Concat(larger);
    }

    static void Main()
    {
        var s = new Solution();
        var r = new Random();
        var times = r.Next(10);
        for (var i = 0; i < times; i++)
        {
            var count = r.Next(20);
            var nums = Enumerable
                       .Repeat(1, count)
                       .Select(x => r.Next(40))
                       .ToList();
            var sortedNums = nums.OrderBy(x => x);
            Console.WriteLine(
                    @"Raw: {0} {4} Sorted: {1} {4} Expected {2} Actual {3}",
                    String.Join(", ", nums),
                    String.Join(", ", sortedNums),
                    sortedNums
                    .Zip(
                        sortedNums
                        .Skip(1),
                        (x, y) => y - x)
                    .Max(),
                    s.MaximumGap(nums.ToArray()),
                    Environment.NewLine
                    );
        }
    }
}
