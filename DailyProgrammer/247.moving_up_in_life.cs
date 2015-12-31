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
        var exes = new HashSet<Tuple<int, int>>();
        var i = 0;
        var m = 0;
        using (StreamReader reader = new StreamReader(path))
        {
            reader.ReadLine();
            String line = null;
            while ((line = reader.ReadLine()) != null)
            {
                i++;
                for (var j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'X')
                    {
                        exes.Add(Tuple.Create(i, j));
                    }
                }

                m = line.Length;
            }
        }
        
        return exes
               .SelectMany(x => exes.Select(y => new { first = x, second = y }))
               .Where(x => x.first.Item1 <= x.second.Item1 && x.first.Item2 <= x.second.Item2)
               .Select(x => CountPaths(x.first.Item1, x.first.Item2, x.second.Item1, x.second.Item2, m))
               .Aggregate(1, (acc, x) => acc * x);
    }

    public static int CountPaths(int x1, int y1, int x2, int y2, int m)
    {
        Console.WriteLine("{0}-{1} {2}-{3}", x1, y1, x2, y2);
        Console.ReadLine();
        if (x1 == x2 && y1 == y2)
        {
            return 1;
        }

        if (x1 < 0 || y2 == m)
        {
            return 0;
        }

        return CountPaths(x1 - 1, y1, x2, y2, m) +
               CountPaths(x1 - 1, y1 + 1, x2, y2, m) + 
               CountPaths(x1, y1 + 1, x2, y2, m);
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
