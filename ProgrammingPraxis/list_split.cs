// http://programmingpraxis.com/2015/12/04/minimum-split/
//
// Given a list of integers,
// find the place where the list can be split
// in two that minimizes the differences in the sums of the two halves of the list.
// For instance, given the list [3,7,4,2,1],
// splitting after the second element of the list gives sums of 10 and 7 for the two halves of the list,
// for a difference of 3, and no other split gives a lower difference.

using System;
using System.Linq;

static class Program
{
    static Tuple<int[], int[]> Split(this int[] a)
    {
        var left = 0;
        var right = a.Sum();
        var split = 0;
        var minSplit = 0;
        var minDiff = int.MaxValue;
        while (right > 0)
        {
            split++;
            right -= a[split - 1];
            left += a[split - 1];
            var diff = Math.Abs(right - left);
            if (diff < minDiff)
            {
                minSplit = split;
                minDiff = diff;
            }
        }

        return Tuple.Create(a.Take(minSplit).ToArray(), a.Skip(minSplit).ToArray());
    }

    static void Print(this Tuple<int[], int[]> t)
    {
        Console.WriteLine("{0} - {1}", String.Join(", ", t.Item1), String.Join(", ", t.Item2));
    }

    static void Main()
    {
        new [] { 3, 7, 4, 2, 1 }.Split().Print();
    }
}
