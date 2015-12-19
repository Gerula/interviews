//  https://leetcode.com/problems/subsets-ii/
//
//   Given a collection of integers that might contain duplicates, nums, return all possible subsets.
//
//   Note:
//
//       Elements in a subset must be in non-descending order.
//           The solution set must not contain duplicate subsets.

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        if (nums.Length == 0)
        {
            return new List<IList<int>>();
        }
        var empty = new List<int>();

        return Enumerable
            .Range(0, nums.Length)
            .SelectMany(x => {
                var list = new List<IList<int>>();
                list.Add(new List<int> { nums[x] });
                foreach (var l in SubsetsWithDup(nums.Skip(x + 1).ToArray()).Where(y => y.Any()))
                {
                    list.Add(new List<int> { nums[x] }.Concat(l).ToList());
                }

                return list;
            })
            .Concat(new List<IList<int>>() { empty })
            .ToList();
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, new Solution().SubsetsWithDup(new [] { 1, 2, 2 }).Select(x => String.Join(", ", x))));
        Console.WriteLine(String.Join(Environment.NewLine, new Solution().SubsetsWithDup(new [] { 0 }).Select(x => String.Join(", ", x))));
    }
}
