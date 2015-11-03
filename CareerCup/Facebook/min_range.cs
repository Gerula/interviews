// http://careercup.com/question?id=6262661043978240
//
// Given a set of ranges and a target range write an algorithm to find the smallest set of ranges
// that covers the target range.
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program 
{
    static String Print(this Tuple<int, int> t)
    {
        return String.Format("[{0}, {1}]", t.Item1, t.Item2);
    }

    static List<Tuple<int, int>> SmallestRange(this List<Tuple<int, int>> intervals, Tuple<int, int> target)
    {
        var start = new HashSet<Tuple<int, int>>();
        var end = new HashSet<Tuple<int, int>>();
        var neighbors = new Dictionary<Tuple<int, int>, HashSet<Tuple<int, int>>>();
        foreach (var interval in intervals)
        {
            if (interval.Over(target))
            {
                start.Add(interval);
            }

            if (interval.Under(target))
            {
                end.Add(interval);
            }

            if (!neighbors.ContainsKey(interval))
            {
                neighbors[interval] = new HashSet<Tuple<int, int>>();
            }

            foreach (var other in neighbors.Keys.Where(x => x != interval))
            {
                if (other.Over(interval))
                {
                    neighbors[other].Add(interval);
                }

                if (interval.Over(other))
                {
                    neighbors[interval].Add(other);
                }
            }
        }

        Console.WriteLine(neighbors.Print());
        Console.WriteLine("Start {0} ", start.Print());
        Console.WriteLine("End {0} ", end.Print());
        var queue = new Queue<Tuple<int, int>>();
        var prev = new Dictionary<Tuple<int, int>, Tuple<int, int>>();
        start.
            ToList().
            ForEach(x => {
                        queue.Enqueue(x);
                        prev[x] = x;
                    });
        Tuple<int, int> current = null; 
        while (queue.Any())
        {
            current = queue.Dequeue();
            Console.WriteLine(current);
            if (end.Contains(current))
            {
                break;
            }

            if (!neighbors.ContainsKey(current))
            {
                continue;
            }

            foreach(var neighbor in neighbors[current]) 
            {
                queue.Enqueue(neighbor);
                prev[neighbor] = current;
            }
        }

        if (!end.Contains(current))
        {
            return new List<Tuple<int, int>>();
        }

        var result = new List<Tuple<int, int>>();
        Console.WriteLine(current);
        Console.WriteLine(String.Join("| ", prev.Keys.Select(x => String.Format("{0} - {1}", x, String.Join(",", prev[x])))));
        while (!start.Contains((prev[current])))
        {
            result.Add(current);
            current = prev[current];
        }

        result.Add(prev[current]);
        result.Reverse();
        return result;
    }

    static String Print(this Dictionary<Tuple<int, int>, HashSet<Tuple<int, int>>> dictionary)
    {
        return String.Join(
                ", ",
                dictionary.Keys.Select(x => 
                    String.Format(
                        "[{0}] - [{1}]",
                        x.Print(),
                        String.Join(
                            ",",
                            dictionary[x].Select(y => y.Print()))
                    )));
    }

    static String Print(this HashSet<Tuple<int, int>> set)
    {
        return String.Join(
                ", ",
                set.Select(x => x.Print()));
    }

    static bool Over(this Tuple<int, int> first, Tuple<int, int> second)
    {
        return first.Item1 <= second.Item1 && second.Item1 <= first.Item2;
    }

    static bool Under(this Tuple<int, int> first, Tuple<int, int> second)
    {
        return first.Item1 <= second.Item2 && second.Item2 <= first.Item2;
    }

    static void Main()
    {
        var result = new [] { 
                        Tuple.Create(1, 4),
                        Tuple.Create(30, 40),
                        Tuple.Create(20, 91),
                        Tuple.Create(8, 10),
                        Tuple.Create(6, 7),
                        Tuple.Create(3, 9),
                        Tuple.Create(9, 12),
                        Tuple.Create(11, 14)
                    }.
                    ToList().
                    SmallestRange(Tuple.Create(3, 13)).
                    Select(x => x.Print()).
                    ToList();
        Console.WriteLine("END DEBUG");
        Console.WriteLine(String.Join(", ", result));
    }
}
