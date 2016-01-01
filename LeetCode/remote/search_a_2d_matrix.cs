//  https://leetcode.com/problems/search-a-2d-matrix-ii/
//
//  Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:
//
//      Integers in each row are sorted in ascending from left to right.
//      Integers in each column are sorted in ascending from top to bottom.

using System;

public class Solution {
    //  
    //  Submission Details
    //  127 / 127 test cases passed.
    //      Status: Accepted
    //      Runtime: 304 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          https://leetcode.com/submissions/detail/49418465/
    //
    //          Idea was good but I kinda got lost in the details
    public bool SearchMatrix(int[,] matrix, int target) {
        var line = 0;
        var column = matrix.GetLength(1) - 1;
        while (line < matrix.GetLength(0) && column >= 0)
        {
            if (matrix[line, column] == target)
            {
                return true;
            }

            if (matrix[line, column] > target)
            {
                column--;
            }
            else
            {
                line++;
            }
        }

        return false;
    }

    static void Main()
    {
        var matrix = new [,] {
                      {1,   4,  7, 11, 15},
                      {2,   5,  8, 12, 19},
                      {3,   6,  9, 16, 22},
                      {10, 13, 14, 17, 24},
                      {18, 21, 23, 26, 30}
                    };
        Console.WriteLine(new Solution().SearchMatrix(matrix, 5));
        Console.WriteLine(new Solution().SearchMatrix(matrix, 20));
    }
}
