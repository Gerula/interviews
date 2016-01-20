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
        var max = 1;
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                max = Math.Max(max, Longest(i, j, matrix));
            }
        }
        
        return max;
    }
    
    public int Longest(int line, int col, int[,] matrix)
    {
        var max = 0;
        if (line - 1 >= 0 && matrix[line - 1, col] >= matrix[line, col] + 1)
        {
            max = Math.Max(max, 1 + Longest(line - 1, col, matrix));
        }
        
        if (col - 1 >= 0 && matrix[line, col - 1] >= matrix[line, col] + 1)
        {
            max = Math.Max(max, 1 + Longest(line, col - 1, matrix));
        }
        
        if (line + 1 < matrix.GetLength(0) && matrix[line + 1, col] >= matrix[line, col] + 1)
        {
            max = Math.Max(max, 1 + Longest(line + 1, col, matrix));
        }
        
        if (col + 1 < matrix.GetLength(1) && matrix[line, col + 1] >= matrix[line, col] + 1)
        {
            max = Math.Max(max, 1 + Longest(line, col + 1, matrix));
        }
        
        return max == 0 ? 1 : max;
    }
}
