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
}
