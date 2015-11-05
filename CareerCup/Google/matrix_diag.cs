// Given an N x N matrix,
// print it diagonally.
//
// 1 2 3    1  2  3  4
// 4 5 6    5  6  7  8
// 7 8 9    9 10 11 12
//         13 14 15 16 
//
// 1        1
// 2 4      2 5
// 3 5 7    3 6 9
// 6 8      4 7 10 13
// 9        8 11 14
//          12 15
//          16

using System;

static class Program
{
    static void Diagonal(this int[,] a)
    {
        var n = a.GetLength(0);
        for (var i = 0; i < 2 * n - 1; i++)
        {
            var start = i < n ? 0 : i - n + 1;
            for (var j = start; j <= i - start; j++)
            {
                Console.Write("{0} ", a[j, i - j]);
            }

            Console.WriteLine();
        }
    }

    static void Main()
    {
        new int[, ] {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        }.Diagonal();
    }
}
