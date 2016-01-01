//  https://leetcode.com/problems/subsets/
//
//   Given a set of distinct integers, nums, return all possible subsets.
//
//   Note:
//
//       Elements in a subset must be in non-descending order.
//           The solution set must not contain duplicate subsets.
//

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        var result = new List<IList<int>>();
        var max = 1 << nums.Length;
        for (var mask = 0; mask < max; mask++)
        {
            var local = new List<int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if ((1 << i & mask) != 0)
                {
                    local.Add(nums[i]);
                }
            }

            result.Add(local);
        }

        return result;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, new Solution().Subsets(new [] { 1, 2, 3 }).Select(x => String.Join(", ", x))));
    }
}

