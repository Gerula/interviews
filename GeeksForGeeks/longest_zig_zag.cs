//  http://www.geeksforgeeks.org/longest-zig-zag-subsequence/
//
//  The longest Zig-Zag subsequence problem is to find length of the longest subsequence of given sequence such that all elements of this are alternating.
//  If a sequence {x1, x2, .. xn} is alternating sequence then its element satisfy one of the following relation :
//
//    x1 < x2 > x3 < x4 > x5 < …. xn or 
//    x2 > x2 < x3 > x4 < x5 > …. xn 

using System;
using System.Collections.Generic;
using System.Linq;

static class Solution
{
    static int ZigZag(this int[] a)
    {
        int n = a.Length;
        var smaller = Enumerable.Repeat(1, n).ToArray();
        var larger = Enumerable.Repeat(1, n).ToArray();

        int max = int.MinValue;

        for (var i = 1; i < n; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (a[i] > a[j])
                {
                    smaller[i] = Math.Max(smaller[i], larger[j] + 1);
                }
                if (a[i] < a[j])
                {
                    larger[i] = Math.Max(larger[i], smaller[j] + 1);
                }

                max = Math.Max(Math.Max(smaller[i], larger[i]), max);
            }
        }

        return max;
    }

    static void Main()
    {
        foreach (var x in new [] {
                    new [] {1, 5, 4},
                    new [] {1, 4, 5},
                    new [] {10, 22, 9, 33, 49, 50, 31, 60}
                })
        {
            Console.WriteLine(
                    "{0} - {1}",
                    String.Join(", ", x),
                    x.ZigZag());
        }
    }
}
