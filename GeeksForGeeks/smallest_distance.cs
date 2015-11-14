// http://qa.geeksforgeeks.org/5173/fill-the-distances-to-nearest-gates
//
// You are given a m x n 2D grid initialized with these three possible values.
//
//  -1 - A wall or an obstacle.
//   0 - A gate.
//   INF - Infinity means an empty room. We use the value 231 - 1 = 2147483647 to represent INF
//   as you may assume that the distance to a gate is less than2147483647.
//
// Fill each empty room with the distance to its nearest gate. If it is impossible to reach a gate, it should be filled with INF. 
//

using System;
using System.Collections.Generic;

static class Program
{
    static int[,] Print(this int[,] a)
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
        return a;
    }

    static int[,] Fill(this int[,] a)
    {
        var q = new Queue<KeyValuePair<int, int>>();
        for (var i = 0; i < a.GetLength(0); i++)
        {
            for (var j = 0; j < a.GetLength(1); j++)
            {
                if (a[i, j] == 0)
                {
                    q.Enqueue(new KeyValuePair<int, int>(i, j));
                }
            }
        }
        
        while (q.Count > 0)
        {
            var current = q.Dequeue();
            var x = current.Key;
            var y = current.Value;
            for (var i = Math.Max(x - 1, 0); i <= Math.Min(a.GetLength(0) - 1, x + 1); i++)
            {
                for (var j = Math.Max(y - 1, 0); j <= Math.Min(a.GetLength(1) - 1, y + 1); j++)
                {
                    if (a[i, j] == int.MaxValue && (Math.Abs(x - i) + Math.Abs(y - j) != 2))
                    {
                        a[i, j] = a[x, y] + 1;
                        q.Enqueue(new KeyValuePair<int, int>(i, j));
                    }
                }
            }
        }

        return a;
    }

    static void Main()
    {
        new int[,] {
            {int.MaxValue,  -1,  0,  int.MaxValue},
            {int.MaxValue, int.MaxValue, int.MaxValue, -1},
            {int.MaxValue, -1, int.MaxValue, -1},
            {0, -1, int.MaxValue, int.MaxValue}
        }.
        Print().
        Fill().
        Print();
    }
}
