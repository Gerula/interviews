// https://leetcode.com/problems/permutations-ii/
//
//  Given a collection of numbers that might contain duplicates, return all possible unique permutations.
//
//  For example,
//  [1,1,2] have the following unique permutations:
//  [1,1,2], [1,2,1], and [2,1,1]. 
//
// 
// Submission Details
// 30 / 30 test cases passed.
//  Status: Accepted
//  Runtime: 580 ms
//      
//      Submitted: 0 minutes ago
//

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static IList<IList<int>> PermuteUnique(int[] nums) {
        IList<IList<int>> result = new List<IList<int>>();
        Permutations(nums, 0, result);
        return result;
    }

    static void Permutations(int [] nums, int index, IList<IList<int>> result)
    {
        if (index >= nums.Length)
        {
            result.Add(nums.ToList());
            return;
        }

        for (int i = index; i < nums.Length; i++)
        {
            if (i != index && nums.
                                Skip(index).
                                Take(i - index).
                                Contains(nums[i]))
            {
                continue;
            }
           
            Swap(ref nums[i], ref nums[index]);
            Permutations(nums, index + 1, result);
            Swap(ref nums[i], ref nums[index]);
        }
    }

    static void Swap(ref int a, ref int b)
    {
        int c = a;
        a = b;
        b = c;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(
                            Environment.NewLine,
                            PermuteUnique(new [] { 1, 1, 2 }).
                                Select(x => String.Join(", ", x))));
        Console.WriteLine();
        Console.WriteLine(String.Join(
                            Environment.NewLine,
                            PermuteUnique(new [] { 1, 2, 3 }).
                                Select(x => String.Join(", ", x))));
        Console.WriteLine();
        Console.WriteLine(String.Join(
                            Environment.NewLine,
                            PermuteUnique(new [] { 2, 2, 1, 1 }).
                                Select(x => String.Join(", ", x))));
    }
}
