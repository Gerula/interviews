//  https://leetcode.com/problems/spiral-matrix-ii/
//
//  Given an integer n, generate a square matrix filled with elements from 1 to n2 in spiral order.

using System;

public class Solution {
    //  
    //  Submission Details
    //  21 / 21 test cases passed.
    //      Status: Accepted
    //      Runtime: 52 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          https://leetcode.com/submissions/detail/49650919/
    //
    public int[,] GenerateMatrix(int n) {
        var max = n * n;
        var line = 0;
        var column = -1;
        var offset = 0;
        var a = new int [n, n];
        var offsets = new [] {
            new [] { 0,  1},
            new [] { 1,  0},
            new [] { 0, -1},
            new [] {-1,  0}
        };

        for (var x = 1; x <= max; x++)
        {
            var nextLine = line + offsets[offset][0];
            var nextColumn = column + offsets[offset][1];
            if (!(0 <= nextLine && nextLine < n &&
                  0 <= nextColumn && nextColumn < n) ||
                  a[nextLine, nextColumn] != 0)
            {
                offset = (offset + 1) % offsets.Length;
                nextLine = line + offsets[offset][0];
                nextColumn = column + offsets[offset][1];
            }

            line = nextLine;
            column = nextColumn;
            a[line, column] = x;
        }

        return a;
    }

    public static void Print(int [,] a)
    {
        for (var i = 0; i < a.GetLength(0); i++)
        {
            for (var j = 0; j < a.GetLength(1); j++)
            {
                Console.Write("{0} ", a[i, j]);
            }
            
            Console.WriteLine();
        }

        Console.WriteLine();
    }

    static void Main()
    {
        for (var i = 1; i < 10; i++)
        {
            Print(new Solution().GenerateMatrix(i));
        }
    }
}
