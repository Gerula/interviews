// http://careercup.com/question?id=16759664
//
// K lists of sorted ints. Find the smallest range that includes at least one element from 
// each of the list.
//
// For example:
// { 4, 10, 15, 24, 26 }
// { 0, 9, 12, 20 }
// { 5, 18, 22, 30 }
//
// result : [20, 24].
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static Tuple<int, int> Interval(this int[][] lists)
    {
        var first = 0;
        var second = int.MaxValue;
        var k = lists.Length;
        var indexes = new int[k];
        var count = k;
        while (count == k) 
        {
            var min = int.MaxValue;
            for (var i = 0; i < k; i++) 
            {
                min = (indexes[i] < lists[i].Length && lists[i][indexes[i]] < min) ? lists[i][indexes[i]] : min;
            }
            var max = int.MinValue;
            for (var i = 0; i < k; i++) 
            {
                max = (indexes[i] < lists[i].Length && lists[i][indexes[i]] > max) ? lists[i][indexes[i]] : max;
            }
            
            if (max - min < second - first)
            {
                first = min;
                second = max;
            }

            for (var i = 0; i < k; i++) 
            {
                if (lists[i][indexes[i]] == min) 
                {
                    indexes[i]++;
                    if (indexes[i] == lists[i].Length)
                    {
                        count--;
                    }
                }
            }
        }

        return Tuple.Create(first, second);
    }

    static void Main()
    {
        Console.WriteLine(new [] {
                    new [] { 4, 10, 15, 24, 26},
                    new [] { 0, 9, 12, 20 },
                    new [] { 5, 18, 22, 30 }
                }.Interval());
    }
}
