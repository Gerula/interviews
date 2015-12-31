//  https://www.reddit.com/r/dailyprogrammer/comments/3ysdm2/20151230_challenge_247_intermediate_moving/
//
//  Imagine you live on a grid of characters, like the one below. For this example, we'll use a 2*2 grid for simplicity.
//
//  . X
//
//  X .
//
//  You start at the X at the bottom-left, and you want to get to the X at the top-right.
//  However, you can only move up, to the right, and diagonally right and up in one go.
//  This means there are three possible paths to get from one X to the other X (with the path represented by -, + and |):
//
//  +-X  . X  . X
//  |     /     |
//  X .  X .  X-+

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

static class Program
{
    static long Ways(this String path)
    {
        var matrix = new List<String>();
        using (StreamReader reader = new StreamReader(path))
        {
            reader.ReadLine();
            String line = null;
            while ((line = reader.ReadLine()) != null)
            {
                matrix.Add(line);
            }
        }

        var exes = new HashSet<String>();
        var n = matrix.Count;
        var m = matrix.First().Length;
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < m; j++)
            {
                if (matrix[i][j] == 'X')
                {
                    exes.Add(Tuple.Create(i, j).ToString());
                }
            }
        }

        var start = Tuple.Create(n - 1, 0);
        var counts = new Dictionary<String, long>();
        var stack = new Stack<Tuple<int, int>>();
        var visited = new HashSet<String>();
        exes.Remove(start.ToString());
        stack.Push(start);
        counts[start.ToString()] = 1;
        
        while (stack.Count != 0)
        {
            var current = stack.Pop();
            if (visited.Contains(current.ToString()))
            {
                continue;
            }

            visited.Add(current.ToString());
            foreach (var next in new [] {
                Tuple.Create(current.Item1 - 1, current.Item2 + 1),
                Tuple.Create(current.Item1, current.Item2 + 1),
                Tuple.Create(current.Item1 - 1, current.Item2)
            })
            {
                if (!counts.ContainsKey(next.ToString()))
                {
                    counts[next.ToString()] = 0;
                }

                counts[next.ToString()] += counts[current.ToString()];

                if (exes.Contains(next.ToString()))
                {
                    exes.Remove(next.ToString());
                }

                if (0 <= next.Item1 && next.Item2 < m)
                {
                    stack.Push(next);
                }
            }
        }

        Console.WriteLine(String.Join(", ", exes));
        return exes.Any() ? 0 : counts[Tuple.Create(0, m - 1).ToString()];
    }

    static void Main()
    {
        Console.WriteLine("247.1.in".Ways() + " " + 9);
        Console.WriteLine("247.2.in".Ways() + " " + 7625);
        Console.WriteLine("247.3.in".Ways() + " " + 0);
        Console.WriteLine("247.4.in".Ways() + " " + 1);
        Console.WriteLine("247.5.in".Ways() + " " + 19475329563);
        Console.WriteLine("247.6.in".Ways() + " " + 6491776521);
    }
}
