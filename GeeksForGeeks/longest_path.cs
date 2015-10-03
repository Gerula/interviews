// http://www.geeksforgeeks.org/find-the-longest-path-in-a-matrix-with-given-constraints/
//
// Given a n*n matrix where numbers all numbers are distinct and are distributed from range 1 to n2,
// find the maximum length path (starting from any cell) such that all cells along the path are
// increasing order with a difference of 1. 

using System;
using System.Collections.Generic;
using System.Linq;

class Program 
{
    static List<int> LongestPath(int[,] m)
    {
        List<int> result = new List<int>();
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
            {
                List<int> localResult = new List<int>();
                LongestPath(m, 0, i, j, localResult);
                if (localResult.Count > result.Count)
                {
                    result = localResult;
                }
            }
        }

        return result;
    }

    static void LongestPath(int[,] m, int prev, int i, int j, List<int> result)
    {
        if (result.Any() &&
                (i < 0 || i == m.GetLength(0) ||
                 j < 0 || j == m.GetLength(1) ||
                 m[i, j] != prev + 1))
        {
            return;
        }
        
        int current = m[i, j];
        result.Add(current);
        LongestPath(m, current, i + 1, j, result);
        LongestPath(m, current, i - 1, j, result);
        LongestPath(m, current, i, j + 1, result);
        LongestPath(m, current, i, j - 1, result);
    }

    static List<int> GetMaxPath(int[,] m, int i, int j)
    {
        List<int> result = new List<int>();
        int lines = m.GetLength(0);
        int columns = m.GetLength(1);
        var current = Tuple.Create(i, j);

        while (current != null)
        {
            int line = current.Item1;
            int column = current.Item2;
            int expectedValue = m[line, column] + 1;
            result.Add(expectedValue - 1);

            if (line > 0 && m[line - 1, column] == expectedValue)
            {
                current = Tuple.Create(line - 1, column);
                continue;
            }

            if (column > 0 && m[line, column - 1] == expectedValue)
            { 
                current = Tuple.Create(line, column - 1);
                continue;
            }

            if (line < lines - 1 && m[line + 1, column] == expectedValue)
            {
                current = Tuple.Create(line + 1, column);
                continue;
            }

            if (column < columns - 1 && m[line, column + 1] == expectedValue)
            {
                current = Tuple.Create(line, column + 1);
                continue;
            }

            current = null;
        }

        return result;
    }

    static void Main() 
    {
        int[,] m = new int[3, 3] {
            { 1, 2, 9 },
            { 5, 3, 8 },
            { 4, 6, 7 }
        };

        Console.WriteLine(String.Join(",", LongestPath(m)));
    }
}
