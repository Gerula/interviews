//  http://www.geeksforgeeks.org/remove-minimum-elements-either-side-2min-max/
//
//  Given an unsorted array, trim the array such that twice of minimum is greater than maximum in the trimmed array.
//  Elements should be removed either end of the array.
//
//  Number of removals should be minimum.

using System;

static class Program
{
    class MinMax
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    static int Balance(this int[] a)
    {
        var n = a.Length;
        var x = new MinMax[n, n];
        for (var i = 0; i < n; i++)
        {
            x[i, i] = new MinMax {
                Min = a[i],
                Max = a[i] 
            };
        }

        for (var j = 1; j < n; j++)
        {
            for (var i = j - 1; i >= 0; i--)
            {
                x[i, j] = new MinMax {
                    Min = Math.Min(x[i + 1, j].Min, a[i]),
                    Max = Math.Max(x[i + 1, j].Max, a[i])
                };
            }
        }

        for (var len = n; len > 0; len--)
        {
            for (var i = 0; i <= n - len; i++)
            {
                if (2 * x[i, i + len - 1].Min > x[i, i + len - 1].Max)
                {
                    return n - len;
                }
            }
        }

        return -1;
    }

    static void Main()
    {
        foreach (var x in new [] {
                    Tuple.Create(new [] {4, 5, 100, 9, 10, 11, 12, 15, 200}, 4),
                    Tuple.Create(new [] {4, 7, 5, 6}, 0),
                    Tuple.Create(new [] {20, 7, 5, 6}, 1),
                    Tuple.Create(new [] {20, 4, 1, 3}, 3)
                })
        {
            Console.WriteLine(
                    "{0} Exp {1} Act {2}",
                    String.Join(", ", x.Item1),
                    x.Item2,
                    x.Item1.Balance());
        }
    }
}
