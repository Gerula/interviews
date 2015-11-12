// https://leetcode.com/problems/range-sum-query-2d-immutable/
//
// Given a 2D matrix matrix, find the sum of the elements inside the rectangle defined by (row1, col1), (row2, col2).
//
// 
// Submission Details
// 12 / 12 test cases passed.
//  Status: Accepted
//  Runtime: 560 ms
//      
//      Submitted: 0 minutes ago
//

using System;

public class NumMatrix {
    int[,] m;

    public NumMatrix(int[,] matrix) {
        m = new int[matrix.GetLength(0) + 1, matrix.GetLength(1) + 1];
        for (var i = 1; i < m.GetLength(0); i++)
        {
            for (var j = 1; j < m.GetLength(1); j++)
            {
                m[i, j] = m[i, j - 1] + matrix[i - 1, j - 1] +
                          m[i - 1, j] - m[i - 1, j -1];
            }
        }
    }

    public int SumRegion(int row1, int col1, int row2, int col2) {
        return m[row2 + 1, col2 + 1] - m[row1, col1] -
               (m[row1, col2 + 1] - m[row1, col1]) -
               (m[row2 + 1, col1] - m[row1, col1]);
    }

    static void Main()
    {
        var m = new NumMatrix(new [,] 
                    {
                        {3, 0, 1, 4, 2},
                        {5, 6, 3, 2, 1},
                        {1, 2, 0, 1, 5},
                        {4, 1, 0, 1, 7},
                        {1, 0, 3, 0, 5},
                    });

        Console.WriteLine(m.SumRegion(2, 1, 4, 3)); // 8
        Console.WriteLine(m.SumRegion(1, 1, 2, 2)); // 11
        Console.WriteLine(m.SumRegion(1, 2, 2, 4)); // 12
    }
}
