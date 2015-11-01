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
    public static IList<IList<int>> Combine(int n, int k) {
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

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, Combine(4, 2).Select(x => String.Join(", ", x))));
    }
}
