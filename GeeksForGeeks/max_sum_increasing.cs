//  http://www.geeksforgeeks.org/dynamic-programming-set-14-maximum-sum-increasing-subsequence/
//
//  Given an array of n positive integers.
//  Write a program to find the sum of maximum sum subsequence
//  of the given array such that the intgers in the subsequence are sorted in increasing order.
//  For example, if input is {1, 101, 2, 3, 100, 4, 5},
//  then output should be 106 (1 + 2 + 3 + 100),
//  if the input array is {3, 4, 5, 10},
//  then output should be 22 (3 + 4 + 5 + 10) and if the input array is {10, 5, 4, 3}, then output should be 10 

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static int[] MaxIncreasing(this int[] a)
    {
        var n = a.Length;
        var dp = new int[n];
        var pre = new int[n];
        for (var i = 0; i < n; i++)
        {
            pre[i] = i;
            dp[i] = a[i];
        }

        for (var i = 1; i < n; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (a[i] > a[j] && dp[i] < dp[j] + a[i])
                {
                    dp[i] = dp[j] + a[i];
                    pre[i] = j;
                }
            }
        }

        var max = 0;
        var idx = -1;
        for (var i = 0; i < n; i++)
        {
            if (dp[i] > max)
            {
                max = dp[i];
                idx = i;
            }
        }

        var result = new LinkedList<int>();
        while (idx != pre[idx])
        {
            result.AddFirst(a[idx]);
            idx = pre[idx];
        }

        result.AddFirst(a[idx]);

        return result.ToArray();
    }

    static void Main()
    {
        foreach (var a in new [] {
                    new [] { 1, 101, 2, 3, 100, 4, 5 },
                    new [] { 3, 4, 5, 10 },
                    new [] { 10, 5, 4, 3 }
                })
        {
            var x = a.MaxIncreasing();
            Console.WriteLine("[{0}] == [{1}] : {2}", String.Join(", ", a), String.Join(", ", x), x.Sum());
        }
    }
}
