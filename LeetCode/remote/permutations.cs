// https://leetcode.com/problems/permutations/
//
//  Given a collection of numbers, return all possible permutations.
//
//  For example,
//  [1,2,3] have the following permutations:
//  [1,2,3], [1,3,2], [2,1,3], [2,3,1], [3,1,2], and [3,2,1]. 
//
// 
// Submission Details
// 25 / 25 test cases passed.
//  Status: Accepted
//  Runtime: 556 ms
//      
//      Submitted: 10 hours, 52 minutes ago
//

using System;
using System.Collections.Generic;

public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        var result = new List<IList<int>>();
        if (nums.Length < 2)
        {
            result.Add(nums.ToList());
            return result;
        }

        var number = nums.First();
        foreach (var prev in Permute(nums.Skip(1).ToArray()).ToList())
        {
            result.AddRange(Enumerable
                             .Range(0, nums.Length)
                             .Select(x => {
                                var newList = new List<int>(prev);
                                newList.Insert(x, number);
                                return newList;                                
                             }));
        }

        return result;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine), Permute(new [] { 1, 2, 3 }).Select(x => String.Join(", ", x)));
    }
}
