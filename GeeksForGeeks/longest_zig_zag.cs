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
    static List<int> ZigZag(this int[] a)
    {
        int n = a.Length;
        var smaller = Enumerable.Repeat(1, n).ToArray();
        var larger = Enumerable.Repeat(1, n).ToArray();
        var smallerParent = new Dictionary<int, int>();
        var largerParent = new Dictionary<int, int>();
        int max = int.MinValue;
        int maxIdx = -1;
        bool lastSmaller = true;

        for (var i = 1; i < n; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (a[i] > a[j] && smaller[i] < larger[j] + 1)
                {
                    smaller[i] = larger[j] + 1;
                    smallerParent[i] = j;
                }

                if (a[i] < a[j] && larger[i] < smaller[j] + 1)
                {
                    larger[i] = smaller[j] + 1;
                    largerParent[i] = j;
                }

                var localMax = smaller[i];
                var flag = true;
                if (localMax < larger[i])
                {
                    localMax = larger[i];
                    flag = false; 
                }

                if (localMax > max)
                {
                    max = localMax;
                    maxIdx = i;
                    lastSmaller = flag;
                }
            }
        }

        var result = new List<int>();
        var dictionary = lastSmaller ? smallerParent : largerParent;
        result.Add(a[maxIdx]);
        while (dictionary.ContainsKey(maxIdx))
        {
            maxIdx = dictionary[maxIdx];
            result.Add(a[maxIdx]);
            lastSmaller = !lastSmaller;
            dictionary = lastSmaller ? smallerParent : largerParent;
        }

        result.Reverse();
        return result;
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
                    String.Join(", ", x.ZigZag()));
        }
    }
}
