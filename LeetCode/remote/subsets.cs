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
    //  
    //  Submission Details
    //  19 / 19 test cases passed.
    //      Status: Accepted
    //      Runtime: 584 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        var result = new List<IList<int>>();
        Subsets(nums, 0, result, new List<int>());
        return result.Concat(new List<IList<int>>() { new List<int>() }).ToList();
    }

    public void Subsets(int[] nums, int position, List<IList<int>> result, List<int> partial)
    {
        if (position == nums.Length)
        {
            return;
        }

        for (var i = position; i < nums.Length; i++)
        {
            if (i != position && nums[i] == nums[i - 1]) 
            {
                continue;
            }

            partial.Add(nums[i]);
            result.Add(new List<int>(partial));
            Subsets(nums, i + 1, result, partial);
            partial.RemoveAt(partial.Count - 1);
        }
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, new Solution().SubsetsWithDup(new [] { 1, 2, 2 }).Select(x => String.Join(", ", x))));
        Console.WriteLine(String.Join(Environment.NewLine, new Solution().SubsetsWithDup(new [] { 0 }).Select(x => String.Join(", ", x))));
        Console.WriteLine(String.Join(Environment.NewLine, new Solution().SubsetsWithDup(new [] { 1, 1 }).Select(x => String.Join(", ", x))));
    }
}
