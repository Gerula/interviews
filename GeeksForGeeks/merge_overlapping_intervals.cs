// http://www.geeksforgeeks.org/merging-intervals/
//
// Given a set of time intervals in any order, merge all overlapping intervals
// into one and output the result which should have only mutually exclusive intervals.
// Let the intervals be represented as pairs of integers for simplicity.
// For example, let the given set of intervals be {{1,3}, {2,4}, {5,7}, {6,8} }.
// The intervals {1,3} and {2,4} overlap with each other, so they should be merged and become {1, 4}.
// Similarly {5, 7} and {6, 8} should be merged and become {5, 8}
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program 
{
    static IEnumerable<Tuple<int, int>> Merge(this Tuple<int, int>[] a)
    {
        var sorted = a.ToList().OrderBy(x => x.Item1);
        var prev = sorted.First();
        foreach (var interval in sorted.Skip(1).Take(sorted.Count() - 1))
        {
            if (interval.Item1 <= prev.Item2)
            {
                prev = Tuple.Create(prev.Item1, interval.Item2);
            }
            else
            {
                yield return prev;
                prev = interval;
            }
        }

        yield return prev;
    }

    static String Stringify(this Tuple<int, int> tuple)
    {
        return String.Format("[{0}, {1}]", tuple.Item1, tuple.Item2);
    }

    static void Main()
    {
        Console.WriteLine(String.Join(", ", new [] {
                        Tuple.Create(1, 3),
                        Tuple.Create(2, 4),
                        Tuple.Create(5, 7),
                        Tuple.Create(6, 8)
                    }.Merge().Select(x => x.Stringify())));
    }
}
