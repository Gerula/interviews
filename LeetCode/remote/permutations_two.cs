//  https://leetcode.com/problems/permutations/
//
//   Given a collection of distinct numbers, return all possible permutations.
//
//   For example,
//   [1,2,3] have the following permutations:
//
//   [1,2,3],
//   [1,3,2],
//   [2,1,3],
//   [2,3,1],
//   [3,1,2],
//   [3,2,1]. 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    //  
    //  Submission Details
    //  25 / 25 test cases passed.
    //      Status: Accepted
    //      Runtime: 600 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/problems/permutations/
    //
    public IList<IList<int>> Permute(int[] nums) {
        var result = new List<IList<int>>();
        if (!nums.Any())
        {
            result.Add(new List<int>());
            return result;
        }

        result.AddRange(
               nums
               .SelectMany(
                       x => Permute(
                                nums
                                .Where(
                                    y => y != x)
                                .ToArray())
                            .Select(
                                y => new List<int> {x}
                                .Concat(y)
                                .ToList()))
               .ToList());
        return result;
    }

    static void Main()
    {
        var s = new Solution();
        foreach (var x in new [] {
                    new [] { 1, 2, 3 },
                    new [] { 1, 2, 3, 4 },
                    new [] { 1, 2, 4, 4, 5 },
                })
        {
            Console.WriteLine(String.Join(Environment.NewLine, s.Permute(x).Select(y => String.Join(", ", y))));
            Console.WriteLine();
        }
    }
}
