//  https://leetcode.com/problems/combination-sum/
//
//   Given a set of candidate numbers (C) and a target number (T),
//   find all unique combinations in C where the candidate numbers sums to T.
//
//   The same repeated number may be chosen from C unlimited number of times. 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    //  
    //  Submission Details
    //  168 / 168 test cases passed.
    //      Status: Accepted
    //      Runtime: 540 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        var solution = new List<IList<int>>();
        Comb(candidates, 0, target, solution, new List<int>());
        return solution;
    }

    public void Comb(int[] candidates, int index, int target, IList<IList<int>> result, List<int> partial)
    {
        if (target == 0)
        {
            result.Add(new List<int>(partial));
        }

        for (var i = index; i < candidates.Length; i++)
        {
            if (candidates[i] > target || partial.Any() && partial.Last() > candidates[i]) 
            {
                continue;
            }

            partial.Add(candidates[i]);
            Comb(candidates, index, target - candidates[i], result, partial);
            partial.RemoveAt(partial.Count - 1);
        }
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, new Solution().CombinationSum(new [] { 2, 3, 6, 7 }, 7).Select(x => String.Join(", ", x))));
    }
}
