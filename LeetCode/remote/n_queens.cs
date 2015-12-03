// https://leetcode.com/problems/n-queens/
//
// The n-queens puzzle is the problem of placing n queens on an n×n chessboard such that no two queens attack each other.
//
// Given an integer n, return all distinct solutions to the n-queens puzzle.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution {
    public IList<IList<string>> SolveNQueens(int n) {
        var result = new List<IList<String>>();
        Queens(0, n, new List<int>(), result);
        return result;
    }

    static void Queens(int level, int n, List<int> partial, IList<IList<String>> result)
    {
        if (level == n)
        {
            result.Add(partial.Select(x => ToBoard(n, x)).ToList());
            return;
        }

        for (var i = 0; i < n; i++)
        {
            bool valid = true;
            var levels = level;
            for (var k = 0; k < partial.Count && valid; k++)
            {
                var low = i - levels;
                var high = i + levels;
                levels--;
                valid = partial[k] != i && partial[k] != low && partial[k] != high;
            }

            if (!valid)
            {
                continue;
            }

            partial.Add(i);
            Queens(level + 1, n, partial, result);
            partial.RemoveAt(partial.Count - 1);
        }
    }

    static String ToBoard(int n, int val)
    {
        var result = new StringBuilder(new String(Enumerable.Repeat('.', n).ToArray()));
        result[val] = 'Q';
        return result.ToString();
    }

    static void Main()
    {
        var c = new Solution();
        Console.WriteLine(String.Join(Environment.NewLine + Environment.NewLine, c.SolveNQueens(4).Select(x => String.Join(Environment.NewLine, x))));
    }
}
