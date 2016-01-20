//  Given an integer matrix, find the length of the longest increasing path.
//
//  From each cell, you can either move to four directions: left, right, up or down. You may NOT move diagonally or move outside of the boundary (i.e. wrap-around is not allowed).
//
//  Example 1:
//
//  nums = [
//   [9,9,4],
//   [6,6,8],
//   [2,1,1]
//  ]
//
//  Return 4
//  The longest increasing path is [1, 2, 6, 9].
//
//  Example 2:
//
//  nums = [
//   [3,4,5],
//   [3,2,6],
//   [2,2,1]
//  ]
//
//  Return 4
//  The longest increasing path is [3, 4, 5, 6]. Moving diagonally is not allowed.

using System;

public class Solution {
    public int LongestIncreasingPath(int[,] matrix) {
        var max = 0;
        var cache = new int[matrix.GetLength(0), matrix.GetLength(1)];
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                max = Math.Max(max, Longest(i, j, matrix, cache));
            }
        }
        
        return max;
    }
    
    public int Longest(int line, int col, int[,] matrix, int[,] cache)
    {
        if (cache[line, col] > 0)
        {
            return cache[line, col];
        }
        
        var max = 0;
        if (line - 1 >= 0 && matrix[line - 1, col] >= matrix[line, col] + 1)
        {
            max = Math.Max(max, Longest(line - 1, col, matrix, cache));
        }
        
        if (col - 1 >= 0 && matrix[line, col - 1] >= matrix[line, col] + 1)
        {
            max = Math.Max(max, Longest(line, col - 1, matrix, cache));
        }
        
        if (line + 1 < matrix.GetLength(0) && matrix[line + 1, col] >= matrix[line, col] + 1)
        {
            max = Math.Max(max, Longest(line + 1, col, matrix, cache));
        }
        
        if (col + 1 < matrix.GetLength(1) && matrix[line, col + 1] >= matrix[line, col] + 1)
        {
            max = Math.Max(max, Longest(line, col + 1, matrix, cache));
        }
        
        cache[line, col] = max + 1;
        return cache[line, col];
    }

    public int LongestIncreasingPath2(int[,] matrix)
    {
        var n = matrix.GetLength(0);
        var m = matrix.GetLength(1);
        var leftUp = new int[n, m, 2];
        var rightDown = new int[n, m, 2];

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < m; j++)
            {
                if (i >= 1)
                {
                    var smaller = matrix[i - 1, j] >= matrix[i, j] ? 1 : 0;
                    leftUp[i, j, smaller] = Math.Max(leftUp[i, j, smaller], leftUp[i - 1, j, smaller]); 
                }

                if (j >= 1)
                {
                    var smaller = matrix[i, j - 1] >= matrix[i, j] ? 1 : 0;
                    leftUp[i, j, smaller] = Math.Max(leftUp[i, j, smaller], leftUp[i, j - 1, smaller]); 
                }

                leftUp[i, j, 0]++;
                leftUp[i, j, 1]++;
            }
        }

        for (var i = n - 1; i >= 0; i--)
        {
            for (var j = m - 1; j >= 0; j--)
            {
                if (i < n - 1)
                {
                    var smaller = matrix[i + 1, j] >= matrix[i, j] ? 1 : 0;
                    rightDown[i, j, smaller] = Math.Max(rightDown[i, j, smaller], rightDown[i + 1, j, smaller]); 
                }

                if (j < m - 1)
                {
                    var smaller = matrix[i, j + 1] >= matrix[i, j] ? 1 : 0;
                    rightDown[i, j, smaller] = Math.Max(rightDown[i, j, smaller], rightDown[i, j + 1, smaller]); 
                }

                rightDown[i, j, 0]++;
                rightDown[i, j, 1]++;
            }
        }

        var max = 0;
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < m; j++)
            {
                max = Math.Max(max, Math.Max(leftUp[i, j, 0] + rightDown[i, j, 1] - 1, leftUp[i, j, 1] + rightDown[i, j, 0] - 1));
            }
        }

        return max;
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.LongestIncreasingPath2(new [,] { {9, 9, 4}, {6, 6, 8}, {2, 1, 1} }));
        Console.WriteLine(s.LongestIncreasingPath2(new [,] { {3, 4, 5}, {3, 2, 6}, {2, 2, 1} }));
        Console.WriteLine(s.LongestIncreasingPath2(new [,] { {1} }));
    }
}
