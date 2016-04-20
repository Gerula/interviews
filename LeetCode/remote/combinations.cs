// https://leetcode.com/problems/combinations/
//
//  Given two integers n and k, return all possible combinations of k numbers out of 1 ... n.
// 
// For example,
// If n = 4 and k = 2, a solution is:
// 
// [
//   [2,4],
//   [3,4],
//   [2,3],
//   [1,2],
//   [1,3],
//   [1,4],
// ]
//
// https://leetcode.com/submissions/detail/44670697/
//
// Not Found
//
// The requested URL /submissions/detail/44670697/ was not found on this server.
//
// Submission Result: Accepted

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    public static IList<IList<int>> CombineClassic(int n, int k) {
        IList<IList<int>> result = new List<IList<int>>();
        Combine(n, 1, k, result, new List<int>());
        return result;
    }

    public static void Combine(int n, int current, int k, IList<IList<int>> result, IList<int> partial)
    {
        if (partial.Count == k)
        {
            var res = new List<int>();
            res.AddRange(partial);
            result.Add(res);
            return;
        }

        for (int i = current; i <= n; i++)
        {
            partial.Add(i);
            Combine(n, i + 1, k, result, partial);
            partial.RemoveAt(partial.Count - 1);
        }
    }

    static IEnumerable<IEnumerable<int>> Combinations(this IEnumerable<int> numbers, int k)
    {
        if (k == 0)
        {
            return new [] { new int[0] };
        }

        return numbers.
                SelectMany((element, index) =>
                           numbers.
                            Skip(index + 1).
                            Combinations(k - 1).
                            Select(c => new [] { element }.Concat(c)));
    }

    //  It's regression, baby!
    //  https://leetcode.com/submissions/detail/59555121/
    //
    //  Submission Details
    //  26 / 26 test cases passed.
    //      Status: Accepted
    //      Runtime: 516 ms
    //          
    //          Submitted: 0 minutes ago
    public class Solution {
        public IList<IList<int>> Combine(int n, int k) {
            return Combinations(Enumerable.Range(1, n).ToList(), k);
        }
        
        public IList<IList<int>> Combinations(IList<int> nums, int k)
        {
            var result = new List<IList<int>>();
            if (k == 0)
            {
                return result;
            }
            
            if (k == 1)
            {
                return nums
                    .Select(x => new List<int> { x })
                    .ToList<IList<int>>();
            }
            
            return nums
                .SelectMany(
                    x => Combinations(nums.Skip(nums.IndexOf(x) + 1).ToList(), k - 1),
                    (x, y) => {
                        return new List<int> { x }
                                .Concat(y)
                                .ToList();
                    })
                .ToList<IList<int>>();
        }
    }

    public static IList<IList<int>> Combine(int n, int k) {
        if (k == 0)
        {
            return (IList<IList<int>>) new List<IList<int>> { new List<int> { n } };
        }
        
        Console.WriteLine(n);
        List<IList<int>> result = new List<IList<int>>();
        result.AddRange(
                        Enumerable
                        .Range(1, n)
                        .Reverse()
                        .SelectMany(x =>
                            Combine(x - 1, k - 1)
                            .Select(y => new List<int> { x }
                                         .Concat(y)
                                         .ToList())
                            .Where(y => y.Count == k)));
        
        return result;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, CombineClassic(4, 2).Select(x => String.Join(", ", x))));
        Console.WriteLine();
        Console.WriteLine(String.Join(Environment.NewLine, Enumerable.Range(1, 4).Combinations(2).Select(x => String.Join(", ", x))));
        Console.WriteLine();
        Console.WriteLine(String.Join(Environment.NewLine, Combine(4, 2).Select(x => String.Join(", ", x))));
    }
}
