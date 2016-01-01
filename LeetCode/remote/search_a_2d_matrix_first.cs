//  https://leetcode.com/problems/search-a-2d-matrix/
//
//  Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:
//
//      Integers in each row are sorted from left to right.
//          The first integer of each row is greater than the last integer of the previous row.
//

using System;

public class Solution {
    //  
    //  Submission Details
    //  134 / 134 test cases passed.
    //      Status: Accepted
    //      Runtime: 168 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          https://leetcode.com/submissions/detail/49418717/
    //          Booyakasha!
    public bool SearchMatrix(int[,] matrix, int target) {
        var line = 0;
        var column = matrix.GetLength(1) - 1;
        while (line < matrix.GetLength(0) && matrix[line, column] < target)
        {
            line++;
        }

        if (line == matrix.GetLength(0))
        {
            return false;
        }

        while (column >= 0 && matrix[line, column] > target)
        {
            column--;
        }

        return column >= 0 && matrix[line, column] == target;
    }

    static void Main()
    {
        var matrix = new [,] {
            {1,   3,  5,  7},
            {10, 11, 16, 20},
            {23, 30, 34, 50}
        };

        Console.WriteLine(new Solution().SearchMatrix(matrix, 3));
        Console.WriteLine(new Solution().SearchMatrix(matrix, 50));
        Console.WriteLine(new Solution().SearchMatrix(matrix, 31));
    }
}
