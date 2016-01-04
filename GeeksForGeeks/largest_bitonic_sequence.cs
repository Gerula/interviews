//  http://www.geeksforgeeks.org/dynamic-programming-set-15-longest-bitonic-subsequence/
//
//  Given an array arr[0 … n-1] containing n positive integers,
//  a subsequence of arr[] is called Bitonic if it is first increasing, then decreasing.
//  Write a function that takes an array as argument and returns the length of the longest bitonic subsequence.
//  A sequence, sorted in increasing order is considered Bitonic with the decreasing part as empty.
//  Similarly, decreasing order sequence is considered Bitonic with the increasing part as empty. 

using System;
using System.Collections.Generic;
using System.Linq;

static class Program 
{
    static int[] Bitonic(this int[] a)
    {
        var n = a.Length;
        var start = new int[n];
        var end = new int[n];
        var prev = new int[n];
        var succ = new int[n];
        for (var i = 0; i < n; i++)
        {
            start[i] = end[i] = 1;
            prev[i] = succ[i] = i;
        }

        for (var i = 1; i < n; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (a[i] > a[j] && start[i] < start[j] + 1)
                {
                    prev[i] = j;
                    start[i] = start[j] + 1;
                }
            }
        }

        for (var i = n - 2; i >= 0; i--)
        {
            for (var j = n - 1; j > i; j--)
            {
                if (a[i] > a[j] && end[i] < end[i] + 1)
                {
                    succ[i] = j;
                    end[i] = end[j] + 1;
                }
            }
        }

        var max = int.MinValue;
        var maxIdx = -1;
        for (var i = 0; i < n; i++)
        {
            if (max < start[i] + end[i] - 1)
            {
                max = start[i] + end[i] - 1;
                maxIdx = i;
            }
        }

        var result = new LinkedList<int>();
        for (var i = maxIdx; prev[i] != i; i = prev[i])
        {
            result.AddFirst(i);
        }

        for (var i = succ[maxIdx]; succ[i] != i; i = succ[i])
        {
            result.AddLast(i);
        }

        return result.ToArray();
    }

    static void Main()
    {
        foreach (var a in new [] {
                    new [] {1, 11, 2, 10, 4, 5, 2, 1},
                    new [] {12, 11, 40, 5, 3, 1},
                    new [] {80, 60, 30, 40, 20, 10}
                })
        {
            Console.WriteLine("{0} - {1}", String.Join(", ", a), String.Join(", ", a.Bitonic()));
        }
    }
}
