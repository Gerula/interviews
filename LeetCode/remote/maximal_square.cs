// https://leetcode.com/problems/maximal-square/
//
//  Given a 2D binary matrix filled with 0's and 1's, find the largest square containing all 1's and return its area.
//
//  For example, given the following matrix:
//
//  1 0 1 0 0
//  1 0 1 1 1
//  1 1 1 1 1
//  1 0 0 1 0
//
//  Return 4. 
//
// 
// Submission Details
// 67 / 67 test cases passed.
//  Status: Accepted
//  Runtime: 156 ms
//      
//      Submitted: 0 minutes ago
//

using System;

public class Solution {
    public int MaximalSquare(char[,] matrix) {
        var mins = new int[matrix.GetLength(0), matrix.GetLength(1)];
        int max = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            mins[i, 0] = matrix[i, 0] == '1' ? 1 : 0;
            max = Math.Max(max, mins[i, 0]);
        }

        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            mins[0, i] = matrix[0, i] == '1' ? 1 : 0;
            max = Math.Max(max, mins[0, i]);
        }
        
        for (int i = 1; i < matrix.GetLength(0); i++)
        {
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == '1')
                {
                    mins[i, j] = Math.Min(mins[i - 1, j - 1], Math.Min(mins[i - 1, j], mins[i, j - 1])) + 1;
                    max = Math.Max(max, mins[i, j]);
                }
            }
        }

        return max * max;
    }

    static void Main()
    {
        Console.WriteLine(new Solution().MaximalSquare(new char[,] {
                                                        {'1', '0', '1', '0', '0'},
                                                        {'1', '0', '1', '1', '1'},
                                                        {'1', '1', '1', '1', '1'},
                                                        {'1', '0', '0', '1', '0'}
                                                      }));
    }
}
