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
    //  
    //  Submission Details
    //  17 / 17 test cases passed.
    //      Status: Accepted
    //      Runtime: 256 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/52187017/
    //
    //  You are here!
    //  Your runtime beats 10.00% of csharp submissions.
    //  Of course.. Linq is slow.
    public int MaximumGap(int[] nums) {
        if (nums.Length < 2)
        {
            return 0;
        }

        var sorted = Radix(nums.ToList(), 1000000000);
        return sorted
               .Zip(
                  sorted
                  .Skip(1),
                  (a, b) => b - a)
               .Max();
    }

    public List<int> Radix(List<int> nums, int digit)
    {
        if (!nums.Any())
        {
            return nums;
        }

        var result = Enumerable
                     .Range(0, 10)
                     .Aggregate(
                             new Dictionary<int, List<int>>(),
                             (acc, x) => {
                                acc[x] = new List<int>();
                                return acc;
                             });

        foreach (var x in nums)
        {
            result[x / digit % 10].Add(x);
        }

        if (digit > 1)
        {
            result = result
                     .Keys
                     .Aggregate(
                             new Dictionary<int, List<int>>(),
                             (acc, x) => {
                                acc[x] = Radix(result[x], digit / 10);
                                return acc;
                             });
        }

        return Enumerable
               .Range(0, 10)
               .Aggregate(
                       new List<int>(),
                       (acc, x) => {
                            acc.AddRange(result[x]);
                            return acc;
                       })
               .ToList() ;
    }

    public IEnumerable<int> Radix2(IEnumerable<int> nums, int mask)
    {
        if (!nums.Any())
        {
            return nums;
        }

        var smaller = nums.Where(x => (x & mask) == 0);
        var larger = nums.Where(x => (x & mask) != 0);
        
        if (mask > 1)
        {
            smaller = Radix2(smaller, mask >> 1);
            larger = Radix2(larger, mask >> 1);
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
