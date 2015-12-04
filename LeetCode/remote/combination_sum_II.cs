// https://leetcode.com/problems/combination-sum-ii/
//
//  Given a collection of candidate numbers (C) and a target number (T), find all unique combinations in C where the candidate numbers sums to T.
//
//  Each number in C may only be used once in the combination.
//
//  Note:
//
//  All numbers (including target) will be positive integers.
//  Elements in a combination (a1, a2, … , ak) must be in non-descending order. (ie, a1 ≤ a2 ≤ … ≤ ak).
//  The solution set must not contain duplicate combinations.
//
//  For example, given candidate set 10,1,2,7,6,1,5 and target 8,
//  A solution set is:
//  [1, 7]
//  [1, 2, 5]
//  [2, 6]
//  [1, 1, 6]
//

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        var result = new List<IList<int>>();
        Array.Sort(candidates);
        Combinations(candidates, 0, target, new List<int>(), result);
        return result;
    }

    public void Combinations(int[] candidates, int index, int target, List<int> partial, IList<IList<int>> result)
    {
        if (target == 0 && !result.Any(x => x.SequenceEqual(partial)))
        {
            result.Add(new List<int>(partial));
            return;
        }

        for (var i = index; i < candidates.Length; i++)
        {
            if (target - candidates[i] >= 0)
            {
                partial.Add(candidates[i]);
                Combinations(candidates, i + 1, target - candidates[i], partial, result);
                partial.RemoveAt(partial.Count - 1);
            }
        }
    }

    static void Main()
    {
        var s = new Solution();
        foreach (var x in s.CombinationSum2(new [] { 10, 1, 2, 7, 6, 1, 5 }, 8))
        {
            Console.WriteLine(String.Join(", ", x));
        }
    }
}
