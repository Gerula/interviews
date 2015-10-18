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

    static int kth_inplace(this Tuple<int, int>[] intervals, int k)
    {
        var prev = intervals[0];
        int start = prev.Item1;
        int count = prev.Item2 - prev.Item1 + 1;
        int maxRight = prev.Item2;
        int maxLeft = prev.Item1;
        if (k <= count) 
        {
            return start + (count - k) + 1;
        }

        foreach (var interval in intervals.Skip(1))
        {
            if (interval.Item2 > maxRight)
            {
                maxRight = interval.Item2; 
                if (interval.Item1 > maxRight)
                {
                    maxLeft = interval.Item2;
                    k -= count;
                    count = interval.Item2 - interval.Item1 + 1;
                    start = interval.Item1;
                }
                else
                {
                    count += interval.Item2 + 1 - maxLeft;
                }
            }

            if (k <= count) 
            {
                return start + (count - k) + 1;
            }
        }

        return 0;
    }

    static void Main()
    {
        var input = new [] {
            Tuple.Create(2, 8),
            Tuple.Create(5, 10),
            Tuple.Create(7, 20)
        };

        for (int i = 3; i <= 10; i++)
        {
           Console.WriteLine(
                   "{0} -> {1} -> {2}",
                   i,
                   input.kth(i),
                   input.kth_inplace(i));
        }
    }
}

