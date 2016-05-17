//  http://www.geeksforgeeks.org/shortest-path-in-a-binary-maze/
//  Given a MxN matrix where each element can either be 0 or 1.
//  We need to find the shortest path between a given source cell to a destination cell.
//  The path can only be created out of a cell if its value is 1.
//
//  Expected time complexity is O(MN).

using System;
using System.Collections.Generic;

static class Program
{
    static int Down(this int x, int m)
    {
        return x + m + 1;
    }

    static int Right(this int x)
    {
        return x + 1;
    }

    static int Up(this int x, int m)
    {
        return x - m - 1;
    }

    static int Left(this int x)
    {
        return x - 1;
    }

    static bool Deserialize(this int x, int[,] a,  out int line, out int column)
    {
        line = x / a.GetLength(1) + 1; 
        column = x % a.GetLength(1) + 1;
        return 0 <= line && line < a.GetLength(0) &&
               0 <= column && column < a.GetLength(1);
    }

    static int SerializeAt(this int[,] a, int x)
    {
        var line = 0;
        var column = 0;

        return x.Deserialize(a, out line, out column) &&
               a[line, column] == 1 ? 1 : 0;
    }

    static int ShortestPath(this int[,] a, Tuple<int, int> startTuple, Tuple<int, int> endTuple)
    {
        var m = a.GetLength(1);
        var start = startTuple.Item1 * m + startTuple.Item2 + 1;
        var end = endTuple.Item1 * m + endTuple.Item2 + 1;
        var queue = new Queue<int>();
        queue.Enqueue(start);
        var visited = new HashSet<int>();
        visited.Add(start);
        var distance = new Dictionary<int, int>();
        distance[start] = 0;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current == end)
            {
                return distance[current];
            }

            if (a.SerializeAt(current.Down(m)) == 1) { queue.Enqueue(current.Down(m)); }
            if (a.SerializeAt(current.Right()) == 1) { queue.Enqueue(current.Right()); }
            if (a.SerializeAt(current.Up(m)) == 1) { queue.Enqueue(current.Up(m)); }
            if (a.SerializeAt(current.Left()) == 1) { queue.Enqueue(current.Left()); }
        }

        return -1;
    }

    static void Main()
    {
        Console.WriteLine(new [,] {{1, 0, 1, 1, 1, 1, 0, 1, 1, 1 },
                                   {1, 0, 1, 0, 1, 1, 1, 0, 1, 1 },
                                   {1, 1, 1, 0, 1, 1, 0, 1, 0, 1 },
                                   {0, 0, 0, 0, 1, 0, 0, 0, 0, 1 },
                                   {1, 1, 1, 0, 1, 1, 1, 0, 1, 0 },
                                   {1, 0, 1, 1, 1, 1, 0, 1, 0, 0 },
                                   {1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                                   {1, 0, 1, 1, 1, 1, 0, 1, 1, 1 },
                                   {1, 1, 0, 0, 0, 0, 1, 0, 0, 1 }}.ShortestPath(
                                                                       Tuple.Create(0, 0),
                                                                       Tuple.Create(3, 4)));
    }
}
