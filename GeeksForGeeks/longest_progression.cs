//  http://www.geeksforgeeks.org/length-of-the-longest-arithmatic-progression-in-a-sorted-array/
//
//  Given a set of numbers, find the Length of the Longest Arithmetic Progression (LLAP) in it.
//
//  Examples:
//
//  set[] = {1, 7, 10, 15, 27, 29}
//  output = 3
//  The longest arithmetic progression is {1, 15, 29}
//
//  set[] = {5, 10, 15, 20, 25, 30}
//  output = 6
//  The whole set is in AP

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int Prog(int[] a)
    {
        return Enumerable
               .Range(0, a.Length)
               .Select(x => Prog(a, x, 0, 0))
               .Max();
    }

    static int Prog(int[] a, int pos, int offset, int next)
    {
        if (pos == 0)
        {
            return 1;
        }

        if (next != 0)
        {
            if (next == a[pos])
            {
                return 1 + Prog(a, pos - 1, offset, next - offset);
            }

            return 0;
        }

        var max = 0;
        for (var i = pos - 1; i >= 0; i--)
        {
            max = Math.Max(max, Prog(a, pos - 1, a[pos] - a[i], a[i]) + 1);
        }

        return max;
    }

    static int Prog2(int[] a)
    {
        var n = a.Length;
        var dp = Enumerable
                 .Range(0, n)
                 .Select(x => new Dictionary<int, int>())
                 .ToArray();

        var next = Enumerable
                   .Range(0, n)
                   .ToArray();
        var max = int.MinValue;
        var maxIdx = -1;
        for (var i = n - 1; i >= 0; i--)
        {
            for (var j = i + 1; j < n; j++)
            {
                var diff = a[j] - a[i];
                dp[i][diff] = 1 + (dp[j].ContainsKey(diff) ? dp[j][diff] : 1);
                if (max <= dp[i][diff])
                {
                    max = dp[i][diff];
                    maxIdx = i;
                    next[i] = j;
                }
            }
        }

        while (next[maxIdx] != maxIdx)
        {
            Console.Write("{0} ", a[maxIdx]);
            maxIdx = next[maxIdx];
        }

        Console.WriteLine("{0} ", a[maxIdx]);
        return max;
    }

    static void Main()
    {
        Console.WriteLine(Prog(new [] { 1, 7, 10, 15, 27, 29 }));
        Console.WriteLine(Prog(new [] { 5, 10, 15, 20, 25, 30 }));
        Console.WriteLine(Prog2(new [] { 1, 7, 10, 15, 27, 29 }));
        Console.WriteLine(Prog2(new [] { 5, 10, 15, 20, 25, 30 }));
    }
}
