// http://careercup.com/question?id=5693045032878080
//
// There are N ranges of numberes. Find Kth smallest element.
//

using System;
using System.Collections;
using System.Linq;

static class Program
{
    static int kth(this Tuple<int, int>[] intervals, int k)
    {
        return intervals.
                Aggregate(
                 new BitArray(intervals.Last().Item2 + 1),
                 (acc, x) => {
                    Enumerable.
                        Range(x.Item1, x.Item2 - x.Item1 + 1).
                        ToList().
                        ForEach(i => {
                            acc[i] = true;
                        });

                    return acc;
                 }).
                Cast<bool>().
                Select((z, w) => new { index = w, val = z}).
                Where(b => b.val).
                Select(a => a.index).
                ToList()[k];
    }

    static void Main()
    {
        var input = new [] {
            Tuple.Create(2, 8),
            Tuple.Create(5, 10),
            Tuple.Create(7, 20)
        };

        for (int i = 3; i < 10; i++)
        {
           Console.WriteLine("{0} -> {1}", i, input.kth(i));
        }
    }
}

