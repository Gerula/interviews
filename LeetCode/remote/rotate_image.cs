//  https://leetcode.com/problems/rotate-image/
//
//  You are given an n x n 2D matrix representing an image.
//
//  Rotate the image by 90 degrees (clockwise).

using System;

static class Solution {
    //  
    //  Submission Details
    //  20 / 20 test cases passed.
    //      Status: Accepted
    //      Runtime: 164 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          https://leetcode.com/submissions/detail/48980539/
    static void Rotate(int[,] matrix) {
        var n = matrix.GetLength(0);

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n - i; j++)
            {
                var c = matrix[i, j];
                matrix[i, j] = matrix[n - j - 1, n - i - 1];
                matrix[n - j - 1, n - i - 1] = c;
            }
        }

        for (var j = 0; j < n; j++)
        {
            for (var i = 0; i < n / 2; i++)
            {
                var c = matrix[i, j];
                matrix[i, j] = matrix[n - i - 1, j];
                matrix[n - i - 1, j] = c;
            }
        }
    }
    
    public static void Print(this int[,] a)
    {
        for (var i = 0; i < a.GetLength(0); i++)
        {
            for (var j = 0; j < a.GetLength(1); j++)
            {
                Console.Write(a[i, j] + " ");
            }

            Console.WriteLine();
        }
    }

    static void Main()
    {
        var a = new int[3, 3];
        var k = 1;
        for (var i = 0; i < a.GetLength(0); i++)
        {
            for (var j = 0; j < a.GetLength(0); j++)
            {
                a[i, j] = k++;
            }
        }

        a.Print();
        Rotate(a);
        Console.WriteLine();
        a.Print();
    }
}
