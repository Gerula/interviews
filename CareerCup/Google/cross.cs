// http://careercup.com/question?id=5678853664014336
//
// Given an N x N matrix, find and print the largest 
// cross of ones.
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program 
{
    static Tuple<int, int, int> MaxCross(this int[,] a)
    {
        int n = a.GetLength(0);
        var top = (int[,]) a.Clone();
        var left = (int[,]) a.Clone(); 
        var bottom = (int[,]) a.Clone();
        var right  = (int[,]) a.Clone(); 
        for (int i = 1; i < n; i++)
        {
            for (int j = 1; j < n; j++)
            {
                if (a[i,j] == 1) 
                {
                    top[i, j] = top[i - 1, j] + 1;
                    left[i, j] = left[i, j - 1] + 1;
                }
            }
        }

        int maxX, maxY, maxLength;
        maxX = maxY = maxLength = 0;

        for (int i = n - 2; i >= 0; i--)
        {
            for (int j = n - 2; j >= 0; j--)
            {
                if (a[i,j] == 1) 
                {
                    bottom[i, j] = bottom[i + 1, j] + 1;
                    right[i, j] = right[i, j + 1] + 1;
                    int min = new [] {
                                bottom[i, j],
                                right[i, j],
                                top[i, j],
                                left[i, j]
                              }.Min();

                    if (min > maxLength)   
                    {
                        maxLength = min;
                        maxX = i;
                        maxY = j;
                    }
                }
            }
        }

        return Tuple.Create(maxX, maxY, maxLength * 4 - 3);
    }

    static void Print(this int[,] a)
    {
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(0); j++)
            {
                Console.Write("{0} ", a[i,j]);
            }

            Console.WriteLine();
        }
    }

    static void Main()
    {
        new [] {
            new int[,] {
                { 0, 0, 0, 0 },
                { 0, 1, 0, 1 },
                { 1, 1, 1, 1 },
                { 0, 1, 0, 1 }
            },
            new int[,] {
                { 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 1, 0, 0 },
                { 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1 },
                { 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 1, 0, 0 }
            }
        }.ToList().ForEach(x => {
            x.Print();
            var result = x.MaxCross();
            Console.WriteLine(
                "line:{0} column:{1} - side {2}",
                result.Item1,
                result.Item2,
                result.Item3);
            Console.WriteLine();
        });
    }
}
